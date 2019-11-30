using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerDeath : MonoBehaviour
{
    public bool Die = false;
    public AudioSource myFx;
    public AudioClip deathFx;
    public ScoreManager ScoreManager;
    private float volume;

    private Animator m_Animator;
    private int state = 0;


    // Start is called before the first frame update
    void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
        myFx.volume = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Die)
        {
            switch (state)
            {
                case 0:
                    myFx.PlayOneShot(deathFx);
                    Time.timeScale = 0.2f;
                    state++;
                    break;

                case 1:
                    m_Animator.SetBool("Die", true);
                    transform.GetComponent<PlayerController>().death = true;
                    state++;
                    break;

                case 2: //Texto de muerte

                    break;
            }
        }
    }

    public void ShowScoreScreen()
    {
        if (ScoreManager)
        {
            ScoreManager.ShowScoreScreen();
        }
    }
}
