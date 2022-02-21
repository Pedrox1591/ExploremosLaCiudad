using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class CambipMapaBotonDerecha : MonoBehaviour
{
    public Image UIImage;
    public Boton_listo Objeto;
    public bool variable;
    public GameObject GameObject_parte2;
    public GameObject GameObject_chatarra_parte2;

    public Sprite imagenACambiar;
    public Sprite imagenACambiar2;
    public GameObject circulo_verde;
    public GameObject Mochilaa;
    public static bool variable_mapa1_mapa2_mapa3;
    public GameObject GameTexto;

    public GameObject PrimerBox;

    public GameObject SegundoBox;

    
    // Start is called before the first frame update
    void Start()
    {
        UIImage = GameObject.Find("Canvas").GetComponent<Image>();
        Debug.Log("entro aca");
        variable = false;
        variable_mapa1_mapa2_mapa3 =false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CambiarSpriteMapa(){
        Debug.Log("entra a la funcion del boton objeto.var = "+Objeto.var);
        
       if (Objeto.var == true)
        {
            Debug.Log("variable_mapa1_mapa2_mapa3: "+variable_mapa1_mapa2_mapa3+" "+Boton_listo.var2);
            if(variable_mapa1_mapa2_mapa3 ==false){
            variable_mapa1_mapa2_mapa3 =true;
            Objeto.var =false;
            UIImage.sprite = imagenACambiar;

            variable = true;
            GameObject_parte2.SetActive(true);
            GameObject_chatarra_parte2.SetActive(true);
            circulo_verde.SetActive(false);
            GameTexto.SetActive(false);
            }
            else if(variable_mapa1_mapa2_mapa3==true && Boton_listo.var2 == true){
            Objeto.var =false;
            UIImage.sprite = imagenACambiar2;

            variable = true;
            //GameObject_parte2.SetActive(true);
            //GameObject_chatarra_parte2.SetActive(true);
            circulo_verde.SetActive(false);
            Mochilaa.SetActive(true);
            GameTexto.SetActive(false);
            PrimerBox.SetActive(false);
            SegundoBox.SetActive(false);
            Mochila.var = true;
            }
            

        }

    }
}
