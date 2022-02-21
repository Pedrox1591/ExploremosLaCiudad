using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DetectarObjetoClickeado : MonoBehaviour, IPointerClickHandler
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPointerClick(PointerEventData data)
    {
        Debug.Log("tocaste: " +gameObject.name);
        if(gameObject.tag == "Objeto_para_escultura")
        {
            
            
            
            /*GameObject.Find("Slider_rotacion").GetComponent<Slider>().value = gameObject.transform.localRotation.z;
            GameObject.Find("RED").GetComponent<Slider>().value = gameObject.GetComponent<Image>().color.r;
            Debug.Log(gameObject.GetComponent<Image>().color.r+ "  "+ GameObject.Find("RED").GetComponent<Slider>().value);
            GameObject.Find("GREEN").GetComponent<Slider>().value = gameObject.GetComponent<Image>().color.g;

            GameObject.Find("BLUE").GetComponent<Slider>().value = gameObject.GetComponent<Image>().color.b;
            GameObject.Find("Tamaño_de_objeto").GetComponent<Slider>().value = gameObject.transform.localScale.x / 7;*/
            barra_colores.objeto_seleccionado = gameObject.GetComponent<Image>();

        }
        if (gameObject.tag == "Boceto")
        {
            GameObject.Find("Imagen_tomada").GetComponent<Image>().sprite = gameObject.GetComponent<Image>().sprite;
            GameObject.Find("script_detectar_escultura").GetComponent<Script_detectar_esculturas>().funcheckList_boceto();
        }


    }

}
