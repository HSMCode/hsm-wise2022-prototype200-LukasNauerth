using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreTimer : MonoBehaviour
{
    //other Variables
    private GameObject _inGameUI;
    private GameObject _gameOverUI;

    //Variables Timer
    private Text timerUI;
    private string timerText = "Zeit: ";
    public float timeLeft = 60f;
    private bool countingDown; //Timer running down


    //Variables Score 
    private Text scoreUI;
    private string scoreText = "Coins Collected: ";
    private int currentScore = 0;
    public int winScore = 10;

    //result Variables
    private bool gameWon;
    private Text resultUI;
    private string resultWon = "Du hast gewonnen!";
    private string resultLost = "Du hast verloren!";
    

    // Start is called before the first frame update
    void Start()
    {
        _inGameUI = GameObject.Find("InGame");
        _gameOverUI = GameObject.Find("GameOver");

        scoreUI = GameObject.Find("Score").GetComponent<Text>();
        timerUI = GameObject.Find("Timer").GetComponent<Text>();
        resultUI = GameObject.Find("Result").GetComponent<Text>();

        scoreUI.text = scoreText + currentScore.ToString();

        _inGameUI.SetActive(true);
        _gameOverUI.SetActive(false);

        countingDown = true;   
    }

    // Update is called once per frame
    void Update()
    {
        if(countingDown)
        {
            CountdownTimer();
        }
        
    }


    private void CountdownTimer() //timer
    {

        if(timeLeft > 0) // reduce by one the timer
        {
            timeLeft -= Time.deltaTime;
            timerUI.text = timerText + Mathf.Round(timeLeft).ToString();
        }
        else //if the timer runs out
        {
            timeLeft = 0;
            timerUI.text = timerText + timeLeft.ToString();
            countingDown = false;

            CheckGameOver();
        }

    }

    private void CheckGameOver()
    {
        // GameOver WIN
        if(currentScore >= winScore)
        {
            gameWon = true;

            StartCoroutine(GameOver());
        }
        // GameOver LOST
        else if(currentScore < winScore && !countingDown)
        {
            gameWon = false;
            
            StartCoroutine(GameOver());
        }
        
    }

    private IEnumerator GameOver()
    {
        yield return new WaitForSeconds(2f);

        if (gameWon) //changes Color of the result, if the game is won
        {
            resultUI.text = resultWon;
            resultUI.color = Color.green;
        }
        else if (!gameWon)//changes Color of result, if the game ist lost
        {
            resultUI.text = resultLost;
            resultUI.color = Color.red;
        }
        
        //sets the UI
        _inGameUI.SetActive(false);
        _gameOverUI.SetActive(true);

    }

    public void addScore() //adds 1 Point to the score
    {
        currentScore++;
        scoreUI.text = scoreText + currentScore.ToString(); 
    }

    
}
