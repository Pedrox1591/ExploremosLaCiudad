using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CambioDeMapa : MonoBehaviour
{
    // Start is called before the first frame update
    public int id_del_mapa;
    public GameObject Necesitas_mas_ulearncoins;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void inicio_mapa(){
  
     SceneManager.LoadScene(id_del_mapa);
        
        
    }
    public void inicio_mapa_con_coste()
    {
        
            bool a = GameObject.Find("UlearnCoins").GetComponent<UlearnCoins>().Ganar_UlearnCoins(-500,true);
            if (a)
            {
            Debug.Log("si le alcansa la plata");
            }
            else
            {
                Necesitas_mas_ulearncoins.SetActive(true);
            }
        
    }
}
