using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderVolume : MonoBehaviour
{
    // VARIABLES
    public Slider sliderVolume;
    private float valor;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        valor = sliderVolume.value;
        AudioListener.volume = valor;
    }
}
