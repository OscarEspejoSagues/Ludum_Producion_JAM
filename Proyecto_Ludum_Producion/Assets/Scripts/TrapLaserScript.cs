using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapLaserScript : MonoBehaviour
{

    public SpriteRenderer mySprite;
    public int NumberOfLasers;
    public GameObject myLaserPrefab;

    private int state = 0;

    void Start()
    {
 
    }

    public void InstanceLasers()
    {
        GameObject lastLaser = null;
        GameObject aux = null;
        for (int i = 0; i<=NumberOfLasers; i++)
        {
            if (aux == null)
            {
                lastLaser = Instantiate(myLaserPrefab, transform.position, transform.rotation);
                aux = lastLaser;
            }
            else
            {
                lastLaser = Instantiate(myLaserPrefab, aux.transform.GetChild(2).position, aux.transform.GetChild(2).rotation);
                aux = lastLaser;
            }
        }
        state++;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case 0: //appear
                state++;
                break;
            case 1: //start blasting
                InstanceLasers();
                break;
        }
    }
}
