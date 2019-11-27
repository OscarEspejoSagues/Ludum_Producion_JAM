using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventUI : MonoBehaviour
{
    public GameLogic GameLogic;

    public void UnfreezeGame()
    {
        GameLogic.UnfreezeGame();

        Debug.Log("game unfreezed");
    }

    public void AnimationIn()
    {
        GetComponent<Animator>().SetTrigger("DescIn");

        Debug.Log("text appears");
    }

    public void AnimationOut()
    {
        GetComponent<Animator>().SetTrigger("DescOut");

        Debug.Log("text disappears");
    }
}
