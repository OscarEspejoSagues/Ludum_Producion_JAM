using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialDeathTrap : MonoBehaviour
{

    private Vector2 pos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pos.y = transform.position.y - 0.05f;
        transform.transform.position = pos;
    }
}
