using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeLogic : MonoBehaviour
{
    public float Speed = 5.0f;
    public bool MoveUp = false;

    public GameObject Particles;

    private Vector2 parentPosition;

    
    // Start is called before the first frame update
    void Start()
    {
        parentPosition = transform.parent.transform.position;
        InvokeRepeating("Autodestroy", 5.0f, 1);
    }

    public void Autodestroy()
    {
        Destroy(transform.parent.gameObject);
    }

    public void Movement()
    {
        if (MoveUp)
        {
            parentPosition.y = parentPosition.y - Speed;
            transform.parent.transform.position = parentPosition;
        }
        else
        {
            parentPosition.y = parentPosition.y + Speed;
            transform.parent.transform.position = parentPosition;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) //trigger to kill Player
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerDeath>().Die = true;
        }
        else if(collision.tag == "Wall")
        {
            Instantiate(Particles, transform.position, transform.rotation, transform.parent.parent);
            Destroy(transform.parent.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
}
