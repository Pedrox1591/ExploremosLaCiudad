using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Movimiento_en_crear_esculturas : MonoBehaviour,IDragHandler
{
    public bool booleano_en_mov;
    public GameObject Padre;
    public string estado;
    public int estado_int;
    // Start is called before the first frame update
    public void OnDrag(PointerEventData data)
    {


        if (booleano_en_mov)
        {
            //Debug.Log(data.position);
            Vector3 vector = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 1);
            transform.position = vector;
            //Debug.Log(transform.position+" "+transform.localPosition);

        }


    }
    void Start()
    {
        booleano_en_mov = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Cuadro_basuras")
        {
            //Debug.Log("el objeto: esta siendo destruido"+gameObject.name);
            if (Padre.GetComponent<instance_object_in_crea_escultura>().cantidad == 0)
            {
                Padre.transform.localScale = new Vector3(40, 40, 1);
            }
            Padre.GetComponent<instance_object_in_crea_escultura>().cantidad = Padre.GetComponent<instance_object_in_crea_escultura>().cantidad + 1;
            Padre.GetComponent<instance_object_in_crea_escultura>().texto.text = Padre.GetComponent<instance_object_in_crea_escultura>().cantidad + "";
            Destroy(gameObject);
            instance_object_in_crea_escultura.objects_instanciados.Remove(gameObject);
        }
    }

}
