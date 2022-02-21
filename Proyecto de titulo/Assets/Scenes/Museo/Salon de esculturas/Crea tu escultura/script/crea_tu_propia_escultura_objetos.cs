using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class crea_tu_propia_escultura_objetos : MonoBehaviour
{
    public List<GameObject> Lista_basuras = new List<GameObject>()
    {
    };
    public GameObject basura_cuadrado1;
    /*public GameObject basura_cuadrado3;
    public GameObject basura_cuadrado4;
    public GameObject basura_cuadrado5;
    public GameObject basura_cuadrado6;
    public GameObject basura_cuadrado7;
    public GameObject basura_cuadrado8;
    public GameObject basura_cuadrado9;
    public GameObject basura_cuadrado10;
    public GameObject basura_cuadrado11;
    public GameObject basura_cuadrado12;
    public GameObject basura_cuadrado13;
    public GameObject basura_cuadrado14;
    public GameObject basura_cuadrado15;
    public GameObject basura_cuadrado16;
    public GameObject basura_cuadrado17;
    public GameObject basura_cuadrado18;
    public GameObject basura_cuadrado19;
    public GameObject basura_cuadrado20;*/
    public GameObject Contend;
    public GameObject carril_buasura;
    int contador_basura;
    public List<GameObject> lista_de_cubos_para_basura = new List<GameObject>() { };
    // Start is called before the first frame update
    void Start()
    {
        
        lista_de_cubos_para_basura.Add(basura_cuadrado1);
        for (int x = 0; x < Lista_basuras.Count; x++)
        {
            agregar_cuadrado_para_la_posicion();
        }
        Debug.Log("EL START SE LLAMA"+gameObject.name);
        get_objetos();
    }
    public void agregar_cuadrado_para_la_posicion()
    {
        Contend.GetComponent<RectTransform>().sizeDelta = new Vector2(Contend.GetComponent<RectTransform>().sizeDelta.x + 250, Contend.GetComponent<RectTransform>().sizeDelta.y);
        carril_buasura.GetComponent<RectTransform>().sizeDelta = new Vector2(carril_buasura.GetComponent<RectTransform>().sizeDelta.x + 250, carril_buasura.GetComponent<RectTransform>().sizeDelta.y);
        GameObject copia_basura = lista_de_cubos_para_basura[lista_de_cubos_para_basura.Count - 1];
        GameObject nuevo_cubo_basura = Instantiate(copia_basura, carril_buasura.transform);
        nuevo_cubo_basura.name = "Cuadrado (" + ((int)lista_de_cubos_para_basura.Count + 1) + ")";
        nuevo_cubo_basura.transform.localPosition = new Vector3(nuevo_cubo_basura.transform.localPosition.x + 250, nuevo_cubo_basura.transform.localPosition.y, nuevo_cubo_basura.transform.localPosition.z);
        lista_de_cubos_para_basura.Add(nuevo_cubo_basura);
    }
    void get_objetos()
    {
        contador_basura = 0;
        sacar_cosas_de_la_mochila();
        eliminar_objetos_instanciados();
        //llenar_lista_basura();
        
        int var = 600072;
        for (int x = 0; x < 20; x++)
        {

            StartCoroutine(Get(Login.usuarios_id, var, "get_cantidad", x));
            var = var + 1;
            //Debug.Log(var);
        }
        var = 600236;
        for (int x = 20; x < 24; x++)
        {

            StartCoroutine(Get(Login.usuarios_id, var, "get_cantidad", x));
            var = var + 1;
            //Debug.Log(var);
        }
    }
    void sacar_cosas_de_la_mochila()
    {
        
        for (int x = 0; x < Lista_basuras.Count; x++)
        {
            Lista_basuras[x].transform.position = new Vector3(0, 1000, 0);
        }
    }
    public void eliminar_objetos_instanciados()
    {
        for (int x = 0; x < InstanceObject_in_map.objects_instanciados.Count; x++)
        {
            InstanceObject_in_map.objects_instanciados[x].GetComponent<movimiento_en_mapa>().Padre.GetComponent<InstanceObject_in_map>().item_normalidad();
            Destroy(InstanceObject_in_map.objects_instanciados[x]);
        }
        InstanceObject_in_map.objects_instanciados.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator Get(int id_usuario, int id_elemento, string extend, int prueba)
    {
        get_cantidad objeto = new get_cantidad();
        objeto.usuario_id = id_usuario;
        objeto.id_elemento = id_elemento;

        string urlAPI = url_api.url+"/Inventario_reim/" + extend;

        var jsonData = JsonUtility.ToJson(objeto);
        //Debug.Log(jsonData);
        using (UnityWebRequest www = UnityWebRequest.Post(urlAPI, jsonData))
        {
            www.SetRequestHeader("content-type", "application/json");
            www.uploadHandler.contentType = "application/json";
            www.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(jsonData));
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log(www.error);
            }
            else
            {
                var result = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                //Debug.Log(result);
                if (www.isDone)
                {
                    if (result != "null")// con esto evitamos que dropee errores si no encuentra un resultado al hacer la consulta
                    {
                        var StockNotJson = JsonUtility.FromJson<get_cantidad>(result);
                        //Debug.Log(Lista_comidas[prueba]+" tiene: " + StockNotJson.cantidad);
                        if ((StockNotJson.cantidad > 0 && contador_basura < 20 && id_elemento > 600071 && id_elemento < 600092)||(StockNotJson.cantidad > 0 && contador_basura < 20 && id_elemento > 600235 && id_elemento < 600240))
                        {
                            Debug.Log("pruebarty: " + prueba);
                            //Lista_basuras[prueba].transform.SetParent(lista_de_cubos_para_basura[0].GetComponentInChildren<Transform>());
                            //Debug.Log("ENTRA AL DESGRACIADO IF con la cantidad: "+ StockNotJson.cantidad);
                            Debug.Log("lista_de_cubos_para_basura[contador_basura]: " + lista_de_cubos_para_basura[contador_basura] + " Lista_basuras[prueba]: " + Lista_basuras[prueba]);
                            (Lista_basuras[prueba]).transform.position = lista_de_cubos_para_basura[contador_basura].transform.position;
                            
                            Lista_basuras[prueba].transform.localScale = new Vector3(35, 35, 1);
                            //Lista_comidas[prueba].tag = Lista_comidas[prueba].tag + "EnInventario";
                            lista_de_cubos_para_basura[contador_basura].GetComponentInChildren<Text>().text = "" + StockNotJson.cantidad;
                            Lista_basuras[prueba].GetComponent<instance_object_in_crea_escultura>().cantidad = StockNotJson.cantidad;
                            Lista_basuras[prueba].GetComponent<instance_object_in_crea_escultura>().cantidad_inicial = StockNotJson.cantidad;
                            Lista_basuras[prueba].GetComponent<instance_object_in_crea_escultura>().texto = lista_de_cubos_para_basura[contador_basura].GetComponentInChildren<Text>();
                            Lista_basuras[prueba].GetComponent<instance_object_in_crea_escultura>().cuadrado_basura = lista_de_cubos_para_basura[0];
                            Lista_basuras[prueba].transform.SetParent(carril_buasura.transform);
                            contador_basura = contador_basura + 1;

                            //lista_de_cubos_para_basura.Remove(lista_de_cubos_para_basura[0]);
                            //Debug.Log(lista_de_cubos_para_basura.Count);
                        }

                    }

                }

            }

        }

    }

}
