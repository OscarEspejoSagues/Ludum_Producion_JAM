using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour
{
    public GameObject Arrow;
    public GameObject DeathTrap;
    public SpriteRenderer TextImage;
    public Sprite[] TextToShow;
    public float Rate = 5.0f;
    public GameObject PlayButton;
    public PlayerController PlayerController;

    private int CurrentText = 0;
    private float nextActionTime = 5.0f;
    private float actionTimer = 0f;

    private void Awake()
    {
        DeathTrap.SetActive(false);
    }

    void Start()
    {
        TextImage.sprite = TextToShow[CurrentText];

        Time.timeScale = 1f;
    }


    // Update is called once per frame
    void Update()
    {
        actionTimer += Time.deltaTime;

        if (actionTimer > nextActionTime)
        {
            nextActionTime += Rate;
            CurrentText++;
            TextImage.sprite = TextToShow[CurrentText];
            switch (CurrentText)
            {
                case 1:
                    //transform.parent.position = new Vector3(8.0f, -1.12f, 1.0f);
                    //Arrow.transform.position = Vector3.zero;
                    Arrow.GetComponent<Animator>().SetTrigger("Animation2");
                    break;
                case 2:
                    Arrow.SetActive(false);
                    //transform.parent.position = new Vector3(0.77F, -1.17f, 1.0f);
                    break;
                case 6:
                    DeathTrap.SetActive(true);
                    //PlayButton.SetActive(true);
                    break;
                case 7:
                    break;
            }
        }

        if (PlayerController.death)
        {
            PlayButton.SetActive(true);
        }
    }
}
