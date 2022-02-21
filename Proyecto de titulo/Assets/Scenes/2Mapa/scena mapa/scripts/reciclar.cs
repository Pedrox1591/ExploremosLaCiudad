using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reciclar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(gameObject.name == "reciclaje_vidrio" && collision.tag == "BasuraVidrio")
        {
            Debug.Log("Cuadrado correcto");
        }
        else
        {
            //Debug.Log("Cuadrado incorrecto");
        }
        if (gameObject.name == "reciclaje_papel"&& collision.tag == "Basura")
        {

        }
        else
        {
            //Debug.Log("Cuadrado incorrecto");
        }
        if (gameObject.name == "reciclaje_plastico"&& collision.tag == "BasuraPlastico")
        {
            Debug.Log("Cuadrado correcto");
        }
        else
        {
            //Debug.Log("Cuadrado incorrecto");
        }
    }
}
