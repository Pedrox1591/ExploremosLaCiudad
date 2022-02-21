using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mochila : MonoBehaviour
{
    public static bool var = false;
    public static bool var2 = false;
    int contador;
    public GameObject Profesora;
    public GameObject cuadro_a_mover;
    public Button btn_informacion;
    // Start is called before the first frame update
    void Start()
    {
        contador =0;
        var2 = false;
        //cuadrado_a_borrar.SetActive(false);
        for(int x = 0;x< cuadro_a_mover.transform.GetChild(2).transform.childCount; x++)
        {
            cuadro_a_mover.transform.GetChild(2).transform.GetChild(x).GetComponent<movimiento>().booleano = true;
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void OnTriggerEnter2D(Collider2D a){
         Debug.Log("Entro al colidder por lo menos");
         if (contador==4){
             var2=true;
             Profesora.SetActive(true);
            GetComponent<AudioSource>().mute = true;
            btn_informacion.interactable = false;
            GameObject.Find("tiempoxactividad").GetComponent<TiempoxActividad>().UpdateTxA();
         }
         if(a.gameObject.tag =="Fruta" || a.gameObject.tag == "BasuraPlastico" || a.gameObject.tag == "BasuraVidrio")
        {
             contador = contador+1;
             Debug.Log("entro a la mochila");
            
         }
         else if(a.gameObject.tag =="ComidaChatarra" || a.gameObject.tag =="basuraNoReciclable"){
            //contador = contador+1; No puede hechar comida chatarra
            //StartCoroutine(reproducir_sonido_error());
             
         }
     }
}
