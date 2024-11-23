using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using TMPro;

public class Driver : MonoBehaviour
{
    //SPEEDS
    public float currentSpeed;
    public float normalSpeed;
    public float slowSpeed;
    public float boostSpeed;
    public float turnSpeed;

    //TIMERS
    public float slowSpeedTimer;
    public float slowSpeedTimerMax;
    public float boostTimer;
    public float boostTimerMax;
    public bool hasCollided;

    public bool hasPackage;
    public float destroyDelay;

    public int playerScore;
    public int scoreValue;

    public TextMeshProUGUI scoreText;


    void Start()
    {
        currentSpeed = normalSpeed; 
        hasPackage = false;
        playerScore = 0;
        UpdateScoreText();
    }

    
    void Update()
    {
        float turnAmount = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime ;     //RETURNS A VALUE BETWEEN 1 AND -1 DEPENDING ON PLAYER INPUT
        float moveAmount = Input.GetAxis("Vertical") * currentSpeed * Time.deltaTime;

        transform.Rotate(0, 0, -turnAmount);

        transform.Translate(0, moveAmount, 0);

        if (currentSpeed == slowSpeed && hasCollided == true)
        {
            slowSpeedTimer += Time.deltaTime;
            
            if (slowSpeedTimer > slowSpeedTimerMax)
            {
                hasCollided = false;
                currentSpeed = normalSpeed;
                slowSpeedTimer = 0;
            }
        }


        if (currentSpeed == boostSpeed)
        {
            boostTimer += Time.deltaTime;

            if (boostTimer > boostTimerMax)
            {
                currentSpeed = normalSpeed;
                boostTimer = 0;
            }
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {        
        if (other.gameObject.tag == "Package" && hasPackage == false)
        {
            hasPackage = true;
            Destroy(other.gameObject, destroyDelay);
        }

        
        if (other.gameObject.tag == "Customer" && hasPackage == true)
        {
            playerScore += scoreValue;
            UpdateScoreText();

            hasPackage = false;
        }


        if (other.gameObject.tag == "Boost")
        {
            currentSpeed = boostSpeed;
        }
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        currentSpeed = slowSpeed;
        hasCollided = true;
    }


    void UpdateScoreText()
    {
        scoreText.text = "Score: " + playerScore.ToString();
    }
}
