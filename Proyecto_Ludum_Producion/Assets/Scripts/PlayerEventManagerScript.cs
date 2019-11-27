using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEventManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    //Public vars
    public float zoomSpeed = 1;
    public float targetOrtho;
    public float smoothSpeed = 2.0f;
    public float minOrtho = 1.0f;
    public float maxOrtho = 5.0f;
    public bool enableEvent = false;
    public enum events {ZOOMIN,SPEEDDEBUFF,SPEEDBUFF };

    public Transform _camera;
    public Vector3 offset;

    public float debuffSpeed;
    public float buffSpeed;

    private float defaultSpeed;


    void Start()
    {
        targetOrtho = Camera.main.orthographicSize;
        defaultSpeed = this.transform.parent.GetComponent<PlayerController>().speed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if(enableEvent)
            eventManager(events.SPEEDBUFF);
        else
        {

            targetOrtho += zoomSpeed;
            targetOrtho = Mathf.Clamp(targetOrtho, minOrtho, maxOrtho);
            this.transform.parent.GetComponent<PlayerController>().speed = defaultSpeed;
        }
        Camera.main.orthographicSize = Mathf.MoveTowards(Camera.main.orthographicSize, targetOrtho, smoothSpeed * Time.deltaTime);

        
    }

    public void eventManager(events eventNumber)
    {
       
        switch (eventNumber)
        {
            case events.ZOOMIN:
                targetOrtho -= zoomSpeed;
                targetOrtho = Mathf.Clamp(targetOrtho, minOrtho, maxOrtho);
                _camera.position = new Vector3(transform.position.x + offset.x, transform.position.y + offset.y, _camera.position.z);

                this.transform.parent.GetComponent<PlayerController>().speed = defaultSpeed;
                break;
            case events.SPEEDDEBUFF:
                this.transform.parent.GetComponent<PlayerController>().speed = debuffSpeed;

                targetOrtho += zoomSpeed;
                targetOrtho = Mathf.Clamp(targetOrtho, minOrtho, maxOrtho);
                break;
            case events.SPEEDBUFF:
                this.transform.parent.GetComponent<PlayerController>().speed = buffSpeed;

                targetOrtho += zoomSpeed;
                targetOrtho = Mathf.Clamp(targetOrtho, minOrtho, maxOrtho);
                break;

        }
    }
}
