using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class movimiento_Actividad2 : MonoBehaviour, IDragHandler
{
    public bool booleano;


    void Start()
    {
        booleano = true;
    }
    void Update()
    {

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
        if (a.gameObject.tag == "CuadroNoReciclable" && gameObject.tag == "basuraNoReciclable")
        {
            booleano = false;
        }
        if (a.gameObject.tag == "CuadroVidrio" && gameObject.tag == "BasuraVidrio")
        {
            booleano = false;
        }
        if (a.gameObject.tag == "CuadroPlastico" && gameObject.tag == "BasuraPlastico")
        {
            booleano = false;
        }

    }


}
