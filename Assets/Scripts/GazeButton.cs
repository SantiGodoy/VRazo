using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Button))]
public class GazeButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image progressImage; 
    public bool isEntered = false;
    RectTransform rt;
    Button _button;
    float timeElapsed;
    Image cursor;
    
    void Awake()
    {
        _button = GetComponent<Button>();
        rt = GetComponent<RectTransform>();
        progressImage.enabled = false;
    }

    float GazeActivationTime = 1.5f;

    void Update()
    {
        if (isEntered)
        {
            progressImage.enabled = true;
            timeElapsed += Time.deltaTime;
            progressImage.fillAmount = Mathf.Clamp(timeElapsed / GazeActivationTime, 0, 1);
            if (timeElapsed >= GazeActivationTime)
            {
                timeElapsed = 0;
                _button.onClick.Invoke();
                progressImage.fillAmount = 0;
                isEntered = false;
            }
        }
        else
        {
            progressImage.enabled = false;
            timeElapsed = 0;
        }
    }

    #region IPointerEnterHandler implementation

    public void OnPointerEnter(PointerEventData eventData)
    {
        isEntered = true;
    }

    #endregion

    #region IPointerExitHandler implementation

    public void OnPointerExit(PointerEventData eventData)
    {
        isEntered = false;
        progressImage.fillAmount = 0;
    }
    #endregion
}
