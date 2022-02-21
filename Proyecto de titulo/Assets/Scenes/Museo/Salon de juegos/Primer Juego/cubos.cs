using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class cubos : MonoBehaviour,IPointerClickHandler
{
    // Start is called before the first frame update
    public Sprite imagenACambiar;
    public Sprite imagen_original;
    public Sprite imagen_error;
    public static bool volver_a_original;
    public static int var;
    public bool error;
    void Start()
    {
        volver_a_original=false;
        error = false;
    }

    // Update is called once per frame
    void Update()
    {
        /*if(volver_a_original == true){
            gameObject.GetComponent<Image>().sprite = imagen_original;
            error = false;
        }*/


    }
    public void OnPointerClick(PointerEventData a){
        if (memorize_test.nivel_en_juego == true && memorize_test.nivel_completado_bool == false)
        {
            var =0;

            //Debug.Log("memorize_test.secuencia.Remove("+gameObject.name+")");
            for(int x =0;x<memorize_test.secuencia.Count;x++){
                if(memorize_test.secuencia[x]==gameObject){
                    var=1;
                }
            }
            if(var==1){
                memorize_test.secuencia.Remove(gameObject);
                Debug.Log("se elimino de la lista"+gameObject.name);
                gameObject.GetComponent<Image>().sprite = imagenACambiar;
                GameObject.Find("UlearnCoins").GetComponent<UlearnCoins>().Ganar_UlearnCoins(5); 
            }
            else{
                if(error == false)
                {
                    error = true;
                    Debug.Log("Entro al else");
                    gameObject.GetComponent<Image>().sprite = imagen_error;
                    memorize_test.vidas = memorize_test.vidas - 1;
                }
                
            }
        //memorize_test.secuencia.Remove(GameObject.name);
        }
    }
}
