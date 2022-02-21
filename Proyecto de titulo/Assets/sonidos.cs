using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class sonidos : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool estado_sonido = true;
    //public bool var;
    public AudioSource musica;
    void Start()
    {
        //musica = GetComponent<AudioSource>();
        
        Debug.Log(estado_sonido);
        if (estado_sonido)
        {
            gameObject.GetComponent<Toggle>().isOn = false;
            musica.mute = false;
        }
        else
        {
            gameObject.GetComponent<Toggle>().isOn = true;
            musica.mute = true;
        }
        //sonido();
        
         
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void sonido()
    {
        if (gameObject.GetComponent<Toggle>().isOn)
        {
            estado_sonido = false;
        }
        else
        {
            estado_sonido = true;
        }
        /*//estado_sonido = true;
        Debug.Log("LA MUSICA ESTABA EN : "+estado_sonido);
        if (estado_sonido)
        {
            
            estado_sonido = false;
            musica.Pause();
            Debug.Log(" ahora esta en estado_sonido: " + estado_sonido);
            //gameObject.GetComponent<Toggle>().isOn = true;
            
        }
        else if (estado_sonido ==false)
        {
            //gameObject.GetComponent<Toggle>().isOn = false;
            estado_sonido = true;
            musica.Play();
            Debug.Log("ahora esta en estado_sonido: " + estado_sonido);
        }*/
        
    }
}
