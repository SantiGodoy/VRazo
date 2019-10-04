using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Walk : MonoBehaviour
{
    // This variable determinates if the player will move or not 
    private bool isWalking = false;
    private int i = 1;

    public GameObject menu;
    public RobotController robotController;
    public LaserToggle laserToggle;
    public GameObject tutorialManager;
    public GameObject selectSphere;

    public GameObject[] points;

    //This is the variable for the player speed
    [Tooltip("With this speed the player will move.")]
    public float speed;
    
    void Start()
    {

    }

    public void StartWalking()
    {
        isWalking = true;
    }

    void Update()
    {
        if (isWalking)
        {
            if (i < points.Length)
            {
                Vector3 heading = (points[i].transform.position - transform.position);

                if (heading.sqrMagnitude <= 0.1f)
                    ++i;

                Vector3 direction = heading / heading.magnitude * speed * Time.deltaTime;
                Quaternion rotation = Quaternion.Euler(new Vector3(0, -transform.rotation.eulerAngles.y, 0));
                transform.Translate(rotation * direction);
            }
            else
            {
                laserToggle.enable = true;
                tutorialManager.SetActive(true);
                selectSphere.SetActive(false);
                menu.SetActive(true);
                isWalking = false;
            }
        }
    }

}