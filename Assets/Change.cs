using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Change : States
{
    public Color myColor;
    private Image image;
    [SerializeField] public GameObject secret;
    

    // Start is called before the first frame update
    void Awake()
    {
        image = this.GetComponent<Image>();
        secret = GameObject.Find("SecretPanel");
        secret.SetActive(false);
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
            image.color = new Color32(255,0,0,50);
        }
        if(failState && !secretState)
        {
            image.color = new Color32(0,255,0,50);
        }
        if(secretState)
        {
            image.color = new Color32(0,0,255,50);
            ShowSecret();
        }
        if(neutralState)
        {
            image.color = new Color32(125,125,125,225);
            ShowSecret();
        }
    }
    private void ShowSecret()
    {
        if(secretState)
        {
            secret.SetActive(true);
        }
        else
        {
            secret.SetActive(false);
        }
    }

}
