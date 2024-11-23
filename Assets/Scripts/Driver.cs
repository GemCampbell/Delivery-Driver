using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Driver : MonoBehaviour
{
    public float moveSpeed;
    public float turnSpeed;
    
    
    void Start()
    {
        
    }

    
    void Update()
    {
        float turnAmount = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime ;     //RETURNS A VALUE BETWEEN 1 AND -1 DEPENDING ON PLAYER INPUT
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        transform.Rotate(0, 0, -turnAmount);

        transform.Translate(0, moveAmount, 0);
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        print("I have hit a: " + other.gameObject.tag);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        print("I have run over a: " + other.gameObject.tag);
    }
}
