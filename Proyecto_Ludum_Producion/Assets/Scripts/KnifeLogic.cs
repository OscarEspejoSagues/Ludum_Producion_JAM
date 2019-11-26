using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeLogic : MonoBehaviour
{
    public float Speed = 5.0f;
    private Vector2 parentPosition;

    // Start is called before the first frame update
    void Start()
    {
        parentPosition = transform.parent.transform.position;
        InvokeRepeating("Autodestroy", 5.0f, 1);
    }

    public void Autodestroy()
    {
       // Destroy(transform.parent.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        parentPosition.y = parentPosition.y - Speed;
        transform.parent.transform.position = parentPosition;
    }
}
