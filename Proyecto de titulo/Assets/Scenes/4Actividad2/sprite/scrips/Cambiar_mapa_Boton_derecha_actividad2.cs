using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cambiar_mapa_Boton_derecha_actividad2 : MonoBehaviour
{
    public Image UIImage;
    public Boton_listo_Activida2 Objeto = new Boton_listo_Activida2();
    public bool variable;
    public GameObject GameObjecBasuraNoReciclableParte2;
    public GameObject GameObjecBasuraReciclableVidrioParte2;
    public GameObject GameObjecBasuraReciclablePlasticoParte2;
    public GameObject Mochila_Act2;

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
    public void CambiarSpriteMapa()
    {
        Debug.Log(Objeto.var+" es igual a true");
        if (Objeto.var == true)
        {
            
            UIImage.sprite = imagenACambiar;

            variable = true;
            GameObjecBasuraNoReciclableParte2.SetActive(true);
            GameObjecBasuraReciclableVidrioParte2.SetActive(true);
            GameObjecBasuraReciclablePlasticoParte2.SetActive(true);
            circulo_verde.SetActive(false);
        }
        if (Objeto.final ==true){
            Mochila_Act2.SetActive(true);
            mochila_act2.var_act2 = true;
        }
    }
}
