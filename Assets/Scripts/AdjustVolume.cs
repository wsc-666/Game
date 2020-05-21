﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AdjustVolume : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioMixer adMixer;

    public void turnVolume()
    {
        adMixer.SetFloat("MasterVolume", volumeSlider.value);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
