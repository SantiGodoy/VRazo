using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Template : MonoBehaviour
{
    public GameObject start;
    public GameObject[] paths;
    public GameObject target;
    public GameObject burnMarkPrefab;

    public Material activeTarget;
    public Material inactiveTarget;
    public Material activePath;
    public Material inactivePath;
    
    private ArrayList marks;

    // Start is called before the first frame update
    void Start()
    {
        marks = new ArrayList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startActivated()
    {
        for (int i = 0; i < paths.Length; ++i)
            paths[i].GetComponent<Renderer>().material = activePath;
        target.GetComponent<Renderer>().material = activeTarget;
    }

    public void pathFailed()
    {
        for (int i = 0; i < paths.Length; ++i)
            paths[i].GetComponent<Renderer>().material = inactivePath;
        target.GetComponent<Renderer>().material = inactiveTarget;
    }

    public void burn(Vector3 position)
    {
        marks.Add(Instantiate(burnMarkPrefab, position, Quaternion.identity * Quaternion.Euler(0, -10, 90)));
    }

    public void deleteMarks()
    {
        for(int j = 0; j < marks.Count; ++j)
            Destroy(marks[j] as Object);

        marks.Clear();
    }
}
