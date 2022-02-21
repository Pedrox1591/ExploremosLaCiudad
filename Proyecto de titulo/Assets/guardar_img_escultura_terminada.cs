using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking;

public class guardar_img_escultura_terminada : MonoBehaviour
{
    // Start is called before the first frame update
    Vector2 tamaño_original;
    Vector3 pos_orignal;
    public GameObject Camera_1;
    public GameObject camera_2;
    guardar_img_escultura objeto = new guardar_img_escultura();
    public GameObject Escultura_terminada;
    void Start()
    {
        tamaño_original = GameObject.Find("Imagen_tomada").GetComponent<RectTransform>().sizeDelta;
        pos_orignal = GameObject.Find("Imagen_tomada").transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void screenshot()
    {
        if (GameObject.Find("script_detectar_escultura").GetComponent<Script_detectar_esculturas>().bool_checkList_boceto == true && GameObject.Find("script_detectar_escultura").GetComponent<Script_detectar_esculturas>().bool_checkList_objetos == true)
        {
            StartCoroutine(guardar_img_esculturas());
        }
        else
        {
            GameObject.Find("Pasos_para_terminar_escultura").GetComponent<Animator>().Play("Animacion_faltan_pasos");
        }

    }
    public IEnumerator guardar_img_esculturas()
    {
        Camera_1.SetActive(false);
        camera_2.SetActive(true);
        GameObject.Find("Canvas").GetComponent<Canvas>().renderMode = RenderMode.WorldSpace;
        //GameObject.Find("Cuadro_escultura").transform.localScale = new Vector3(2, 2, 2);
        /*GameObject.Find("Cuadro_escultura").GetComponent<RectTransform>().sizeDelta = new Vector2(GameObject.Find("Canvas").GetComponent<RectTransform>().sizeDelta.x, GameObject.Find("Canvas").GetComponent<RectTransform>().sizeDelta.y);
        GameObject.Find("Imagen_tomada").GetComponent<RectTransform>().sizeDelta = new Vector2(GameObject.Find("Canvas").GetComponent<RectTransform>().sizeDelta.x, GameObject.Find("Canvas").GetComponent<RectTransform>().sizeDelta.y);
        GameObject.Find("Imagen_tomada").transform.position = new Vector3(0, 0, 0);*/
        yield return new WaitForEndOfFrame();
        float width = Screen.width;
        float height = Screen.height;
        Texture2D tex = new Texture2D((int)width, (int)height, TextureFormat.RGB24, false);
        tex.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        tex.Apply();
        byte[] bytes = tex.EncodeToJPG();

        //Destroy(tex);
        Texture2D texx = new Texture2D(1, 1);
        texx.LoadImage(bytes);
        Sprite sprite = Sprite.Create(texx, new Rect(0, 0, texx.width, texx.height), new Vector2(.5f, .5f));
        //GameObject.Find("a").GetComponent<UnityEngine.UI.Image>().sprite = sprite;
        StartCoroutine(Insert_img(bytes, 20014));
        Camera_1.SetActive(true);
        camera_2.SetActive(false);
        borrar_objectos();
        GameObject.Find("Canvas").GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceCamera;
        Escultura_terminada.SetActive(true);


    }
    public void borrar_objectos()
    {
        Debug.Log("Esta entrando a borrar, el largo de la fila es: "+ instance_object_in_crea_escultura.objects_instanciados.Count);
        for (int x = 0; x < instance_object_in_crea_escultura.objects_instanciados.Count; x++)
        {
            insertElement(instance_object_in_crea_escultura.objects_instanciados[x].GetComponent<Movimiento_en_crear_esculturas>().Padre.GetComponent<instance_object_in_crea_escultura>().cantidad, instance_object_in_crea_escultura.objects_instanciados[x].GetComponent<prueba>().idElemento);
            StartCoroutine(Eliminar_objeto_instanciado(instance_object_in_crea_escultura.objects_instanciados[x]));
        }
        
    }
    public IEnumerator Eliminar_objeto_instanciado(GameObject objeto)
    {
        objeto.transform.localScale = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(2);
        Destroy(objeto);
    }
    public void salir_full_screen()
    {
        /*GameObject.Find("Imagen_tomada").GetComponent<RectTransform>().sizeDelta = tamaño_original;
        GameObject.Find("Imagen_tomada").transform.position = pos_orignal;*/
    }
    public IEnumerator Insert_img(Byte[] imagen_a_subir, int actividad_id)
    {
        guardar_img_escultura.dibujo_reim objeto = new guardar_img_escultura.dibujo_reim();
        //objeto.id_dibujo_reim = id;
        objeto.sesion_id = AsignaReimAlumno.Session;
        objeto.usuario_id = Login.usuarios_id;
        objeto.reim_id = 600;
        objeto.actividad_id = actividad_id;
        objeto.imagen = imagen_a_subir;
        //objeto.url = "hhtp/pruwb";
        //objeto.url = null;

        string urlAPI = url_api.url + "/Dibujo_reim/add";

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
                        //var StockNotJson = JsonUtility.FromJson<dibujo_reim>(result);
                        Debug.Log(result);

                    }

                }

            }

        }

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

    }
}
