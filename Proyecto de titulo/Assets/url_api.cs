using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class url_api : MonoBehaviour
{
    // Start is called before the first frame update
    public static string url;
    public static int periodo;
    void Start()
    {
        url = "https://7tv5uzrpoj.execute-api.sa-east-1.amazonaws.com/prod/api";
        //url = "http://localhost:3002/api";
        periodo = 202102;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
