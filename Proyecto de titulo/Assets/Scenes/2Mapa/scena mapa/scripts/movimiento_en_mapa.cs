using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class movimiento_en_mapa : MonoBehaviour, IDragHandler
{
    // Start is called before the first frame update
    public bool booleano_en_mov;
    public GameObject Padre;
    public static bool en_zona_para_reciclaje;
    public string estado;
    public int estado_int;
    void Start()
    {
        en_zona_para_reciclaje = false;
        booleano_en_mov = true;
    }
    public void OnDrag(PointerEventData data)
    {


        if (booleano_en_mov)
        {
            //Debug.Log(data.position);
            transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y,0);

        }


    }
    


    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("eNTRA AL TRIGGER");
        if (gameObject.tag == "BasuraPlastico" && collision.name == "basureros_plastico")
        {
            Debug.Log("has puesto bien el objeto: " + gameObject.name + " en el basureros_plastico");
            estado = "Objeto Reciclado";
            estado_int = 1;
            gameObject.GetComponent<prueba>().InsertTouch(estado_int, estado);
            Padre.GetComponent<InstanceObject_in_map>().cantidad_inicial = Padre.GetComponent<InstanceObject_in_map>().cantidad_inicial - 1;
            gameObject.GetComponent<prueba>().insertElement(Padre.GetComponent<InstanceObject_in_map>().cantidad_inicial, gameObject.GetComponent<prueba>().idElemento);
            InstanceObject_in_map.objects_instanciados.Remove(gameObject);
            StartCoroutine(destruir_objecto());
            GameObject.Find("UlearnCoins").GetComponent<UlearnCoins>().Ganar_UlearnCoins(5);

        }
        else if ((gameObject.tag == "BasuraPlastico" && collision.name == "basurero_vidrio") || (gameObject.tag == "BasuraPlastico" && collision.name == "basurero_papel"))
        {
            estado = "Incorrecto";
            estado_int = 0;
            //Debug.Log("has puesto mal el objeto: " + gameObject.name + " en el basureros_plastico");
            gameObject.GetComponent<prueba>().InsertTouch(estado_int, estado);
        }

        if (gameObject.tag == "BasuraVidrio" && collision.name == "basurero_vidrio")
        {
            Debug.Log("has puesto bien el objeto: " + gameObject.name + " en el basureros_vidrio");
            estado = "Objeto Reciclado";
            estado_int = 1;
            gameObject.GetComponent<prueba>().InsertTouch(estado_int, estado);
            Padre.GetComponent<InstanceObject_in_map>().cantidad_inicial = Padre.GetComponent<InstanceObject_in_map>().cantidad_inicial - 1;
            gameObject.GetComponent<prueba>().insertElement(Padre.GetComponent<InstanceObject_in_map>().cantidad_inicial, gameObject.GetComponent<prueba>().idElemento);
            InstanceObject_in_map.objects_instanciados.Remove(gameObject);
            StartCoroutine(destruir_objecto());
            GameObject.Find("UlearnCoins").GetComponent<UlearnCoins>().Ganar_UlearnCoins(5);
        }
        else if ((gameObject.tag == "BasuraVidrio" && collision.name == "basureros_plastico") || (gameObject.tag == "BasuraVidrio" && collision.name == "basurero_papel"))
        {
            estado = "Incorrecto";
            estado_int = 0;
            gameObject.GetComponent<prueba>().InsertTouch(estado_int, estado);
            //Debug.Log("has puesto mal el objeto: " + gameObject.name + " en el basureros_plastico");
        }
        if (gameObject.tag == "BasuraPapel" && collision.name == "basurero_papel")
        {
            Debug.Log("has puesto bien el objeto: " + gameObject.name + " en el basurero_papel");
            estado = "Objeto Reciclado";
            estado_int = 1;
            gameObject.GetComponent<prueba>().InsertTouch(estado_int, estado);
            Padre.GetComponent<InstanceObject_in_map>().cantidad_inicial = Padre.GetComponent<InstanceObject_in_map>().cantidad_inicial - 1;
            gameObject.GetComponent<prueba>().insertElement(Padre.GetComponent<InstanceObject_in_map>().cantidad_inicial, gameObject.GetComponent<prueba>().idElemento);
            InstanceObject_in_map.objects_instanciados.Remove(gameObject);
            StartCoroutine(destruir_objecto());
            GameObject.Find("UlearnCoins").GetComponent<UlearnCoins>().Ganar_UlearnCoins(5);
        }
        else if ((gameObject.tag == "BasuraPapel" && collision.name == "basureros_plastico") || (gameObject.tag == "BasuraPapel" && collision.name == "basurero_vidrio"))
        {
            estado = "Incorrecto";
            estado_int = 0;
            gameObject.GetComponent<prueba>().InsertTouch(estado_int, estado);
            //Debug.Log("has puesto mal el objeto: " + gameObject.name + " en el basureros_plastico");
        }
        else if (gameObject.tag != "BasuraPlastico" && gameObject.tag != "basurero_vidrio" && gameObject.tag != "basurero_papel")
        {
            estado = "No aplica";
            estado_int = 2;
            gameObject.GetComponent<prueba>().InsertTouch(estado_int, estado);
        }
        if (collision.name == "NuevaMochilaCarril")
        {
            //Debug.Log("el objeto: esta siendo destruido"+gameObject.name);
            if (Padre.GetComponent<InstanceObject_in_map>().cantidad == 0)
            {
                Padre.transform.localScale = new Vector3(40, 40, 1);
            }
            Padre.GetComponent<InstanceObject_in_map>().cantidad = Padre.GetComponent<InstanceObject_in_map>().cantidad + 1;
            Padre.GetComponent<InstanceObject_in_map>().texto.text = Padre.GetComponent<InstanceObject_in_map>().cantidad + "";
            Destroy(gameObject);
            InstanceObject_in_map.objects_instanciados.Remove(gameObject);
        }

    }
    public IEnumerator destruir_objecto()
    {
        gameObject.transform.localScale = new Vector3(0,0,0);
        yield return new WaitForSeconds(5);
        Destroy(gameObject);

    }
}
