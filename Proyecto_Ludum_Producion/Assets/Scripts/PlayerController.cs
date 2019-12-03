using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Private vars
    private Rigidbody2D rb2d;
    private Vector2 movement;
    private float defaultSpeed;

    //Public vars
    public float speed;
    public float rotationSpeed;
    public bool death = false;
    public bool freezed = false;
    public bool invertControls = false;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        transform.localScale = new Vector3(0.5f, 0.5f, 0.0f);
        defaultSpeed = speed;

    }

    // Update is called once per frame
    private void Update()
    {
        if (!death && !freezed && !invertControls)
        {
            movement.x = Input.GetAxis("Horizontal");
            movement.y = Input.GetAxis("Vertical");
            speed = defaultSpeed;
        }
        else if (freezed || death)
        {
            movement = Vector3.zero;
        }
        else if (invertControls)
        {
            movement.x = -Input.GetAxis("Horizontal");
            movement.y = -Input.GetAxis("Vertical");
            speed = defaultSpeed;
        }
    }
    private void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + movement * speed * Time.fixedDeltaTime);
    }
}
