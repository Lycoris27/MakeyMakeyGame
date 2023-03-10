using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Change : States
{
    public Color myColor;
    private Image image;
    

    // Start is called before the first frame update
    void Awake()
    {
        image = this.GetComponent<Image>();
    }
    
    void Start()
    {
        //myColor.a = 1;
        
        
    }

    // Update is called once per frame
    void Update()
    {

        GetInput();
        GetReaction();
        if (countingDown)
        {
            print(timer);
            CountDown();
        }


    }
    
    private void GetReaction()
    {
        if(winState && !secretState)
        {
            image.color = new Color32(255,0,0,255);
        }
        if(failState && !secretState)
        {
            image.color = new Color32(0,255,0,255);
        }
        if(secretState)
        {
            image.color = new Color32(0,0,255,255);
        }
        if(neutralState)
        {
            image.color = new Color32(125,125,125,225);
        }
    }

}
