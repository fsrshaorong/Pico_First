using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchContent : MonoBehaviour
{
    public GameObject current;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchTo(GameObject target)
    {
        current.SetActive(false);
        target.SetActive(true);
        current = target;
    }
}
