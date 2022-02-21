using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DondeDejarObjetosQuePertenecen : MonoBehaviour
{
    public Transform cuadrado;
    public Transform cuadrado1;
    public Transform cuadrado2;
    public Transform cuadrado3;
    public Transform cuadrado4;
    public Transform cuadrado5;
    public Transform cuadrado6;
    public Transform cuadrado7;
    public Transform cuadrado8;
    public Transform cuadrado9;
    public Transform cuadrado10;
    public Transform cuadrado11;

    public int variable1;

    public List<Transform> listaDeCuadrados = new List<Transform>();
    public int var = 0;



    // Start is called before the first frame update
    void Start()
    {
        listaDeCuadrados.Add(cuadrado);listaDeCuadrados.Add(cuadrado1); listaDeCuadrados.Add(cuadrado2); listaDeCuadrados.Add(cuadrado3); listaDeCuadrados.Add(cuadrado4);
        listaDeCuadrados.Add(cuadrado5); listaDeCuadrados.Add(cuadrado6); listaDeCuadrados.Add(cuadrado7); listaDeCuadrados.Add(cuadrado8); listaDeCuadrados.Add(cuadrado9);
        listaDeCuadrados.Add(cuadrado10); listaDeCuadrados.Add(cuadrado11);
        variable1 = 0;
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    void OnTriggerEnter2D(Collider2D a)
    {
        //Debug.Log("Se estan tocando las cosas " + a.gameObject.name + " " + cuadrado1.position);
  
        if(a.gameObject.tag == "ObjetoEstacionDeBomberos")
        {
            
                a.transform.position = listaDeCuadrados[0].position;
                listaDeCuadrados.RemoveAt(0);
                variable1 = variable1 + 1;




        }


    }

        
    
}
