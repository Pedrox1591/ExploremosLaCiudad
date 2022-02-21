using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


[Serializable]
public class inventario_reim_class {
    public string sesion_id;
    public int id_elemento;
    public int cantidad;
    public string datetime_creacion;
}
public class get_cantidad{
    public int usuario_id;
    public int id_elemento;

    public int cantidad;
}

public class inventario_reim : MonoBehaviour
{
    public int id_elemento;
    public int cantidad;
    Image imagen;
    public static float actual_comida;
    public static float actual_agua;
    float tiempo;

    bool get_conseguido;
    bool corrutine_agua;
    bool corrutine_comida;
    
    public void insertElement(int numero_cantidad, int id_del_elemento) {
        inventario_reim_class ARA;
        ARA = new inventario_reim_class();
        ARA.sesion_id = AsignaReimAlumno.Session;
        ARA.id_elemento = id_del_elemento;
        ARA.cantidad = numero_cantidad;
        ARA.datetime_creacion = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
        Debug.Log("Date time creation ="+ARA.datetime_creacion);
        StartCoroutine(PostInsert_Element(ARA,"add"));
    }
        public void GetElement() {
        inventario_reim_class ARA;
        ARA = new inventario_reim_class();
        ARA.sesion_id = AsignaReimAlumno.Session;
        ARA.id_elemento = id_elemento;
        //ARA.cantidad = cantidad;
        //ARA.datetime_creacion = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
        //StartCoroutine(Get(ARA, "get_cantidad"));
    }
    public IEnumerator PostInsert_Element(inventario_reim_class a, string extend)  {
        string urlAPI = url_api.url + "/Inventario_reim/" + extend;
        //Debug.Log("urlPI: "+urlAPI);

        var jsonData = JsonUtility.ToJson(a);
        using (UnityWebRequest www = UnityWebRequest.Post(urlAPI, jsonData)) {
            www.SetRequestHeader("content-type", "application/json");
            www.uploadHandler.contentType = "application/json";
            www.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(jsonData));
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError) {
                Debug.Log(www.error);
                Debug.Log("error!");
            }
            else {
                if (www.isDone) {   
                    //Debug.Log("Se actualizo correctamente"+ extend);
                    var result = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                    Debug.Log(result);
                    if (result != null) {
                        
                            
                                //actual_comida = StockNotJson.cantidad;
                                
                            
                            //Debug.Log("Session: "+Session);
                            //Session = result;
                        
                        //var asignaRA = JsonUtility.FromJson<AsignaInicio>(result);
                        //
                    }
                }
            }
        }
    }
    public IEnumerator Get(int id_usuario, int id_elemento, string extend)
    {

        get_cantidad objeto = new get_cantidad();
        objeto.usuario_id = id_usuario;
        objeto.id_elemento = id_elemento;

        string urlAPI = url_api.url+"/Inventario_reim/" + extend;

        var jsonData = JsonUtility.ToJson(objeto);
        Debug.Log(jsonData);
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
                if (www.isDone) 
                {
                    if(result != "null")
                    {
                        var StockNotJson = JsonUtility.FromJson<get_cantidad>(result);
                        if (id_elemento == 600233)
                        {
                            actual_comida = StockNotJson.cantidad;
                            GameObject.Find("barra_comida").GetComponent<Image>().fillAmount = actual_comida / 100;
                        }

                        Debug.Log("StockNotJson.cantidad" + StockNotJson.cantidad);
                    }
                    
                }

            }
            corrutine_agua = false;
            corrutine_comida = false;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        //get_conseguido =false;
        //GetElement();
        corrutine_agua = false;
        corrutine_comida = false;
        //Debug.Log("SAAA: "+ scene.buildIndex);
        //imagen = gameObject.GetComponent<Image>();
        get_comida_agua();

    }
    

    // Update is called once per frame
    void Update()
    {

        //tiempo = tiempo + 1 * Time.deltaTime;
        //if(get_conseguido == false ){
        
        


        //}

    }
    public void get_comida_agua()
    {
                //StartCoroutine(Get(Login.usuarios_id, 600232, "get_cantidad")); se elimina agua
        StartCoroutine(Get(Login.usuarios_id, 600233, "get_cantidad"));
    }
    /*public void primer_insert(){
        insertElement(100,600233);
        //insertElement(100,600232); se elimina agua
    }*/
    public static bool validar_comida(){
        Debug.Log("ActualComida: " + actual_comida);
        if (actual_comida + 10 >=100)
        {
            return false;
        }
        else
        {
            return true;
        }
        

            }
}
