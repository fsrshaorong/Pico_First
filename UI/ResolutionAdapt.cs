using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionAdapt : MonoBehaviour
{
    public Vector2 rawOffset;

    private float baseUnit = 1920;
    RectTransform rectTransform;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height * 2);
        rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.width * 2);
        rectTransform.SetPositionAndRotation(new Vector3(rawOffset.x / baseUnit * Screen.width, rawOffset.y / baseUnit * Screen.height, 0), new Quaternion());
    }
}
