using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    public GameObject tutorialInfo;
    [TextArea]
    public string[] messages = new string[10];
    GameObject canvas;
    TextMeshProUGUI t;
    int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        tutorialInfo.SetActive(true);
        canvas = tutorialInfo;
        tutorialShowNext();
        canvas.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void tutorialShowNext()
    {
		if (i < messages.Length) {
			t = GameObject.Find ("Tutorial").GetComponent<TextMeshProUGUI> ();
			t.text = messages [i];
			++i;
		} else
			canvas.SetActive (false);
    }
}
