using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeSpawner : MonoBehaviour
{

    public int NumberOfKnifes = 10;
    public float Rate = 0.1f;
    public float Speed = 5.0f;
    public bool NegativeX = false;
    public bool GoUp = false;

    public GameObject Knife;

    private float nextActionTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void SpawnKnife()
    {
        Instantiate(Knife, transform.parent.transform.position, transform.parent.transform.rotation);
    }

    public void MovementX()
    {
        Vector2 _newPosition = new Vector2(transform.parent.transform.position.x, transform.parent.transform.position.y);
        if (NegativeX)
        {
            _newPosition.x -= Mathf.Sin(Time.time) * Time.deltaTime * Speed;
        }
        else
        {
            _newPosition.x += Mathf.Sin(Time.time) * Time.deltaTime * Speed;
        }
        transform.parent.transform.position = _newPosition;
    }



    void Update()
    {
        MovementX();
        if (Time.time > nextActionTime)
        {
            nextActionTime += Rate;
            GameObject knife = Instantiate(Knife, transform.parent.position, transform.parent.rotation);
            if (!GoUp)
            {
                knife.transform.GetChild(0).GetComponent<KnifeLogic>().MoveUp = true;
            }
            else
            {
                knife.transform.GetChild(0).GetComponent<KnifeLogic>().MoveUp = false;
            }

        }
        if (Time.time > 5)
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
