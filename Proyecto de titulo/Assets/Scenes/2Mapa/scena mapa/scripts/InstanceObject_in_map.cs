using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstanceObject_in_map : MonoBehaviour
{
    public int cantidad_inicial;
    public int cantidad;
    public Text texto;
    public GameObject cuadrado_basura;
    public static List<GameObject> objects_instanciados = new List<GameObject> ();
    bool instance;//si la cantidad es mayor a 0, instance es true
    
    // Start is called before the first frame update
    void Start()
    {
        instance = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void instanceObject()
    {
        if (cantidad > 0)
        {
            instance = true;
        }
        Debug.Log("para el obj: "+gameObject.name+ "instance:"+instance+" en_zona_para_reciclaje: "+ movimiento_en_mapa.en_zona_para_reciclaje + " y su cantidad: "+ cantidad+" y su cantidad inicial es: "+ cantidad_inicial);
        if (instance && movimiento_en_mapa.en_zona_para_reciclaje)
        {
            //Sprite sprite_objeto = gameObject.GetComponent<Image>().sprite;
            GameObject a = Instantiate(gameObject);
            //Destroy(a.GetComponent<Image>());
            //a.AddComponent<SpriteRenderer>().sprite = sprite_objeto;
            a.transform.localPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 50, 0);
            a.transform.localPosition = GameObject.Find("Spawn_basura").transform.position;
            a.transform.SetParent(GameObject.Find("Canvas").transform);
            //a.AddComponent<BoxCollider2D>();
            Destroy(a.GetComponent<InstanceObject_in_map>());
            a.AddComponent<movimiento_en_mapa>();
            a.GetComponent<movimiento_en_mapa>().Padre = gameObject;
            a.AddComponent<Rigidbody2D>();
            a.GetComponent<Rigidbody2D>().gravityScale = 0;
            //a.GetComponent<movimiento_en_mapa>().booleano_en_mov=true;
            Transform b = gameObject.transform;

            a.transform.localScale = new Vector3(15, 15, 1);
            texto.text = "" + (cantidad - 1);
            cantidad = cantidad - 1;
            objects_instanciados.Add(a);
            if (cantidad == 0)
            {
                instance = false;
                gameObject.transform.localScale = new Vector3(0,0,0);
            }
        }
        
    }
    public void item_normalidad()
    {
        gameObject.transform.localScale = new Vector3(40, 40, 1);
        cantidad = cantidad_inicial;
        texto.text = cantidad + "";
    }
}
