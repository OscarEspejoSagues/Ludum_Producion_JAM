using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum events { NONE, ZOOMIN, SPEEDDEBUFF, SPEEDBUFF, BLUR, FOW};

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

    public events CurrentEvent = events.NONE;

    public Transform _camera;
    public Vector3 offset;

    public float debuffSpeed;
    public float buffSpeed;

    public GameObject BlurDebuff;
    public GameObject FOWDebuff;

    private float defaultSpeed;


    void Start()
    {
        targetOrtho = Camera.main.orthographicSize;
        defaultSpeed = transform.parent.GetComponent<PlayerController>().speed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (enableEvent)
            eventManager(CurrentEvent);
        else
        {

            targetOrtho += zoomSpeed;
            targetOrtho = Mathf.Clamp(targetOrtho, minOrtho, maxOrtho);
            transform.parent.GetComponent<PlayerController>().speed = defaultSpeed;

            FOWDebuff.SetActive(false);
            BlurDebuff.SetActive(false);
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

                transform.parent.GetComponent<PlayerController>().speed = defaultSpeed;
                break;

            case events.SPEEDDEBUFF:
                transform.parent.GetComponent<PlayerController>().speed = debuffSpeed;

                targetOrtho += zoomSpeed;
                targetOrtho = Mathf.Clamp(targetOrtho, minOrtho, maxOrtho);
                break;

            case events.SPEEDBUFF:
                transform.parent.GetComponent<PlayerController>().speed = buffSpeed;

                targetOrtho += zoomSpeed;
                targetOrtho = Mathf.Clamp(targetOrtho, minOrtho, maxOrtho);
                break;

            case events.BLUR:
                BlurDebuff.SetActive(true);
                break;

            case events.FOW:
                FOWDebuff.SetActive(true);
                break;

            case events.NONE:
                break;
        }
    }
}
