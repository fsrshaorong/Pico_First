using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IDragHandler
{
    private RectTransform rt;

    // Start is called before the first frame update
    void Start()
    {
        rt = GetComponent<RectTransform>();
    }

    public void OnDrag(PointerEventData eventData)
    {

        Vector3 pos;

        if (RectTransformUtility.ScreenPointToWorldPointInRectangle
        (rt, eventData.position, eventData.pressEventCamera, out pos))
        {
            rt.position = pos;
        }

    }
}
