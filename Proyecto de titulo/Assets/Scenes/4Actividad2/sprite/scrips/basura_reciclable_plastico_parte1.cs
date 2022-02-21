using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class basura_reciclable_plastico_parte1 : MonoBehaviour
{
    public GameObject fruta1;
    public GameObject fruta2;
    public GameObject fruta3;
    public GameObject fruta4;
    public GameObject fruta5;

    public GameObject posicion1;
    public GameObject posicion2;
    public GameObject posicion3;
    public GameObject posicion4;
    public GameObject posicion5;

    // Start is called before the first frame update
    void Start()
    {
        List<GameObject> listafrutas = new List<GameObject>(){fruta1,fruta2,fruta3,fruta4,fruta5
        };
        List<GameObject> lista_de_sprites = new List<GameObject>(){posicion1,posicion2,posicion3,posicion4,posicion5
        };
        

        for (int x = lista_de_sprites.Count-1; x >= 0; x--)
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
