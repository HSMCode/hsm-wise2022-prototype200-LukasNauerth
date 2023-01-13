using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    private ScoreTimer scoreUI; //adds score to ScoreTimer


    private GameObject _player;
    public float turnSpeed;
    public bool isRotating;




    public Vector3 targetPosition;
    public float smoothTime = 0.5f; 
    public float speed;
    Vector3 velocity;


    void Start()
    {
        scoreUI = GameObject.Find("Canvas").GetComponent<ScoreTimer>(); //finds the script
    }

    void FixedUpdate ()
    {
        if(isRotating)
        {
            transform.Rotate(0,0,turnSpeed); 
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime, speed);
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            scoreUI.addScore(); //adds one to the score in the other script
            isRotating = true;
            Destroy(this.gameObject,1.5f);
            
        }
    }

}
