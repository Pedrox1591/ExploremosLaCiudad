using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mochila_mapa : MonoBehaviour
{
    public GameObject mochila_por_dentro;

    // Start is called before the first frame update
    bool estado;
    void Start()
    {
        estado = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Onclick_mochila(){
       //mochila_por_dentro.SetActive(true);
       if(estado == false)
        {
            estado = true;
            mochila_por_dentro.GetComponent<Animation>().Play("abrir_mochila");
        }
       
    }
    public void Onclick_x(){
        //mochila_por_dentro.SetActive(false);
        if(estado == true)
        {
            estado = false;
            mochila_por_dentro.GetComponent<Animation>().Play("cerrar_mochila");
        }
        
    }
}
