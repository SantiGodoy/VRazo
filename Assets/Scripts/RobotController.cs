using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotController : MonoBehaviour {

    //Inicializar la posición de la base y del brazo superior
    public Transform RobotBase;
    public Transform RobotUpperArm;
    public Transform RobotLowerArm;

    //Velocidad de los movimientos
    public float xSpeed = 0.5f;
    public float ySpeed = 0.5f;
    public float zSpeed = 0.5f;

    public bool leftJoystick = true;
    public bool rightJoystick = true;

    private float totalBaseRotation = 0;
    private float totalLowerArmRotation = 0;
    private float totalUpperArmRotation = 0;

    public bool enable;

    private void Start()
    {
        enable = false;
    }

    void Update() {
        if(enable)
        {
            float lowerArmRotation;

            if (Input.GetKey("joystick button 1")) {
                lowerArmRotation = 1 * ySpeed;
                totalLowerArmRotation += lowerArmRotation;
                if(totalLowerArmRotation > -20 && totalLowerArmRotation < 30)
                    RobotLowerArm.Rotate(lowerArmRotation, 0, 0);
                else
                    totalLowerArmRotation -= lowerArmRotation;
            }

            if(Input.GetKey("joystick button 2"))
            {
                lowerArmRotation = -1 * ySpeed;
                totalLowerArmRotation += lowerArmRotation;
                if (totalLowerArmRotation > -20 && totalLowerArmRotation < 30)
                    RobotLowerArm.Rotate(lowerArmRotation, 0, 0);
                else
                    totalLowerArmRotation -= lowerArmRotation;
            }
                

            //Cogemos el movimiento horizontal del joystick izquierdo del mando
            float yRotation = Input.GetAxis("LeftJoystickHorizontal");
            //Cogemos el movimiento frontal del joystick derecho del mando
            float xRotation = Input.GetAxis("LeftJoystickVertical");

            //Solucion para que el robot no se mueva solo debido a la calibracion del mando cuando no se mueve el joystick
            if(Mathf.Abs(xRotation) < 0.2 && Mathf.Abs(yRotation) < 0.2 && !Input.GetKey("joystick button 1") && !Input.GetKey("joystick button 2"))
            {
                //SoundManager.StopSound();
                return;
            }

            /*if(!SoundManager.isPlaying())
                SoundManager.PlaySound();*/
            float baseRotation = xRotation * xSpeed;
            totalBaseRotation += baseRotation;
            //Rota sobre el eje y la base del robot cogiendo como Input el movimiento horizontal del joystick izquierdo
            if(totalBaseRotation > -30 && totalBaseRotation < 30)
                RobotBase.Rotate(0, -baseRotation, 0);
            else
                totalBaseRotation -= baseRotation;

            float upperArmRotation = yRotation * ySpeed;
            totalUpperArmRotation += upperArmRotation;
            //Rota sobre el eje x el brazo superior del robot cogiendo como Input el movimiento vertical del joystick izquierdo
            if(totalUpperArmRotation > -30 && totalUpperArmRotation < 60)
                RobotUpperArm.Rotate(-upperArmRotation, 0, 0);
            else
                totalUpperArmRotation -= upperArmRotation;
        }
    }
    
    public void changeSpeed(float xS = 0.5f, float yS = 0.5f, float zS = 0.5f)
    {
        xSpeed = xS;
        ySpeed = yS;
        zSpeed = zS;
    }

    public void activate(bool act)
    {
        enable = act;
    }
}