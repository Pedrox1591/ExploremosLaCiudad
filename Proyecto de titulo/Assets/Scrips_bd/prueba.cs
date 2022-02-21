using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

[Serializable]
public class AlumnoRespuestaActividad {
    public int id_reim;
    public int id_actividad;
    public int id_elemento;
    public string datetime_touch;
    public float Eje_X;
    public float Eje_Y;
    public float Eje_Z;
    public int correcta;
    public int id_user;
    public int id_per;
    public string resultado;
    public int Tipo_Registro;
}

public class prueba : MonoBehaviour,IEndDragHandler, IPointerClickHandler
{
    //public int idReim; 
    public int idActividad;
    public int idElemento;
    //public int Correcta;
    //public int idUser;
    //public int idPer;
    //public string Resultado;
    public int TipoRegistro;
    public movimiento objeto;
    public movimiento_en_mapa objeto2;
    public int cantidad_obtenida_get;
    int id_Actividad;



    public void InsertTouch(int Correctaa,string a) {
        AlumnoRespuestaActividad ARA;
        ARA = new AlumnoRespuestaActividad();
        ARA.id_reim = 600;
        ARA.id_actividad = idActividad;
        ARA.id_elemento = idElemento;
        ARA.datetime_touch = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
        ARA.Eje_X = Convert.ToInt32(Input.mousePosition.x);
        ARA.Eje_Y = Convert.ToInt32(Input.mousePosition.y);
        ARA.Eje_Z = Convert.ToInt32(Input.mousePosition.z);
        ARA.correcta = Correctaa;
        ARA.id_user = Login.usuarios_id;
        ARA.id_per = url_api.periodo;
        ARA.resultado = a;
        ARA.Tipo_Registro = TipoRegistro;
        StartCoroutine(Post(ARA));
    }
    public void InsertTouch_movimiento(int Correctaa, string a)
    {
        AlumnoRespuestaActividad ARA;
        ARA = new AlumnoRespuestaActividad();
        ARA.id_reim = 600;
        ARA.id_actividad = idActividad;
        ARA.id_elemento = idElemento;
        ARA.datetime_touch = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
        ARA.Eje_X = Convert.ToInt32(transform.localPosition.x);
        ARA.Eje_Y = Convert.ToInt32(transform.localPosition.y);
        ARA.Eje_Z = Convert.ToInt32(transform.localPosition.z);
        ARA.correcta = Correctaa;
        ARA.id_user = Login.usuarios_id;
        ARA.id_per = url_api.periodo;
        ARA.resultado = a;
        ARA.Tipo_Registro = TipoRegistro;
        StartCoroutine(Post(ARA));
    }


    public IEnumerator Post(AlumnoRespuestaActividad ARA) {
        string urlAPI = url_api.url+"/alumno_respuesta/add";

        var jsonData = JsonUtility.ToJson(ARA);

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
                    var result = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                    if (result != null) {
                        //var AlumnoRespuesta = JsonUtility.FromJson<AlumnoRespuestaActividad>(result);                                         
                    }
                }
            }
        }
    }
    //public void OnPointerClick(PointerEventData eventData)
    //{
      //  InsertTouch();
    //}
    public void OnEndDrag(PointerEventData eventData){
        //Debug.Log("apretaste el "+gameObject.name);

        if (id_Actividad == 4)
        {
            Debug.Log("estas tocando el objeto: "+gameObject.name);
            InsertTouch(gameObject.GetComponent<movimiento>().variable_muy_variable, gameObject.GetComponent<movimiento>().resultado_movimiento);
        }
        if (id_Actividad == 2)
        {
            InsertTouch(gameObject.GetComponent<movimiento_en_mapa>().estado_int, gameObject.GetComponent<movimiento_en_mapa>().estado);
        }
        if(id_Actividad == 6)
        {
            InsertTouch(gameObject.GetComponent<movimiento>().variable_muy_variable, gameObject.GetComponent<movimiento>().resultado_movimiento);
        }
        OnPointerClick(eventData);
    }
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        
        if (id_Actividad == 4)
        {
            try
            {
                if (GameObject.Find("CuadradoMochila").activeInHierarchy)
                {
                    Debug.Log("printeara e obj con el tag " + gameObject.tag);
                    if (gameObject.tag == "Fruta")
                    {
                        InsertTouch(1, "Seleccion a Mochila");
                    }
                    else if (gameObject.tag == "ComidaChatarra")
                    {
                        InsertTouch(2, "Seleccion a Mochila");
                    }


                }
            }
            catch (Exception e)
            {
                Debug.Log("El cuadrado no esta instanciado");
            }

            //Debug.Log("estas tocando el objeto: " + gameObject.name);
            
        }
        if (id_Actividad == 2)
        {
            InsertTouch(gameObject.GetComponent<movimiento_en_mapa>().estado_int, gameObject.GetComponent<movimiento_en_mapa>().estado);
        }
        if (id_Actividad == 6)
        {
            try {
                if (GameObject.Find("CuadradoMochila").activeInHierarchy)
                {
                    InsertTouch(gameObject.GetComponent<movimiento>().variable_muy_variable, "Seleccion a Mochila");
                }

            }
            catch (Exception e)
            {

            }
            
        }
    }


    // Start is called before the first frame update
    void Start() 
    {
        if(SceneManager.GetActiveScene().buildIndex != 2 && SceneManager.GetActiveScene().buildIndex != 1)
        {
            get(false);
            id_Actividad = SceneManager.GetActiveScene().buildIndex;
        }
        
        
    }

    // Update is called once per frame
    void Update() {
        
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
    public IEnumerator Postt(inventario_reim_class a, string extend)
    {
        yield return new WaitForSeconds(2);
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
    public IEnumerator Get(int id_usuario, int id_elemento, string extend,bool hacer_insert)
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
                //Debug.Log(www.error);
            }
            else
            {
                var result = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                if (www.isDone)
                {
                    //actual_comida = StockNotJson.cantidad;
                    if (result != "null")// con esto evitamos que dropee errores si no encuentra un resultado al hacer la consulta
                    {
                        var StockNotJson = JsonUtility.FromJson<get_cantidad>(result);
                        cantidad_obtenida_get = StockNotJson.cantidad;
                        //Debug.Log("cantidad de"+gameObject.name +" "+ StockNotJson.cantidad);
                        if (hacer_insert)
                        {
                            //Debug.Log("se hizo el get y ahora biene el insert");
                            insertElement(cantidad_obtenida_get + 1, id_elemento);
                        }
                    }

                    //Debug.Log("StockNotJson.cantidad" + StockNotJson.cantidad);
                }

            }
        }

    }
    void OnTriggerEnter2D(Collider2D a)
    {
        if (a.name == "CuadradoMochila")
        {
            
            insertElement(cantidad_obtenida_get+1,idElemento);
            Debug.Log("insertElement("+cantidad_obtenida_get + 1+", "+idElemento+");");
            
        }
    }
    public void get(bool hacer_insert)
    {
        //Debug.Log(Login.usuarios_id+" "+idElemento);
        StartCoroutine(Get(Login.usuarios_id, idElemento, "get_cantidad", hacer_insert));
    }
    public void insertar_weas_por_primera_ves()
    {
            insertElement(100, 600233);
    }
    public void comer()
    {
        Debug.Log("Entro a comer");
        
    }
    


}
