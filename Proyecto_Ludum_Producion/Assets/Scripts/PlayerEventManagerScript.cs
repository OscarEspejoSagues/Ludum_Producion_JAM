using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEventManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float zoomSpeed = 1;
    public float targetOrtho;
    public float smoothSpeed = 2.0f;
    public float minOrtho = 1.0f;
    public float maxOrtho = 5.0f;
    public bool zoomIn = false;

    public Transform _camera;
    public Vector3 offset;

    void Start()
    {
        targetOrtho = Camera.main.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (zoomIn)
        {
            targetOrtho -=  zoomSpeed;
            targetOrtho = Mathf.Clamp(targetOrtho, minOrtho, maxOrtho);
            _camera.position = new Vector3(transform.position.x + offset.x, transform.position.y + offset.y, _camera.position.z);

        }
        else if(!zoomIn)
        {
            targetOrtho +=  zoomSpeed;
            targetOrtho = Mathf.Clamp(targetOrtho, minOrtho, maxOrtho);
        }

        Camera.main.orthographicSize = Mathf.MoveTowards(Camera.main.orthographicSize, targetOrtho, smoothSpeed * Time.deltaTime);
    }
}
