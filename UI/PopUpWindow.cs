using UnityEngine;
using UnityEngine.UI;

public class PopUpWindow : MonoBehaviour
{
    public Camera mainCamera;
    public Vector3 targetPos;
    public CanvasGroup canvas;
    public float distance=10f;



    void Start()
    {
        canvas.alpha = 0;

    }

    void Update()
    {
        if ((mainCamera.transform.position - targetPos).magnitude <= distance)
    
        {
            canvas.alpha = 1;
        }
        else
        {
            canvas.alpha = 0;

        }


    }
}
    


