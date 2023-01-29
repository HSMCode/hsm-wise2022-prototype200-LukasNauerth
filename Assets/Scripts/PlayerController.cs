using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float horizontalInput;
    private float forwardInput;
    [SerializeField] float turnSpeed;    
    [SerializeField] float speed;

    private Animator _playerAnim;

    private Rigidbody _playerRb;
 
    
    // public float forceDown;
    public float gravityModifier = 1f;

    public bool isOnGround;



    // Start is called before the first frame update
    void Start()
    {
        // _playerAnim = GetComponent<Animator>();
        _playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        transform.Rotate(Vector3.up * horizontalInput * Time.deltaTime * turnSpeed);
        transform.Translate(Vector3.forward * forwardInput * Time.deltaTime * speed);
        
       
        
        // release space to start falling - player isFalling
    }
    void FixedUpdate()
    {
        if(isOnGround)
        {
           gravityModifier = 10f;
        }

        _playerRb.AddForce(Physics.gravity * (gravityModifier - 1) * _playerRb.mass);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        

        }
    }

}
