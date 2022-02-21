using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class asignar_nombre_mapa : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Text>().text = Login.usernames+"";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
