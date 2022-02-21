using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using System;

public class comida_en_mapa : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cuadro_comida;
    public Text texto;
    //inventario_reim objeto = new inventario_reim();
    //public GameObject image;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if(script_comer_si.comer_bool == true && script_comer_si.obj_seleccionado.GetComponent == gameObject.GetComponent<prueba>().idElemento)
        {
            script_comer_si.comer_bool = false;
            Debug.Log("Esta entrando donde no deveria entrar bolu");
            gameObject.GetComponent<prueba>().comer();
            GameObject.Find("script_inventario_reim").GetComponent<inventario_reim>().get_comida_agua();
            
        }*/
    }
    public void OnClik()
    {
        //Output to console the clicked GameObject's name and the following message. You can replace this with your own actions for when clicking the GameObject.
        //Debug.Log(name + " Game Object Clicked!");
        cuadro_comida.SetActive(true);
        cuadro_comida.transform.localScale = new Vector3(1,1,1);
        GameObject.Find("Canvas/NuevaMochilaCarril/Comer_comida/imagen_fruta").GetComponent<Image>().sprite = gameObject.GetComponent<Image>().sprite;
        script_comer_si.obj_seleccionado = gameObject;
        Debug.Log("El obj seleccionado es: " + script_comer_si.obj_seleccionado);


    }
}
