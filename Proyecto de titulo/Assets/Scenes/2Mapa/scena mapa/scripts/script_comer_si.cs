using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class script_comer_si : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool comer_bool;
    public static GameObject obj_seleccionado;
    public inventario_reim objeto;
    public  GameObject estas_satisfecho;
    void Start()
    {
        comer_bool = false;
        //obj_seleccionado = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator Postt(inventario_reim_class a, string extend)
    {
        string urlAPI = "https://7tv5uzrpoj.execute-api.sa-east-1.amazonaws.com/prod/api/Inventario_reim/" + extend;
        //Debug.Log("urlPI: "+urlAPI);

        var jsonData = JsonUtility.ToJson(a);
        using (UnityWebRequest www = UnityWebRequest.Post(urlAPI, jsonData))
        {
            www.SetRequestHeader("content-type", "application/json");
            www.uploadHandler.contentType = "application/json";
            www.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(jsonData));
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log(www.error);
                Debug.Log("error!");
            }
            else
            {
                if (www.isDone)
                {
                    //Debug.Log("Se actualizo correctamente"+ extend);
                    var result = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                    //Debug.Log(result);
                    if (result != null)
                    {
                        if (extend == "add")
                        {
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
    public void insertElement(int numero_cantidad, int id_del_elemento)
    {
        inventario_reim_class ARA;
        ARA = new inventario_reim_class();
        ARA.sesion_id = AsignaReimAlumno.Session;
        ARA.id_elemento = id_del_elemento;
        ARA.cantidad = numero_cantidad;
        ARA.datetime_creacion = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
        //Debug.Log("Date time creation =" + ARA.datetime_creacion);
        StartCoroutine(Postt(ARA, "add"));
    }
    public void OnClickButton()
    {
        if ((int)inventario_reim.actual_comida + 10 <= 100)
        {
            GameObject.Find("Comer_comida").transform.localScale = new Vector3(0, 0, 0);
            insertElement((int)inventario_reim.actual_comida + 10, 600233);
            insertElement(obj_seleccionado.GetComponent<prueba>().cantidad_obtenida_get-1, obj_seleccionado.GetComponent<prueba>().idElemento);
            inventario_reim.actual_comida = inventario_reim.actual_comida + 10;
            GameObject.Find("barra_comida").GetComponent<Image>().fillAmount = inventario_reim.actual_comida / 100;
            //StartCoroutine(esperar2_segundos());
            obj_seleccionado.GetComponent<prueba>().InsertTouch(1, "Alimento ingerido");
            obj_seleccionado.GetComponent<comida_en_mapa>().texto.text = int.Parse(obj_seleccionado.GetComponent<comida_en_mapa>().texto.text) - 1 + "";
            if (int.Parse(obj_seleccionado.GetComponent<comida_en_mapa>().texto.text) == 0)
            {
                obj_seleccionado.transform.localScale = new Vector3(0, 0, 0);
            }
        }else if((int)inventario_reim.actual_comida + 10 > 100)
        {
            Debug.Log("Tu Energia ya esta llena");
            obj_seleccionado.GetComponent<prueba>().InsertTouch(0, "Energia al maximo");
            estas_satisfecho.SetActive(true);
        }
        





    }
    /*IEnumerator esperar2_segundos()
    {

        yield return new WaitForSeconds(2);
        objeto.get_comida_agua();
        GameObject.Find("NuevaMochilaCarril").GetComponent<objetos_mochila>().get_objetos();
    }*/
}
