using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using TMPro;

public class Driver : MonoBehaviour
{
    public float moveSpeed;
    public float turnSpeed;

    public bool hasPackage;
    public float destroyDelay;

    public int playerScore;
    public int scoreAmount;

    public TextMeshProUGUI scoreText;
    
    
    void Start()
    {
        hasPackage = false;
        playerScore = 0;
        UpdateScoreText();
    }

    
    void Update()
    {
        float turnAmount = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime ;     //RETURNS A VALUE BETWEEN 1 AND -1 DEPENDING ON PLAYER INPUT
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        transform.Rotate(0, 0, -turnAmount);

        transform.Translate(0, moveAmount, 0);
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
            playerScore += scoreAmount;
            UpdateScoreText();

            hasPackage = false;
        }
    }


    void UpdateScoreText()
    {
        scoreText.text = "Score: " + playerScore.ToString();
    }
}
