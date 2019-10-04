using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour
{
    public Template[] templates;
    public GameObject showing;
    public GameObject hiding;

    private LineRenderer lineRenderer;
    private LaserToggle laserToggle;

    private bool wellDone;
    private int i;

    // Use this for initialization
    void Start()
    {
        laserToggle = GetComponent<LaserToggle>();
        lineRenderer = GetComponent<LineRenderer>();
        i = 0;
        wellDone = false;
        templates[0].transform.position = showing.transform.position;
        for (int j = 1; j < templates.Length; ++j)
            templates[j].transform.position = hiding.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPosition(0, transform.position);
        if(Physics.Raycast(transform.position, transform.forward, out RaycastHit hit))
        {
            if(hit.collider)
            {
                lineRenderer.SetPosition(1, hit.point);
            }

            if(laserToggle.isLaserOn())
            {
                if(hit.collider.CompareTag("Start"))
                {
                    templates[i].startActivated();
                    wellDone = true;
                }
                else if(hit.collider.CompareTag("Target") && wellDone)
                {
                    wellDone = false;
                    templates[i].deleteMarks();
                    templates[i].transform.position = hiding.transform.position;
                    if (++i < templates.Length)
                        templates[i].transform.position = showing.transform.position;
                }
                else if(hit.collider.CompareTag("Template"))
                {
                    wellDone = false;
                    templates[i].pathFailed();
                    templates[i].burn(hit.point);
                }
            }
            else if(wellDone)
            {
                wellDone = false;
                templates[i].pathFailed();
            }
        }
        else
            lineRenderer.SetPosition(1, transform.forward * 5000);
    }
}