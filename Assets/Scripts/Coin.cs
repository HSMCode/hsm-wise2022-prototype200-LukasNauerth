using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    private ScoreTimer scoreUI; //adds score to ScoreTimer

    public AudioSource collectFX;

    private GameObject _player;
    public float turnSpeed;



    public Vector3 targetPosition;
    public float smoothTime = 0.5f; 
    public float speed;
    Vector3 velocity;


    void Start()
    {
        scoreUI = GameObject.Find("Canvas").GetComponent<ScoreTimer>(); //finds the script
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            collectFX.Play();
            scoreUI.addScore(); //adds one to the score in the other script
          
            this.gameObject.SetActive(false);
            
        }
    }

}
