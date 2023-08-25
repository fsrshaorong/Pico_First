using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventCameraSwitch : MonoBehaviour, IPointerEnterHandler
{
    public Camera[] switchTarget;
    public Canvas[] screens;

    public void OnPointerEnter(PointerEventData eventData)
    {
        foreach (var screen in screens)
        {
            print("进入" + transform.name);
            screen.worldCamera = switchTarget[0];
        };
    }

    //    void Update()
    //    {
    //        Vector3 relMouse = Display.RelativeMouseAt(Input.mousePosition);
    //        print("鼠标位置：" + Input.mousePosition);

    ////#if UNITY_EDITOR
    ////        var mousePosInScreenCoords = Input.mousePosition;
    ////#else
    ////        // Convert the global mouse position into a relative position for the current display 
    ////        var mousePosInScreenCoords = Display.RelativeMouseAt(Input.mousePosition);
    ////#endif

    //        foreach (var screen in screens)
    //        {
    //            //print("进入" + transform.name);
    //            screen.worldCamera = switchTarget[(int)relMouse.z];
    //        };
    //    }
}
