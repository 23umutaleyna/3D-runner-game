using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    [SerializeField] int playerScore = 10; 
    float speed = 5.5f; 
    bool isGameOver = false; 
    [SerializeField] string schoolName = "Kodland"; 

    void Start()
    {        
        Debug.Log(playerScore);
        Debug.Log(speed);
        Debug.Log(isGameOver);
        Debug.Log(transform.position);

        if(playerScore > 10)
        {
            Debug.Log("You Win!");
        }
        else
        {
            Debug.Log("You Lose!");
        }
    }
    void Update()
    {
        Debug.Log(schoolName);
    }
}
