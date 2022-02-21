using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class basura_no_reciclable_parte2 : MonoBehaviour
{
    public Image imgObjeto;
    public Image imgObjeto1;
    public Image imgObjeto2;
    public Image imgObjeto3;
    public Image imgObjeto4;
    public Sprite objeto;
    public Sprite objeto1;
    public Sprite objeto2;
    public Sprite objeto3;
    public Sprite objeto4;
    public GameObject GameObject_parte2;
    public Cambiar_mapa_Boton_derecha_actividad2 Objeto = new Cambiar_mapa_Boton_derecha_actividad2();

    // Start is called before the first frame update
    void Start()
    {
        if (Objeto.variable == false)
        {
            GameObject_parte2.SetActive(false);
        }
        List<Image> listaImgObjetos = new List<Image>(){imgObjeto,imgObjeto1,imgObjeto2,imgObjeto3,imgObjeto4,
        };
        List<Sprite> lista_de_sprites = new List<Sprite>(){objeto,objeto1,objeto2,objeto3,objeto4
        };

        for (int x = listaImgObjetos.Count - 1; x >= 0; x--)
        {
            int randomNum = Random.Range(0, lista_de_sprites.Count);
            //Debug.Log("a la fruta: "+(listafrutas[x]).ToString()+" se le va a agregar la imagen: "+ (lista_de_sprites[randomNum]).ToString() );
            listaImgObjetos[x].sprite = lista_de_sprites[randomNum];
            lista_de_sprites.RemoveAt(randomNum);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
