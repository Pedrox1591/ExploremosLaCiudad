using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UlearnCoins : MonoBehaviour
{
    int ulearnCoins_obtenidos;
    

    // Start is called before the first frame update
    void Start()
    {
        //insertElement(0,600235);
        get_UlearnCoins();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void get_UlearnCoins()
    {
        StartCoroutine(Get(Login.usuarios_id, 600235,"get_cantidad"));
    }

    public bool Ganar_UlearnCoins(int coins_ganadas,bool boleano = false)
    {
        if(ulearnCoins_obtenidos+ coins_ganadas >= 0)
        {
            ulearnCoins_obtenidos = ulearnCoins_obtenidos + coins_ganadas;
            insertElement(ulearnCoins_obtenidos, 600235, boleano);
            gameObject.GetComponent<Text>().text = ulearnCoins_obtenidos + "";
            return true;
        }
        else
        {
            return false;
        }
        
    }
    public IEnumerator Get(int id_usuario, int id_elemento, string extend)
    {
        get_cantidad objeto = new get_cantidad();
        objeto.usuario_id = id_usuario;
        objeto.id_elemento = id_elemento;

        string urlAPI = url_api.url + "/Inventario_reim/" + extend;

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
                        ulearnCoins_obtenidos = StockNotJson.cantidad;
                        gameObject.GetComponent<Text>().text = ulearnCoins_obtenidos + "";
                        gameObject.GetComponent<Text>().fontSize = 50;

                    }

                }

            }

        }

    }

    public void insertElement(int numero_cantidad, int id_del_elemento, bool boleano = false)
    {

        inventario_reim_class ARA;
        ARA = new inventario_reim_class();
        ARA.sesion_id = AsignaReimAlumno.Session;
        ARA.id_elemento = id_del_elemento;
        ARA.cantidad = numero_cantidad;
        ARA.datetime_creacion = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
        //Debug.Log("Date time creation =" + ARA.datetime_creacion);
        StartCoroutine(Postt(ARA, "add",boleano));
    }
    public IEnumerator Postt(inventario_reim_class a, string extend, bool boleano = false)
    {
        //yield return new WaitForSeconds(2);
        string urlAPI = url_api.url+ "/Inventario_reim/" + extend;
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
                            if (boleano)
                            {
                                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
                            }
                            //Debug.Log("Session: "+Session);
                            //Session = result;
                        }
                        //var asignaRA = JsonUtility.FromJson<AsignaInicio>(result);
                        
                    }
                }
            }
        }
    }
}
