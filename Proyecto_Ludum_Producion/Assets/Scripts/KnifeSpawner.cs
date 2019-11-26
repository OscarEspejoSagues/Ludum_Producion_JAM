using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeSpawner : MonoBehaviour
{

    public int NumberOfKnifes = 10;
    public float Rate = 0.1f;
    public float Speed = 5.0f;
    public bool NegativeX = false;
    public bool MakeItRain = false;
    public GameObject Knife;

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

    // Update is called once per frame
    void Update()
    {
        if (MakeItRain)
        {
            Instantiate(Knife, transform.parent.transform.position, transform.parent.transform.rotation);
        }
        MovementX();
    }
}
