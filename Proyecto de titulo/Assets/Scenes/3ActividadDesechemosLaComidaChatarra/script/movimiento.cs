using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using System;



public class movimiento : MonoBehaviour, IDragHandler
{
    public bool booleano;
    public string TAGCuadrado1;
    public string TAGCuadrado2;
    public string TAGCuadrado3;
    

    public string TAGObjetos1;

    public string TAGObjetos2;
    public string TAGObjetos3;
    public int variable_muy_variable;
    public string resultado_movimiento;


    void Start()
    {
        Mochila.var = false;
        Mochila.var2 = false;
        mochila_act2.var2_act2 = false;
        mochila_act2.var_act2 = false;
        variable_muy_variable =0;
        booleano = true;
        resultado_movimiento = "No aplica";
        

    }
    void Update()
    {
        int y = SceneManager.GetActiveScene().buildIndex;
        if (y == 4) {
            /*if (Mochila.var == true) {
                booleano = true;
            }*/
            if (Mochila.var2 == true) {
                booleano = false;
            }
        }
       
        if (y == 6)
        {
            /*if (mochila_act2.var_act2 == true)
            {
                booleano = true;
            }*/
            if (mochila_act2.var2_act2 == true)
            {
                booleano = false;
            }
        }

        
    }
    public void OnDrag(PointerEventData data)
    {

        
        if (booleano)
        {
            transform.position = data.position;

        }
    

    }
    
    void OnTriggerEnter2D(Collider2D a)
    {
        Debug.Log("Entro al tigger");
        if (a.gameObject.tag == TAGCuadrado1 && gameObject.tag == TAGObjetos1)
        {
            booleano = false;
            variable_muy_variable=1;
            resultado_movimiento = "Correcto";
            GameObject.Find("UlearnCoins").GetComponent<UlearnCoins>().Ganar_UlearnCoins(5);

        }
        else if((a.gameObject.tag == TAGCuadrado2 && gameObject.tag == TAGObjetos1) || (a.gameObject.tag == TAGCuadrado3 && gameObject.tag == TAGObjetos1)){
            variable_muy_variable=0;
            resultado_movimiento = "Incorrecto";
        }
        if (a.gameObject.tag == TAGCuadrado2 && gameObject.tag == TAGObjetos2)
        {
            booleano = false;
             variable_muy_variable=1;
            resultado_movimiento = "Correcto";
            GameObject.Find("UlearnCoins").GetComponent<UlearnCoins>().Ganar_UlearnCoins(5);

        }
        else if(a.gameObject.tag == TAGCuadrado1 && gameObject.tag == TAGObjetos2 || (a.gameObject.tag == TAGCuadrado3 && gameObject.tag == TAGObjetos2)){
            variable_muy_variable=0;
            resultado_movimiento = "Incorrecto";
        }
        if (a.gameObject.tag == TAGCuadrado3 && gameObject.tag == TAGObjetos3)
        {
            booleano = false;
             variable_muy_variable=1;
            resultado_movimiento = "Correcto";
            GameObject.Find("UlearnCoins").GetComponent<UlearnCoins>().Ganar_UlearnCoins(5);

        }
        else if(a.gameObject.tag == TAGCuadrado1 && gameObject.tag == TAGObjetos3 || (a.gameObject.tag == TAGCuadrado2 && gameObject.tag == TAGObjetos3)){
            variable_muy_variable=0;
            resultado_movimiento = "Incorrecto";
        }
        if(a.gameObject.tag =="CuadradoMochila"){
            variable_muy_variable = 1;
            resultado_movimiento = "Guardado en la mochila";
        }

        
        
    }
    



}
