using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LiveCameraController : MonoBehaviour
{
    Camera cam;
    private IMouseBaseEvent current;
    private IMouseBaseEvent currentDrag;
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.GetComponent<IMouseBaseEvent>() != null)
            {
                if (current == null)
                {
                    current = hit.transform.GetComponent<IMouseBaseEvent>();
                    current.OnMouseEnter();
                    //current.OnMouseHover(true);
                }
                else
                {
                    if (hit.transform.GetComponent<IMouseBaseEvent>() != current)
                    {
                        current.OnMouseExit();
                        current = hit.transform.GetComponent<IMouseBaseEvent>();
                        current.OnMouseEnter();
                        //current.OnMouseHover(true);
                    }
                    else
                    {
                        current.OnMouseOver();
                    }
                }
            }
            else
            {
                if (current != null)
                {
                    current.OnMouseExit();
                    current = null;
                }
            }
        }
        else
        {
            if (current != null)
            {
                current.OnMouseExit();
                current = null;
            }
        }
        if (currentDrag != null)
        {
            currentDrag.OnDrag();
        }
    }

    public void MouseDown()
    {
        currentDrag = current;
        if (current != null)
        {
            current.OnMouseDown();
        }
    }

    public void MouseUp()
    {
        currentDrag = null;
        if (current != null)
        {
            current.OnMouseUp();
        }
    }
}
