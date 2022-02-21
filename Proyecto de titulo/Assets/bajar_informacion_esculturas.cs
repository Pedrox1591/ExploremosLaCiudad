using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bajar_informacion_esculturas : MonoBehaviour
{
    // Start is called before the first frame update
    public bool estado_ventana;
    void Start()
    {
        estado_ventana = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void precionar_boton()
    {
        if (estado_ventana == false)
        {
            estado_ventana = true;
            GetComponent<Animator>().Play("Bajar_ventana_info");
        }
        else if (estado_ventana == true)
        {
            GetComponent<Animator>().Play("Subir_ventana_info");
            estado_ventana = false;
        }
    }
}
