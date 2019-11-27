using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColorTime : MonoBehaviour
{
    //VARIABLES
    public Text timeTitle;
    int counterTime;

    // Start is called before the first frame update
    void Start()
    {
        counterTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        counterTime++;

        if(counterTime > 0 && counterTime < 25)
        {
            timeTitle.color = Color.white;
        }
        else if (counterTime > 25 && counterTime < 50)
        {
            timeTitle.color = Color.red;
        }
        else if (counterTime > 50 && counterTime < 75)
        {
            timeTitle.color = Color.blue;
        }
        else if (counterTime > 75 && counterTime < 100)
        {
            timeTitle.color = Color.green;

            if(counterTime > 95 && counterTime < 100)
            {
                counterTime = 0;
            }
        }
    }
}
