using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjetosQueNoPertenecenBomberosParte1 : MonoBehaviour
{
    public Image fruta1;
    public Image fruta2;
    public Image fruta3;
    public Image fruta4;
    public Image fruta5;
    public Image fruta6;
    public Sprite objeto;
    public Sprite objeto2;
    public Sprite objeto3;
    public Sprite objeto4;
    public Sprite objeto5;
    public Sprite objeto6;

    // Start is called before the first frame update
    void Start()
    {
        List<Image> listafrutas = new List<Image>(){fruta1,fruta2,fruta3,fruta4,fruta5,fruta6
        };
        List<Sprite> lista_de_sprites = new List<Sprite>(){objeto,objeto2,objeto3,objeto4,objeto5,objeto6,
        };
        

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
