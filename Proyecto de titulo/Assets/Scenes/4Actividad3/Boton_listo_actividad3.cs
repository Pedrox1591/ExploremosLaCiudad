using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boton_listo_actividad3 : MonoBehaviour
{
    public DondeDejarObjetosQueNoPertenecen Objeto = new DondeDejarObjetosQueNoPertenecen();
    public DondeDejarObjetosQuePertenecen Objeto1 = new DondeDejarObjetosQuePertenecen();
    public GameObject Objeto3;
    public int numeroDeItems;
    public int numeroDeItemsSegundaActividad;
    public GameObject circulo_verde;
    public bool final;

    public bool var;
    // Start is called before the first frame update
    void Start()
    {
        var = false;
        Objeto3.SetActive(false);
        circulo_verde.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void boton_todo_listo()
    {
        if (var == false)
        {
            if (Objeto.variable1 == numeroDeItems && Objeto1.variable1 == numeroDeItems)
            {
                Debug.Log("Se cumplio el condicional");
                var = true;
                circulo_verde.SetActive(true);
                Objeto3.SetActive(false);
                
            }
            else
            {
                Objeto3.SetActive(true);
            }
        }
        if(var == true)
        {
            if (Objeto.variable1 == numeroDeItemsSegundaActividad+numeroDeItems && Objeto1.variable1 == numeroDeItemsSegundaActividad+numeroDeItems)
            {
                Debug.Log("Se cumplio el condicional");
                Objeto3.SetActive(false);
                var = true;
                circulo_verde.SetActive(true);
                final = true;
            }
            else
            {
                Objeto3.SetActive(true);
            }
        }


    }
}
