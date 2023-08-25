using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IMouseBaseEvent
{
    void OnMouseEnter();
    void OnMouseExit();
    void OnMouseDown();
    void OnMouseUp();
    void OnMouseOver();
    void OnDrag();
}
