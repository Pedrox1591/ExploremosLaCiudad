using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boton_listo_Activida2 : MonoBehaviour
{
    public DondeDejarBasuraNoReciclable Objeto = new DondeDejarBasuraNoReciclable();
    public DondeDejarBasuraPlastico Objeto1 = new DondeDejarBasuraPlastico();
    public DondeDejarBasuraVidrios Objeto2 = new DondeDejarBasuraVidrios();
    public GameObject Objeto3;
    //public GameObject circulo_verde;
    public bool final;


    public bool var;
    // Start is called before the first frame update
    void Start()
    {
        final = false;
        var = false;
        Objeto3.SetActive(false);
        //circulo_verde.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void boton_todo_listo()
    {
        if (var == false)
        {
            if (Objeto.variable1 == 5 && Objeto1.variable1 == 5 && Objeto2.variable1 == 5)
            {
                Debug.Log("Se cumplio el condicional");
                var = true;
                Objeto3.SetActive(false);
                //circulo_verde.SetActive(true);
                GetComponent<Cambiar_mapa_Boton_derecha_actividad2>().CambiarSpriteMapa();
            }
            else
            {
                Objeto3.SetActive(true);
            }
        }
        if (var == true)
        {
            if (Objeto.variable1 == 10 && Objeto1.variable1 == 10 && Objeto2.variable1 == 10)
            {
                Debug.Log("Se cumplio el condicional");
                var = true;
                Objeto3.SetActive(false);
                //circulo_verde.SetActive(false);
                final = true;
                GetComponent<Cambiar_mapa_Boton_derecha_actividad2>().CambiarSpriteMapa();
            }
            else
            {
                Objeto3.SetActive(true);
            }
        }


    }
}
