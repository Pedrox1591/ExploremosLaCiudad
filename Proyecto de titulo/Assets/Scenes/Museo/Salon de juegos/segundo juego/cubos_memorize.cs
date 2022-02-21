using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class cubos_memorize : MonoBehaviour,IPointerClickHandler
{
    public Sprite imagenACambiar;
    public Sprite imagen_original;
    public Sprite imagen_error;
    public bool volver_a_original;
    public static int var;
    public bool error;

    //public static int punto_en_la_secuencia;
    void Start()
    {
        volver_a_original=false;
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if(volver_a_original == true){
            gameObject.GetComponent<Image>().sprite = imagen_original;
            //volver_a_original = false;
            error = false;


        }*/


    }
    public void OnPointerClick(PointerEventData a){
        if(memorize_test_secuencial.nivel_en_juego ==true){
            var =0;

            //Debug.Log("memorize_test.secuencia.Remove("+gameObject.name+")");
            
            if(memorize_test_secuencial.secuencia_memorize_copia[0]==gameObject){
                var=1;
                gameObject.GetComponent<Image>().sprite = imagenACambiar;
                memorize_test_secuencial.secuencia_memorize_copia.Remove(gameObject);
                Debug.Log("se elimino de la lista"+gameObject.name);
                GameObject.Find("UlearnCoins").GetComponent<UlearnCoins>().Ganar_UlearnCoins(5);
            }

            else{
                if(error == false)
                {
                    error = true;
                    Debug.Log("Entro al else");
                    gameObject.GetComponent<Image>().sprite = imagen_error;
                    memorize_test_secuencial.vidas = memorize_test_secuencial.vidas - 1;
                }
                
            }
            var=0;
        //memorize_test.secuencia.Remove(GameObject.name);
        }
    }
}
