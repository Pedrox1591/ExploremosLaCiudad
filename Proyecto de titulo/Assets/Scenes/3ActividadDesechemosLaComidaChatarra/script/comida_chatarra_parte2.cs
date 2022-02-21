using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class comida_chatarra_parte2 : MonoBehaviour
{
    public GameObject fruta1;
    public GameObject fruta2;
    public GameObject fruta3;
    public GameObject fruta4;
    public GameObject fruta5;
    public GameObject fruta6;
    public GameObject fruta7;
    public GameObject fruta8;
    

    public GameObject posicion1;
    public GameObject posicion2;
    public GameObject posicion3;
    public GameObject posicion4;
    public GameObject posicion5;
    public GameObject posicion6;
    public GameObject posicion7;
    public GameObject posicion8;

    public GameObject GameObject_parte2;
    public CambipMapaBotonDerecha Objeto = new CambipMapaBotonDerecha();



    // Start is called before the first frame update
    void Start()
    {
        if (Objeto.variable == false)
        {
            GameObject_parte2.SetActive(false);
        }
         List<GameObject> listafrutas = new List<GameObject>(){fruta1,fruta2,fruta3,fruta4,fruta5,fruta6,fruta7,fruta8
        };
        List<GameObject> lista_de_sprites = new List<GameObject>(){posicion1,posicion2,posicion3,posicion4,posicion5,posicion6,posicion7,posicion8
        };
        

        for (int x = 7; x >= 0; x--)
        {
            int randomNum = Random.Range(0, lista_de_sprites.Count);
            //Debug.Log("a la fruta: "+(listafrutas[x]).ToString()+" se le va a agregar la imagen: "+ (lista_de_sprites[randomNum]).ToString() );
            listafrutas[x].transform.position = lista_de_sprites[randomNum].transform.position;
            lista_de_sprites[randomNum].SetActive(false);
            lista_de_sprites.RemoveAt(randomNum);
        }

    }

    // Update is called once per frame
    void Update()
    {





    }

}
