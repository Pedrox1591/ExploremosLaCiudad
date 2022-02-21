using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class objetos_mochila : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject comida_cuadrado1;
   
    public GameObject Contend;
    public GameObject basura_cuadrado1;


    public GameObject carril_comida;
    public GameObject carril_buasura;


    public GameObject pruebaa;
    public int cantidad_de_elementos;
    public List<GameObject> Lista_basuras = new List<GameObject>()
    {
    };
    public List<GameObject> Lista_comidas = new List<GameObject>(){
        };
    int contador_comida;
    int contador_basura;
     List<GameObject> lista_de_cubos_para_basura = new List<GameObject>() { };
     List<GameObject> lista_de_cubos_para_comida = new List<GameObject>(){};

    public AnimationClip abrir_mochila;
    public AnimationClip cerrar_mochila;
    public void agregar_cuadrado_para_la_posicion()
    {
        Contend.GetComponent<RectTransform>().sizeDelta = new Vector2(Contend.GetComponent<RectTransform>().sizeDelta.x + 350, Contend.GetComponent<RectTransform>().sizeDelta.y);
        carril_buasura.GetComponent<RectTransform>().sizeDelta = new Vector2(carril_buasura.GetComponent<RectTransform>().sizeDelta.x + 350, carril_buasura.GetComponent<RectTransform>().sizeDelta.y);

        GameObject copia_basura = lista_de_cubos_para_basura[lista_de_cubos_para_basura.Count-1];
        GameObject nuevo_cubo_basura = Instantiate(copia_basura, carril_buasura.transform);
        nuevo_cubo_basura.name = "Cuadrado (" + ((int)lista_de_cubos_para_basura.Count+1)+ ")";
        nuevo_cubo_basura.transform.localPosition = new Vector3(nuevo_cubo_basura.transform.localPosition.x + 350, nuevo_cubo_basura.transform.localPosition.y, nuevo_cubo_basura.transform.localPosition.z);

        lista_de_cubos_para_basura.Add(nuevo_cubo_basura);

        carril_comida.GetComponent<RectTransform>().sizeDelta = new Vector2(carril_comida.GetComponent<RectTransform>().sizeDelta.x + 350, carril_comida.GetComponent<RectTransform>().sizeDelta.y);
        GameObject copia_comida = lista_de_cubos_para_comida[lista_de_cubos_para_comida.Count-1];
        GameObject nuevo_cubo_comida = Instantiate(copia_comida, carril_comida.transform);
        nuevo_cubo_comida.name = "Cuadrado (" + ((int)lista_de_cubos_para_comida.Count + 1) + ")";
        nuevo_cubo_comida.transform.localPosition = new Vector3(nuevo_cubo_comida.transform.localPosition.x + 350, nuevo_cubo_comida.transform.localPosition.y, nuevo_cubo_comida.transform.localPosition.z);
        lista_de_cubos_para_comida.Add(nuevo_cubo_comida);
    }
    void Start()
    {
        
        gameObject.AddComponent<Animation>();
        gameObject.GetComponent<Animation>().AddClip(cerrar_mochila, "cerrar_mochila");
        gameObject.GetComponent<Animation>().AddClip(abrir_mochila, "abrir_mochila");
        contador_comida = 0;
        contador_basura= 0;

        agregar_cosas_a_listas();
        for (int x = 0; x < Lista_basuras.Count - 1; x++)
        {
            agregar_cuadrado_para_la_posicion();
        }

        get_objetos();
    }
    void sacar_cosas_de_la_mochila()
    {
        for(int x = 0;x< Lista_comidas.Count; x++)
        {
            Lista_comidas[x].transform.position = new Vector3(0, 1000, 0);
        }
        for (int x = 0; x < Lista_basuras.Count; x++)
        {
            Lista_basuras[x].transform.position = new Vector3(0, 1000, 0);
        }
    }
    void agregar_cosas_a_listas()
    {
        lista_de_cubos_para_comida.Add(comida_cuadrado1);
        lista_de_cubos_para_basura.Add(basura_cuadrado1);
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
    public void get_objetos()
    {
        
        eliminar_objetos_instanciados();
        //lista_de_cubos_para_basura.Clear();
        //lista_de_cubos_para_comida.Clear();
        sacar_cosas_de_la_mochila();
        
        Debug.Log(lista_de_cubos_para_basura.Count+"lista_de_cubos_para_basura");
        contador_basura = 0;
        contador_comida = 0;


        int var = 600011;
        for (int x = 0; x < Lista_comidas.Count; x++)
        {

            StartCoroutine(Get(Login.usuarios_id, var, "get_cantidad", x));
            var = var + 1;
        }

        var = 600072;
        
        for (int x=0; x < Lista_basuras.Count; x++)
        {

            StartCoroutine(Get(Login.usuarios_id, var, "get_cantidad", x));
            var = var + 1;
            //Debug.Log(var);
        }
        var = 600236;
        for (int x = 20; x < Lista_basuras.Count; x++)
        {

            StartCoroutine(Get(Login.usuarios_id, var, "get_cantidad", x));
            var = var + 1;
            //Debug.Log(var);
        }
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
        using (UnityWebRequest www = UnityWebRequest.Post(urlAPI, jsonData)) {
            www.SetRequestHeader("content-type", "application/json");
            www.uploadHandler.contentType = "application/json";
            www.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(jsonData));
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError) {
                Debug.Log(www.error);
            }
            else {
                var result = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                //Debug.Log(result);
                if (www.isDone) {
                    if (result != "null")// con esto evitamos que dropee errores si no encuentra un resultado al hacer la consulta
                    {
                        var StockNotJson = JsonUtility.FromJson<get_cantidad>(result);
                        //Debug.Log(Lista_comidas[prueba]+" tiene: " + StockNotJson.cantidad);
                        if (StockNotJson.cantidad > 0 && contador_comida < Lista_comidas.Count && id_elemento>600010 && id_elemento<600029)
                        {
                            //Lista_comidas[prueba].transform.SetParent(lista_de_cubos_para_comida[0].transform);

                            
                            (Lista_comidas[prueba]).transform.position = lista_de_cubos_para_comida[contador_comida].transform.position;
                            lista_de_cubos_para_comida[contador_comida].GetComponentInChildren<Text>().text = "" + StockNotJson.cantidad;
                            Lista_comidas[prueba].GetComponent<comida_en_mapa>().texto = lista_de_cubos_para_comida[contador_comida].GetComponentInChildren<Text>();
                            //lista_de_cubos_para_comida.Remove(lista_de_cubos_para_comida[0]);
                            Lista_comidas[prueba].transform.SetParent(carril_comida.transform);
                            Lista_comidas[prueba].transform.localScale = new Vector3(40, 40, 1);
                            Debug.Log("el result para: " + Lista_comidas[prueba] + " es: " + result);
                            contador_comida = contador_comida + 1;
                            //Lista_comidas[prueba].tag = Lista_comidas[prueba].tag+"EnInventario";
                        }


                        if ((StockNotJson.cantidad > 0 && contador_basura < Lista_basuras.Count && id_elemento > 600071 && id_elemento < 600092) || (StockNotJson.cantidad > 0 && contador_basura < Lista_basuras.Count && id_elemento > 600235 && id_elemento < 600240))
                        {
                            //Lista_basuras[prueba].transform.SetParent(lista_de_cubos_para_basura[0].GetComponentInChildren<Transform>());
                            //Debug.Log(Lista_basuras[prueba] + " "+ "cantidad: "+StockNotJson.cantidad);
                            Debug.Log("contador_basura: "+ contador_basura);
                            
                            (Lista_basuras[prueba]).transform.position = lista_de_cubos_para_basura[contador_basura].transform.position;
                            Lista_basuras[prueba].transform.localScale = new Vector3(40,40, 1);
                            //Lista_comidas[prueba].tag = Lista_comidas[prueba].tag + "EnInventario";
                            lista_de_cubos_para_basura[contador_basura].GetComponentInChildren<Text>().text = ""+StockNotJson.cantidad;
                            Lista_basuras[prueba].GetComponent<InstanceObject_in_map>().cantidad = StockNotJson.cantidad;
                            Lista_basuras[prueba].GetComponent<InstanceObject_in_map>().cantidad_inicial = StockNotJson.cantidad;
                            Lista_basuras[prueba].GetComponent<InstanceObject_in_map>().texto = lista_de_cubos_para_basura[contador_basura].GetComponentInChildren<Text>();
                            Lista_basuras[prueba].GetComponent<InstanceObject_in_map>().cuadrado_basura = lista_de_cubos_para_basura[contador_basura];
                            Lista_basuras[prueba].transform.SetParent(carril_buasura.transform);
                            Debug.Log(id_elemento+" el result para: " + Lista_basuras[prueba] + " es: " + result);
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
