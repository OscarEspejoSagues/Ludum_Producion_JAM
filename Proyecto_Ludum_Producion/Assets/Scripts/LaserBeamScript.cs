using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeamScript : MonoBehaviour
{

    public float TimeAlive = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Autodestroy", TimeAlive,1);
    }
    public void Autodestroy()
    {
        Destroy(transform.parent.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision) //trigger to kill Player
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerDeath>().Die = true;
        }
    }

    void Update()
    {

    }
}
