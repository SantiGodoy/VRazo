using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderMovement : MonoBehaviour
{
    float minValue = 0, maxValue = 1;
    public Slider sliderRef;
    public GameObject mainMenu;

    void Start()
    {
        sliderRef.minValue = minValue;
        sliderRef.maxValue = maxValue;
    }

    void Update()
    {
        if(Input.GetKeyDown("joystick button 3"))
        {
            this.gameObject.SetActive(false);
            mainMenu.SetActive(true);
        }

        float x = Input.GetAxis("LeftJoystickHorizontal");
        if (Mathf.Abs(x) < 0.2)
            return;
        sliderRef.value += x*0.01f;
    }
}
