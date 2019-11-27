using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnFX : MonoBehaviour
{
    public AudioSource myFx;
    public AudioClip hoverFx;
    public AudioClip clickFx;
    private float volume;

    private void Start()
    {
        myFx.volume = 0.1f;
    }

    public void HoverButton()
    {
        myFx.PlayOneShot(hoverFx);
    }

    public void PressedButton()
    {
        myFx.PlayOneShot(clickFx);
    }
}
