using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reaccionar_emoji : MonoBehaviour
{
    public MostrarEsculturas a;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void reaccionar_imagen(int id_reaccion)
    {
        bool bolleano = GameObject.Find("UlearnCoins").GetComponent<UlearnCoins>().Ganar_UlearnCoins(-100);
        if (bolleano)
        {
            a.reaccionar_imagen(id_reaccion);
           
        }
    }
}
