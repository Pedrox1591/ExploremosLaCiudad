using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mochila_act2 : MonoBehaviour
{
    public static bool var_act2 = false;
    public static bool var2_act2 = false;
    int contador;
    public GameObject Profesora;
    public GameObject cuadro_a_mover_1;
    public GameObject cuadro_a_mover_2;
    public Button btn_informacion;
    // Start is called before the first frame update
    void Start()
    {
        contador = 0;
        var2_act2 = false;
        Debug.Log("si entra al start de la mochila mi pana");
        //cuadrado_a_borrar.SetActive(false);
        for (int x = 0; x < cuadro_a_mover_1.transform.GetChild(2).transform.childCount; x++)
        {
            cuadro_a_mover_1.transform.GetChild(2).transform.GetChild(x).GetComponent<movimiento>().booleano = true;
            Debug.Log("obj de nombre: "+cuadro_a_mover_1.transform.GetChild(2).transform.GetChild(x).name);
        }
        for (int x = 0; x < cuadro_a_mover_2.transform.GetChild(2).transform.childCount; x++)
        {
            cuadro_a_mover_2.transform.GetChild(2).transform.GetChild(x).GetComponent<movimiento>().booleano = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D a)
    {
        Debug.Log("Entro al colidder por lo menos");
        if (contador == 4)
        {
            var2_act2 = true;
            Profesora.SetActive(true);
            GameObject.Find("tiempoxactividad").GetComponent<TiempoxActividad>().UpdateTxA();
            GetComponent<AudioSource>().mute = true;
            btn_informacion.interactable = false;
        }
        if (a.gameObject.tag == "BasuraPlastico")
        {
            contador = contador + 1;
            Debug.Log("entro a la mochila");

        }
        else if (a.gameObject.tag == "BasuraVidrio")
        {
            contador = contador + 1;
        }
    }
}
