using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeLogic : MonoBehaviour
{
    public SpriteRenderer MySprite;
    public int RotationSpeed = 5;
    public bool NegativeX = false;
    public float Speed = 2.0f;


    private float movementTimer = 2.7f;

    // Start is called before the first frame update
    private void Awake()
    {

    }
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) //trigger to kill Player
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerDeath>().Die = true;
        }
    }

    public void Movement()
    {
        //he acabado copiando el movimiento de alex para no liarla mas

        movementTimer += Time.deltaTime;
        Vector2 _newPosition = new Vector2(transform.parent.position.x, transform.parent.position.y);
        if (NegativeX)
        {
            _newPosition.x -= Mathf.Sin(movementTimer) * Time.deltaTime * Speed;
        }
        else
        {
            _newPosition.x += Mathf.Sin(movementTimer) * Time.deltaTime * Speed;
        }
        transform.parent.position = _newPosition;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        MySprite.transform.Rotate(0, 0, 50 * Time.deltaTime * RotationSpeed);
    }

    public void InitializeTrap(int rotationspeed, bool negativeX,float speed)
    {
      RotationSpeed = rotationspeed;
      NegativeX = negativeX;
      Speed = speed;
}
}
