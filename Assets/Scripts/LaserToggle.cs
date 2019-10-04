using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserToggle : MonoBehaviour
{
    private LineRenderer lr;
    private AudioSource laserAudio;

    private bool laserOn;

    public RobotController robotController;

    public Material matLaserOn,
                    matLaserOff;

    public bool enable;

    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        laserAudio = GetComponent<AudioSource>();

        enable = false;
        lr.enabled = false;
        lr.material = matLaserOff;
        laserOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(enable)
        {
            if(Input.GetKeyDown("joystick button 3"))
            {
                if(!lr.enabled)
                {
                    robotController.activate(true);
                    lr.enabled = true;
                }
                else
                {
                    robotController.activate(false);
                    lr.enabled = false;
                }
            }

            if(lr.enabled)
            {
                if (Input.GetKeyDown("joystick button 0"))
                    if (laserOn)
                    {
                        lr.material = matLaserOff;
                        robotController.changeSpeed();
                        laserOn = false;
                    }
                    else
                    {
                        lr.material = matLaserOn;
                        robotController.changeSpeed(0.1f, 0.1f, 0.1f);
                        laserOn = true;
                    }

                if (laserOn && !laserAudio.isPlaying)
                    laserAudio.Play();
                else if (!laserOn)
                    laserAudio.Stop();
            }
        }
    }

    public bool isLaserOn()
    {
        return laserOn;
    }
}