using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zona_reciclaje : MonoBehaviour
{
    public GameObject bote_vidrio;
    public GameObject bote_plastico;
    public GameObject bote_papel;
    public GameObject bote_vidrio_enmapa;
    public GameObject bote_plastico_enmapa;
    public GameObject bote_papel_enmapa;
    // Start is called before the first frame update
    public GameObject reciclar;
    public AnimationClip agrandar;
    public GameObject Mochila;
    void Start()
    {
        //bote_plastico.AddComponent<Animation>().AddClip(agrandar, "a");
        //bote_papel.AddComponent<Animation>().AddClip(agrandar, "a");
        //bote_vidrio.AddComponent<Animation>().AddClip(agrandar, "a");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Jugador")
        {
            bote_plastico.GetComponent<Animation>().Play("animacion_bote_de_basura_agrandar");
            bote_papel.GetComponent<Animation>().Play("animacion_bote_de_basura_agrandar");
            bote_vidrio.GetComponent<Animation>().Play("animacion_bote_de_basura_agrandar");
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log(collision.name);
        if (collision.name == "Jugador")
        {
            bote_plastico.transform.position = new Vector3(bote_plastico_enmapa.transform.position.x+15, bote_plastico_enmapa.transform.position.y+20,0);
            bote_papel.transform.position = new Vector3(bote_papel_enmapa.transform.position.x, bote_papel_enmapa.transform.position.y+20, 0);
            bote_vidrio.transform.position = new Vector3(bote_vidrio_enmapa.transform.position.x- 15, bote_vidrio_enmapa.transform.position.y+20, 0);
            reciclar.SetActive(true);
            
            
            bote_plastico_enmapa.SetActive(false);
            bote_papel_enmapa.SetActive(false);
            bote_vidrio_enmapa.SetActive(false);
            movimiento_en_mapa.en_zona_para_reciclaje = true;
            Mochila.GetComponent<Animator>().Play("Agrandar_mochila_animacion");
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log("si sale we");
        if (collision.name == "Jugador")
        {
            GameObject.Find("NuevaMochilaCarril").GetComponent<objetos_mochila>().eliminar_objetos_instanciados();
            reciclar.SetActive(false);
            movimiento_en_mapa.en_zona_para_reciclaje = false;
            bote_plastico_enmapa.SetActive(true);
            bote_papel_enmapa.SetActive(true);
            bote_vidrio_enmapa.SetActive(true); 
            Mochila.GetComponent<Animator>().Play("fin_animacion");


        }
    }
}
