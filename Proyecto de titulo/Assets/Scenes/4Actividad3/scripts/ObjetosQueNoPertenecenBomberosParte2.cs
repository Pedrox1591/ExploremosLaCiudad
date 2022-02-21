using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjetosQueNoPertenecenBomberosParte2 : MonoBehaviour
{
    public Image fruta1;
    public Image fruta2;
    public Image fruta3;
    public Image fruta4;
    public Image fruta5;
    public Image fruta6;
    
    
    public Sprite Objeto;
    public Sprite Objeto2;
    public Sprite Objeto3;
    public Sprite Objeto4;
    public Sprite Objeto5;
    public Sprite Objeto6;

    public GameObject GameObject_parte2;
    public CambiarMapaBotonDerechaActividad3 Objeto1 = new CambiarMapaBotonDerechaActividad3();



    // Start is called before the first frame update
    void Start()
    {
        if (Objeto1.variable == false)
        {
            GameObject_parte2.SetActive(false);
        }
        List<Image> listafrutas = new List<Image>(){fruta1,fruta2,fruta3,fruta4,fruta5,fruta6
        };
        List<Sprite> lista_de_sprites = new List<Sprite>(){Objeto,Objeto2,Objeto3,Objeto4,Objeto5,Objeto6
        };

        Debug.Log(lista_de_sprites.Count);
        for (int x = listafrutas.Count-1; x >= 0; x--)
        {
            int randomNum = Random.Range(0, lista_de_sprites.Count);
            //Debug.Log("a la fruta: "+(listafrutas[x]).ToString()+" se le va a agregar la imagen: "+ (lista_de_sprites[randomNum]).ToString() );
            listafrutas[x].sprite = lista_de_sprites[randomNum];
            lista_de_sprites.RemoveAt(randomNum);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
       
            
            
        
    }
    
}
