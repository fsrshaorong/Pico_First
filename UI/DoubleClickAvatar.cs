using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DoubleClickAvatar : MonoBehaviour, IPointerDownHandler
{
    float lastClick = 0;
    int clickCount = 1;

    const float DOUBLE_CLICK_THRESHOLD = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        lastClick = Time.time;
        clickCount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(Time.time - lastClick < DOUBLE_CLICK_THRESHOLD)
        {
            clickCount++;
        }
        else
        {
            clickCount = 1;
            lastClick = Time.time;
        }

        if(clickCount == 2)
        {

        }
    }
}
