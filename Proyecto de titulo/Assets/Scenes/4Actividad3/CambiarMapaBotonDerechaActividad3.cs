using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CambiarMapaBotonDerechaActividad3 : MonoBehaviour
{
    public Image UIImage;
    public Boton_listo_actividad3 Objeto = new Boton_listo_actividad3();
    public bool variable;
    public GameObject GameObject_parte2;
    public GameObject GameObject_chatarra_parte2;
    public GameObject profesora;
    public Sprite imagenACambiar;
    public GameObject circulo_verde;
    // Start is called before the first frame update
    void Start()
    {
        UIImage = GameObject.Find("Canvas").GetComponent<Image>();
        Debug.Log("entro aca");
        variable = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CambiarSpriteMapa(){
        Debug.Log("entra a la funcion del boton");
       if (Objeto.var == true)
        {
            UIImage.sprite = imagenACambiar;

            variable = true;
            GameObject_parte2.SetActive(true);
            GameObject_chatarra_parte2.SetActive(true);
            circulo_verde.SetActive(false);

        }
        if (Objeto.final ==true){
            profesora.SetActive(true);
        }

    }
}
