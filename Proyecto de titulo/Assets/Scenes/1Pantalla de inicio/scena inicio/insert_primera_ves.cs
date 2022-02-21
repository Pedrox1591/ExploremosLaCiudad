using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System;
using UnityEngine.UI;

[Serializable]
public class get_ultima_conexion
{
    public int usuario_id;
    public string datetime_termino;
    public int reim_id;
}

public class insert_primera_ves : MonoBehaviour
{
    // Start is called before the first frame update
    string ultima_conexion;

    void Start()
    {
        StartCoroutine(Get_primera_vez());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator Get_primera_vez()
    {
        get_ultima_conexion objeto = new get_ultima_conexion();
        objeto.usuario_id = Login.usuarios_id;
        objeto.reim_id = 600;


        string urlAPI = url_api.url+"/asigna_reim_alumno/get_ultima_conexion";

        var jsonData = JsonUtility.ToJson(objeto);
        Debug.Log(jsonData);
        using (UnityWebRequest www = UnityWebRequest.Post(urlAPI, jsonData))
        {
            www.SetRequestHeader("content-type", "application/json");
            www.uploadHandler.contentType = "application/json";
            www.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(jsonData));
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log("Tiro un error mi pana: "+www.error);
            }
            else
            {
                var result = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);

                
                if (www.isDone)
                {
                    if (result != "null")
                    {
                        Debug.Log(result);
                        var ultimaconexion = JsonUtility.FromJson<get_ultima_conexion>(result);
                        Debug.Log(ultimaconexion.datetime_termino+ "prueba");
                        //string [] a = ultimaconexion.datetime_termino.Split('T');
                        //string[] b = a[0].Split('-');
                        //string[] c = a[1].Split(':');
                        //DateTime aa = new DateTime( int.Parse(b[0]), int.Parse(b[1]), int.Parse(b[2]), int.Parse(c[0]), int.Parse(c[1]), int.Parse(c[2]));
                        string variable_sinletras = ultimaconexion.datetime_termino.Replace('T', ' ').Replace('Z', ' ');
                        
                        string[] b = variable_sinletras.Split(' ');
                        if (int.Parse(b[1].Split(':')[0])-4<0)
                        {

                            int a = int.Parse(b[1].Split(':')[0])-4;
                            Debug.Log(int.Parse(b[1].Split(':')[0])+"- 4 da: "+a);
                            string ac = (24 - (a * -1)).ToString();
                            Debug.Log(ac+" ac");
                            string nuevos_minutos = ac + ":" + b[1].Split(':')[1] + ":" + b[1].Split(':')[2];
                            //Debug.Log((24 - (a * -1)).ToString()+"  xdd");
                            //Debug.Log((b[1].Split(':')[0]));
                            Debug.Log((b[0]+ " "+nuevos_minutos + " aaaaaa"));
                            ultima_conexion = b[0] + " " + nuevos_minutos;
                        }
                        else if (int.Parse(b[1].Split(':')[0]) - 4 > 0)
                        {
                            int a = int.Parse(b[1].Split(':')[0]) - 4;
                            string ac = (int.Parse(b[1].Split(':')[0]) - (a * -1)).ToString();
                            string nuevos_minutos = ac + ":" + b[1].Split(':')[1] + ":" + b[1].Split(':')[2];
                            ultima_conexion = b[0] + " " + nuevos_minutos;
                        }
                        Debug.Log("hora ultima conexion: "+ultima_conexion);
                        Debug.Log(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"+" actual"));
                        primer_sesion();
                        //TimeZoneInfo.ConvertTimeFromUtc(,TimeZoneInfo.FindSystemTimeZoneById("a"));

                    }
                    else
                    {
                        Debug.Log("es su primer login");
                        primer_sesion();
                        //yield return new WaitForSeconds(1);
                        primer_insert();
                        AsignaReimAlumno.primera_ves = true;

                    }

                }

            }
            
        }

    }
    public void primer_sesion()
    {
        GameObject.Find("asigna_reim_alumno").GetComponent<AsignaReimAlumno>().InsertInicio();
    }
    public IEnumerator PostInsert_Element(inventario_reim_class a, string extend)
    {
        string urlAPI = url_api.url + "/Inventario_reim/" + extend;
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
        Debug.Log("Date time creation =" + ARA.datetime_creacion);
        StartCoroutine(PostInsert_Element(ARA, "add"));
    }
    public void primer_insert()
    {
        insertElement(100, 600233);
        int var = 600011;
        for (int x = 0; x < 18; x++)
        {

            insertElement(0, var);
            var = var + 1;
        }

        var = 600072;
        for (int x = 0; x < 20; x++)
        {

            insertElement(0, var);
            var = var + 1;
            //Debug.Log(var);
        }
        var = 600236;
        for (int x = 0; x < 4; x++)
        {

            insertElement(0, var);
            var = var + 1;
            //Debug.Log(var);
        }
        insertElement(0, 600235);
        //insertElement(100,600232); se elimina agua
    }
}
