using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Private vars
    private Rigidbody2D rb2d;
    Vector2 movement;
    //Public vars
    public float speed;
    public float rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        transform.localScale = new Vector3(0.5f, 0.5f, 0.0f);
    }

    // Update is called once per frame
    private void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        rotatePlayer();

    }
    private void FixedUpdate()
    {

        rb2d.MovePosition(rb2d.position + movement * speed * Time.fixedDeltaTime);
    }

    private void rotatePlayer()
    {
        if (Input.GetKeyDown("w"))
        {
            //Vector2 direction = transform
        }
        if (Input.GetKeyDown("a"))
        {

        }
        if (Input.GetKeyDown("s"))
        {

        }
        if (Input.GetKeyDown("d"))
        {

        }
        //Vector2 direction = transform.forward - transform.position;
        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        //transform.localRotation = Quaternion.Slerp(transform.localRotation, rotation, rotationSpeed * Time.deltaTime);
    }
}
