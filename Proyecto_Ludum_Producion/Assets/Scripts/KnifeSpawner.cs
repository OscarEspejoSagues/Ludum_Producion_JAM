using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeSpawner : MonoBehaviour
{

    //public int NumberOfKnifes = 10;
    public float Rate = 0.1f;
    public float Speed = 5.0f;
    public bool NegativeX = false;
    public bool GoUp = false;

    public GameObject Knife;

    private float nextActionTime = 0.0f;

    private float lifeTimer = 0f;
    private float globalTimer = 0f;
    private float movementTimer = 2.7f;    //It doesn't start at 0f because it needs an adjustment

    // Start is called before the first frame update
    void Start()
    {

    }

    public void SpawnKnife()
    {
        Instantiate(Knife, transform.position, transform.rotation);
    }

    public void MovementX()
    {
        Vector2 _newPosition = new Vector2(transform.position.x, transform.position.y);
        if (NegativeX)
        {
            _newPosition.x -= Mathf.Sin(movementTimer) * Time.deltaTime * Speed;
        }
        else
        {
            _newPosition.x += Mathf.Sin(movementTimer) * Time.deltaTime * Speed;
        }
        transform.position = _newPosition;
    }



    void Update()
    {
        globalTimer += Time.deltaTime;
        lifeTimer += Time.deltaTime;
        movementTimer += Time.deltaTime;

        MovementX();
        if (globalTimer > nextActionTime)
        {
            nextActionTime += Rate;
            GameObject knife = Instantiate(Knife, transform.position, transform.rotation, transform);
            if (!GoUp)
            {
                knife.transform.GetChild(0).GetComponent<KnifeLogic>().MoveUp = true;
            }
            else
            {
                knife.transform.GetChild(0).GetComponent<KnifeLogic>().MoveUp = false;
            }
        }

        if (lifeTimer > 5f)
        {
            Destroy(this);
        }
    }

    public void InitializeTrap (float rate, float speed, bool negativeX, bool goUp)
    {
        Speed = speed;
        NegativeX = negativeX;
        GoUp = goUp;
    }
}
