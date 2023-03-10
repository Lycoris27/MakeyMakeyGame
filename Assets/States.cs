using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class States : MonoBehaviour
{
    [Header("State")]
    [SerializeField] protected bool failState = false;
    [SerializeField] protected bool winState = false;
    [SerializeField] protected bool secretState = false;
    [SerializeField] protected bool neutralState = true;

    protected float timer = 0f;
    protected bool countingDown = false;
    //Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        GetInput();
        print(timer);

    }
    
    protected void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.W) && !winState)
        {
            failState = true;
            neutralState = false;
        }
        if (Input.GetKeyDown(KeyCode.A) && !failState)
        {
            winState = true;
            neutralState = false;
        }
        if(Input.GetKeyDown(KeyCode.S) && secretState)
        {
            secretState = false;
            neutralState = true;
            EndTimer();
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            secretState = true;
            neutralState = false;
            StartTimer();
            print(timer);
        }
        if (Input.GetKeyDown(KeyCode.D) && (failState || winState || secretState))
        {
            failState = false;
            winState = false;
            secretState = false;
            neutralState = true;
            EndTimer();

        }
    }
    protected void CountDown()
    {
        if (timer > 0f)
        {
            print(timer);
            timer = timer - Time.deltaTime;
        }
        else
        {
            print(timer);
            print("CountDown Done!");
            secretState = false;
            neutralState = true;
            EndTimer();
        }
    }
    protected void StartTimer()
    {
        timer = 10f;
        countingDown = true;
    }
    protected void EndTimer()
    {
        timer = 0f;
        countingDown = false;
    }
}
