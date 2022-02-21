using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class restar_agua_comida : MonoBehaviour
{
    // Start is called before the first frame update

    int id_elemento_comida =600233;
    int id_elemento_agua =600232;
    int cantida_obtenida_por_Get_agua;
    int cantida_obtenida_por_Get_comida;
    /*bool resta_relizada_water;
    bool resta_relizada_eat;
    bool in_corutine_water;
    bool in_corutine_eat;*/


    void Start()
    {
        /*resta_relizada_water = true;
        resta_relizada_eat = true;
        in_corutine_water = false;
        in_corutine_eat = false;*/
        int y = SceneManager.GetActiveScene().buildIndex;
        if (y == 4 || y == 6 || y == 8 || y == 12 || y == 13)
        {
            //StartCoroutine(Get(Login.usuarios_id, id_elemento_agua, "get_cantidad"));
            StartCoroutine(Get(Login.usuarios_id, id_elemento_comida, "get_cantidad"));
        }

    }
    /*void cantidad_a_insertar_agua(){
        

        //Debug.Log("cantida_obtenida_por_Get>20 = "+cantida_obtenida_por_Get+" "+20);
        if(resta_relizada_water == true)
        {
            //resta_relizada_water = true;
            //Debug.Log("SE HACE EL INSERT CON"+ cantida_obtenida_por_Get+"- 20");
            
            Debug.Log("YA SE REALIZO EL PRIMER INSERT");
        }
    }
    void cantidad_a_insertar_eat()
    {
        

        //Debug.Log("cantida_obtenida_por_Get>20 = "+cantida_obtenida_por_Get+" "+20);
        if (resta_relizada_eat == true)
        {
            //resta_relizada_eat = true;
            //Debug.Log("SE HACE EL INSERT CON"+ cantida_obtenida_por_Get+"- 20");
            
            Debug.Log("YA SE REALIZO EL PRIMER INSERT");
            
            Debug.Log("YA SE REALIZO EL SEGUNDO INSERT");
        }
    }*/
    public void insertElement(int numero_cantidad,int id_del_elemento) {
        inventario_reim_class ARA;
        ARA = new inventario_reim_class();
        ARA.sesion_id = AsignaReimAlumno.Session;
        ARA.id_elemento = id_del_elemento;
        ARA.cantidad = numero_cantidad;
        ARA.datetime_creacion = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
        Debug.Log("Date time creation ="+ARA.datetime_creacion);
        StartCoroutine(Post(ARA,"add"));
    }
    public IEnumerator Post(inventario_reim_class a, string extend)  {
        string urlAPI = url_api.url+"/Inventario_reim/" + extend;
        //Debug.Log("urlPI: "+urlAPI);

        var jsonData = JsonUtility.ToJson(a);
        using (UnityWebRequest www = UnityWebRequest.Post(urlAPI, jsonData)) {
            www.SetRequestHeader("content-type", "application/json");
            www.uploadHandler.contentType = "application/json";
            www.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(jsonData));
            yield return www.SendWebRequest();

            if (www.isNetworkError) {
                Debug.Log(www.error);
                Debug.Log("error!");
            }
            else {
                if (www.isDone) {   
                    //Debug.Log("Se actualizo correctamente"+ extend);
                    var result = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                    //Debug.Log(result);
                    if (result != null) {
                        if(extend == "add"){
                            //Debug.Log("Session: "+Session);
                            //Session = result;
                        }
                        //var asignaRA = JsonUtility.FromJson<AsignaInicio>(result);
                        //
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    { 
    }
    public IEnumerator Get(int id_usuario, int id_elemento, string extend)
    {
        /*if (id_elemento == 600232)
        {
            in_corutine_water = true;
        }
        if (id_elemento == 600233)
        {
            in_corutine_eat = true;
        }*/

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
            else 
            {
                var result = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                if (www.isDone) {
                    var StockNotJson = JsonUtility.FromJson<get_cantidad>(result);
                    if(id_elemento ==600232){
                        cantida_obtenida_por_Get_agua = StockNotJson.cantidad;
                        //resta_relizada_water = false;
                        insertElement(cantida_obtenida_por_Get_agua - 20, 600232);
                    }
                    if(id_elemento == 600233){
                        cantida_obtenida_por_Get_comida = StockNotJson.cantidad;
                        //resta_relizada_eat = false;
                        insertElement(cantida_obtenida_por_Get_comida -20, 600233);
                    }
                    //Debug.Log("StockNotJson.cantidad"+ StockNotJson.cantidad);
                }

            }
            //in_corutine_water = false;
            //in_corutine_eat = false;
        }

    }
}
