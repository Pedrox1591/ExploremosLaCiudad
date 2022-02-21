using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cerrar_Abrir_Ventana : MonoBehaviour
{
    // Start is called before the first frame update
    public bool apretado;
    void Start()
    {
        apretado = false;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClick()
    {
        if (apretado == false)
        {
            GetComponent<Animator>().Play("a");
            //GameObject.Find("Basura_para_la_escultura").GetComponent<Animator>().Play("c");
            apretado = true;

        }
        else if(apretado == true)
        {
            GetComponent<Animator>().Play("b");
            apretado = false;
        }
        

    }
}
