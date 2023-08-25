using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractEventPanel : MonoBehaviour
{
    public GameObject leftScreen;
    public GameObject rightScreen;

    //[NonSerialized]
    public GameObject detailLeftScreen;
    public GameObject detailRightScreen;

    private SwitchContent left;
    private SwitchContent right;
    // Start is called before the first frame update
    void Start()
    {

        leftScreen = transform.parent.gameObject.GetComponent<SaveLayoutToJSON>().leftScreen;
        rightScreen = transform.parent.gameObject.GetComponent<SaveLayoutToJSON>().rightScreen;
        left = leftScreen.GetComponent<SwitchContent>();
        right = rightScreen.GetComponent<SwitchContent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnLeftDetailButtonClick()
    {
        left.SwitchTo(detailLeftScreen);
    }
}
