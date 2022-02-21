using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[Serializable]
public class AsignaInicio
{
    public string sesion_id;
    public int usuario_id;
    public int periodo_id;
    public int reim_id;
    public string datetime_inicio;
    public string datetime_termino;
    

}

public class AsignaReimAlumno : MonoBehaviour {
    public static string Session;
    public static int var = 0;
    public static bool primera_ves;
    //public GameObject alerta_primera_vez;
    //public int code;

    public void InsertInicio() {
;
        var = 1;
        AsignaInicio a;
        a = new AsignaInicio();
        a.sesion_id = Login.usuarios_id + "-" +600+"-"+ System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
        Session = a.sesion_id;
        a.usuario_id = Login.usuarios_id;
        a.periodo_id = url_api.periodo;
        a.reim_id = 600;
        a.datetime_inicio = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
        a.datetime_termino = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
        StartCoroutine(Post(a, "add"));
    } 

    public void UpdateARA()
    {
        AsignaInicio a;
        a = new AsignaInicio();
        a.datetime_termino = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
        //Debug.Log($"final/{Session}");
        StartCoroutine(Post(a, $"final/{Session}"));
    }

    void OnApplicationQuit()
    {
        UpdateARA();
    }

    void OnApplicationPause()
    {
        UpdateARA();
    }

    public IEnumerator Post(AsignaInicio a, string extend)  {
        Debug.Log("entra a la corrutina post");
        string urlAPI = url_api.url+"/asigna_reim_alumno/" + extend;
        Debug.Log("urlPI: "+urlAPI);

        var jsonData = JsonUtility.ToJson(a);
        using (UnityWebRequest www = UnityWebRequest.Post(urlAPI, jsonData))
        {
            www.SetRequestHeader("content-type", "application/json");
            www.uploadHandler.contentType = "application/json";
            www.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(jsonData));
            Debug.Log("aquitamos antes del yield");
            yield return www.SendWebRequest();
            Debug.Log("aquitamos despues del yield");

            if (www.isNetworkError)
            {
                Debug.Log(www.error);
                Debug.Log("error!");
            }
            else
            {
                if (www.isDone) {   
                    //Debug.Log("Se actualizo correctamente"+ extend);
                    var result = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                    Debug.Log("el result de asigna_reim_alumno: "+result);
                    if (result != null) {
                        if(extend == "add"){

                            Debug.Log("Session: "+Session);
                            //Session = result;
                        }
                        //var asignaRA = JsonUtility.FromJson<AsignaInicio>(result);
                        //
                    }
                }
            }
        }
    }

    void Start()
    {
        if(var ==0 && SceneManager.GetActiveScene().buildIndex ==2){
            InsertInicio();
            //alerta_primera_vez.SetActive(true);
        }
        
        //if (code == 2)
        //{
            
        //}
    }


}
