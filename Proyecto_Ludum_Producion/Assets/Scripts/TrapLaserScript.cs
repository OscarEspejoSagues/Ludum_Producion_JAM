using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapLaserScript : MonoBehaviour
{

    public SpriteRenderer mySprite;
    public int NumberOfLasers;
    public GameObject myLaserPrefab;

    public float Speed;
    public bool MoveX;
    public bool NegativeX;
    public bool MoveY;
    public bool NegativeY;


    private int state = 0;

    void Start()
    {

    }

    public void InstanceLasers()
    {
        GameObject lastLaser = null;
        GameObject aux = null;
        for (int i = 0; i <= NumberOfLasers; i++)
        {
            if (aux == null)
            {
                lastLaser = Instantiate(myLaserPrefab, transform.position, transform.rotation);
                lastLaser.transform.SetParent(transform);
                aux = lastLaser;
            }
            else
            {
                lastLaser = Instantiate(myLaserPrefab, aux.transform.GetChild(2).position, aux.transform.GetChild(2).rotation);
                lastLaser.transform.SetParent(transform);
                aux = lastLaser;
            }
        }
        state++;
    }

    public void MovementX()
    {
        Vector2 _newPosition = new Vector2(transform.position.x, transform.position.y);
        if (NegativeX)
        {
            _newPosition.x -= Mathf.Sin(Time.time) * Time.deltaTime * Speed;
        }
        else
        {
            _newPosition.x += Mathf.Sin(Time.time) * Time.deltaTime * Speed;
        }
        transform.position = _newPosition;
    }

    public void MovementY()
    {
        Vector2 _newPosition = new Vector2(transform.position.x, transform.position.y);
        if (NegativeY)
        {
            _newPosition.y -= Mathf.Sin(Time.time) * Time.deltaTime * Speed;
        }
        else
        {
            _newPosition.y += Mathf.Sin(Time.time) * Time.deltaTime * Speed;
        }

        transform.position = _newPosition;
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
            case 2:
                if (MoveX)
                {
                    MovementX();
                }
                if (MoveY)
                {
                    MovementY();
                }
                break;
        }
    }

    public void InitializeTrap(int lasersNum, float speed, bool moveX, bool negativeX, bool moveY, bool negativeY)
    {
        NumberOfLasers = lasersNum;

        Speed = speed;
        MoveX = moveX;
        NegativeX = negativeX;
        MoveY = moveY;
        NegativeY = negativeY;
    }
}
