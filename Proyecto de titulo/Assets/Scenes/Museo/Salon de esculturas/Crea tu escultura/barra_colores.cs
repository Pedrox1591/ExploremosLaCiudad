using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class barra_colores : MonoBehaviour
{
    // Start is called before the first frame update
    public static Image objeto_seleccionado = null;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCickK()

    {
        if (objeto_seleccionado != null)
        {
            Debug.Log("Entro a la funcion que hace que suceda la magia");
            Color nuevo_color = objeto_seleccionado.material.color;
            nuevo_color.r = (int)(GameObject.Find("RED").GetComponent<Slider>().value);
            nuevo_color.g = (int)(GameObject.Find("GREEN").GetComponent<Slider>().value);
            nuevo_color.b = (int)(GameObject.Find("BLUE").GetComponent<Slider>().value);
            //objeto_seleccionado. .color = new Color(), (int)GameObject.Find("GREEN").GetComponent<Slider>().value, (int)GameObject.Find("BLUE").GetComponent<Slider>().value);
            //Debug.Log(GameObject.Find("RED").GetComponent<Slider>().value + " " + GameObject.Find("GREEN").GetComponent<Slider>().value + " " + GameObject.Find("BLUE").GetComponent<Slider>().value);
            objeto_seleccionado.color = new Color32((byte)nuevo_color.r, (byte)nuevo_color.g, (byte)nuevo_color.b, 255);
            objeto_seleccionado.transform.localScale = new Vector3(7 * GameObject.Find("Tamaño_de_objeto").GetComponent<Slider>().value, 7 * GameObject.Find("Tamaño_de_objeto").GetComponent<Slider>().value, 1);
            objeto_seleccionado.transform.localRotation = Quaternion.Euler(0, 0, GameObject.Find("Slider_rotacion").GetComponent<Slider>().value);
            //Debug.Log("byte"+(byte)10);

        }
    }
}
