using UnityEngine.Networking;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[Serializable]
public class TimeActivity
{
    public int id;
    public string inicio;
    public string final;
    public int causa;
    public int usuario_id;
    public int reim_id;
    public int actividad_id;
}

public class TiempoxActividad : MonoBehaviour {
    public int Actividad;
    DateTime Fecha_I;
    public static string Session;
    string inicioaux;

    public string ide;

    public void InsertInicio(int Actividad) {
        TimeActivity ti;
        ti = new TimeActivity();
        ti.inicio = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
        inicioaux = ti.inicio;
        ti.final = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
        ti.causa = 0;
        ti.usuario_id = Login.usuarios_id;
        ti.reim_id = 600;
        ti.actividad_id = Actividad;
        StartCoroutine(Post(ti, "add"));
    }

    public void UpdateTxA(){
        TimeActivity ti;
        ti = new TimeActivity ();
        ti.final = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
        StartCoroutine(Post(ti, $"final/{ide}")); 
    }

    void OnApplicationPause() {
        UpdateTxA();
    }

    public IEnumerator Post(TimeActivity ti, string extend) {
        string urlAPI = url_api.url+"/tiempoxactividad/" + extend;
        //Debug.Log("urlPI de tiempoxactividad: "+urlAPI);
        var jsonData = JsonUtility.ToJson(ti);
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
                if (www.isDone){

                    //Debug.Log("hola1");
                    var result = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);

                    Debug.Log(result);
                    if (result != null) {
                        if(extend == "add")
                        {
                            Debug.Log("result: "+result);
                            ide = result; 
                        }
                    }
                }
            }
        }
    }

    

    void Start() {

        InsertInicio(Actividad);
    }
    public void SalirseDeLaActividad()
    {
        TimeActivity tiP;
        tiP = new TimeActivity();
        tiP.inicio = inicioaux;
        inicioaux = tiP.inicio;
        tiP.final = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
        tiP.causa = 1;
        tiP.usuario_id = Login.usuarios_id;
        tiP.reim_id = 600;
        tiP.actividad_id = Actividad;
        Debug.Log($"update/{Session}");
        StartCoroutine(Post(tiP, $"update/{ide}"));
    }

    void OnApplicationQuit()
    {
        TimeActivity tiP;
        tiP = new TimeActivity();
        tiP.inicio = inicioaux;
        inicioaux = tiP.inicio;
        tiP.final = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
        tiP.causa = 2;
        tiP.usuario_id = Login.usuarios_id;
        tiP.reim_id = 600;
        tiP.actividad_id = Actividad;
        Debug.Log($"update/{Session}");
        StartCoroutine(Post(tiP, $"update/{ide}"));
    }

}
