using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boton_listo : MonoBehaviour
{
    public DondeDejarComidaChatarra Objeto = new DondeDejarComidaChatarra();
    public DondeDejarComidaSaludable Objeto1 = new DondeDejarComidaSaludable();
    public GameObject Objeto3;
    public int numeroDeItems;
    public int numeroDeItemsSegundaActividad;
    //public GameObject circulo_verde;
    public static bool var2;

    public bool var;
    // Start is called before the first frame update
    void Start()
    {
        var2=false;
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
        if(CambipMapaBotonDerecha.variable_mapa1_mapa2_mapa3 == false){
            
            if (var == false)
        {
            if (Objeto.variable1 == numeroDeItems && Objeto1.variable1 == numeroDeItems)
            {
                Debug.Log("Se cumplio el condicional");
                var = true;
                Objeto3.SetActive(false);
                    //circulo_verde.SetActive(true);
                    GetComponent<CambipMapaBotonDerecha>().CambiarSpriteMapa();
            }
            else
            {
                Objeto3.SetActive(true);
            }
        }
        }

        else if(CambipMapaBotonDerecha.variable_mapa1_mapa2_mapa3 == true)
        {
            Debug.Log((Objeto.variable1+" == "+ numeroDeItemsSegundaActividad+numeroDeItems+" y "+ Objeto1.variable1+" == "+numeroDeItemsSegundaActividad+numeroDeItems));
            if (Objeto.variable1 == numeroDeItemsSegundaActividad+numeroDeItems && Objeto1.variable1 == numeroDeItemsSegundaActividad+numeroDeItems)
            {
                Debug.Log("Se cumplio el condicional de la parte 2 donde los items son 18");
                var2=true;
                var=true;
                //circulo_verde.SetActive(true);
                GetComponent<CambipMapaBotonDerecha>().CambiarSpriteMapa();
            }
            else
            {
                Objeto3.SetActive(true);
            }
        }

    }
}
