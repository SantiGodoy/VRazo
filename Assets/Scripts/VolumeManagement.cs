using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class VolumeManagement : MonoBehaviour
{
    public Slider slider;

    private void Start()
    {
        AudioListener.volume = 0;
    }

    public void OnValueChanged()
    {
        AudioListener.volume = slider.value;
    }
}
