using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lapiz : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 a = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x+10, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
        gameObject.GetComponent<Transform>().position = a;
        //Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        //Debug.Log("aa: " + gameObject.GetComponent<Transform>().position);
    }
}
