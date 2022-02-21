using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Networking;
using Newtonsoft.Json;
using System.Linq;

[Serializable]

public class Emociones_id {
    public int id_dibujo_reim;
}
public class put_reaccion_dibujo {
    public int idreaccion;
    public int iddibujo;
    public int idusuario;
    public string fecha;
}
public class MostrarEsculturas : MonoBehaviour
{
    
    // Start is called before the first frame update
    public GameObject carril_dibujo;
    public List<GameObject> lista_de_cubos_para_las_img = new List<GameObject>();
    public List<GameObject> lista_imagenes_bd = new List<GameObject>();
    public GameObject objeto_a_instanciar;
    public List<DibujosEstudiantes.Root> lista_de_clases = new List<DibujosEstudiantes.Root>();
    public List<DibujosEstudiantes.EmocionesList> lista_de_emociones = new List<DibujosEstudiantes.EmocionesList>();
    public Text Alegria_text;
    public Text Tristeza_tex;
    public Text Desagrado_tex;
    public Text Enojo_tex;
    public Text Temor_tex;
    public Text texto;
    bool primera_img;
    //public GameObject emociones;
    int puesto_actual;
    void Start()
    {
        primera_img = false;
        StartCoroutine(get_img_bd(0, 20014));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void agregar_cuadrado_para_la_posicion(int cantidad_a_repetir)
    {
        for (int x = 0; x < cantidad_a_repetir; x++)
        {
            
            //carril_dibujo.GetComponent<RectTransform>().sizeDelta = new Vector2(carril_dibujo.GetComponent<RectTransform>().sizeDelta.x + 250, carril_dibujo.GetComponent<RectTransform>().sizeDelta.y);
            GameObject copia_basura = lista_de_cubos_para_las_img[lista_de_cubos_para_las_img.Count - 1];
            GameObject nuevo_cubo_basura = Instantiate(copia_basura, carril_dibujo.transform);
            nuevo_cubo_basura.name = "Cuadrado (" + ((int)lista_de_cubos_para_las_img.Count + 1) + ")";
            //nuevo_cubo_basura.transform.localPosition = new Vector3(nuevo_cubo_basura.transform.localPosition.x - 250, nuevo_cubo_basura.transform.localPosition.y, nuevo_cubo_basura.transform.localPosition.z);
            lista_de_cubos_para_las_img.Add(nuevo_cubo_basura);
        }

    }
    public IEnumerator get_img_bd(int opc, int actividad_id)
    {
        DibujosEstudiantes.Obtener_Dibujo_Reim objeto = new DibujosEstudiantes.Obtener_Dibujo_Reim();
        //objeto.id_dibujo_reim = id;

        //objeto.usuario_id = Login.usuarios_id;
        objeto.reim_id = 600;
        objeto.actividad_id = actividad_id;
        

        //objeto.url = "hhtp/pruwb";
        //objeto.url = null;

        string urlAPI = url_api.url + "/Dibujo_reim/getAprobados";

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
                Debug.Log("result:" + result);
                if (www.isDone)
                {
                    if (result != "null")// con esto evitamos que dropee errores si no encuentra un resultado al hacer la consulta
                    {
                        if (opc == 0)
                        {
                            var moduleInfo = JsonConvert.DeserializeObject<List<DibujosEstudiantes.Root>>(result);
                            //var groupedModuleInfo = moduleInfo.GroupBy(m => m.ID).ToArray();
                            //var groupedJson = JsonConvert.SerializeObject(groupedModuleInfo);
                            Debug.Log("Largo: " + moduleInfo.Count);
                            Debug.Log(moduleInfo[0].usuario_id);
                            //agregar_cuadrado_para_la_posicion(moduleInfo.Count-1);
                            for (int x = 0; x < moduleInfo.Count; x++)
                            {

                                Texture2D texx = new Texture2D(1000, 1000);


                                texx.LoadImage(moduleInfo[x].imagen.data);
                                Sprite sprite = Sprite.Create(texx, new Rect(0, 0, texx.width, texx.height), new Vector2(.5f, .5f));
                                lista_de_clases.Add(moduleInfo[x]);
                                StartCoroutine(get_reacciones_de_imagenes(moduleInfo[x]));
                                /*GameObject nuevo_objeto = objeto_a_instanciar;
                                nuevo_objeto.GetComponent<Image>().sprite = sprite;
                                lista_imagenes_bd.Add(nuevo_objeto);
                                GameObject objeto_instanciado = Instantiate(nuevo_objeto);
                                objeto_instanciado.transform.SetParent(carril_dibujo.transform);
                                objeto_instanciado.transform.localPosition = new Vector3(lista_de_cubos_para_las_img[x].transform.localPosition.x, lista_de_cubos_para_las_img[x].transform.localPosition.y, lista_de_cubos_para_las_img[x].transform.localPosition.z + 2);
                                objeto_instanciado.transform.localScale = new Vector3(2, 2, 2);
                                objeto_instanciado.AddComponent<DetectarObjetoClickeado>();
                                objeto_instanciado.tag = "escultura";*/

                                /*lista_de_cubos_para_las_img[x].GetComponent<Image>().sprite = sprite;
                                lista_de_cubos_para_las_img[x].transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<Text>().text = "Autor: " + moduleInfo[x].nombres;*/
                                //Debug.Log("el papa: "+ lista_de_cubos_para_las_img[x]+" el hijo: "+ lista_de_cubos_para_las_img[x].transform.GetChild(0).name+" el hijo de su hijo: "+ lista_de_cubos_para_las_img[x].transform.GetChild(0).gameObject.transform.GetChild(0).name+" El nombre deberia ser: "+ moduleInfo[x].nombres);
                            }
                        }
                        /*if (opc == 1)
                        {
                            var moduleInfo = JsonConvert.DeserializeObject<List<DibujosEstudiantes.Root>>(result);
                            agregar_cuadrado_para_la_posicion(1);
                            Texture2D texx = new Texture2D(1000, 1000);


                            texx.LoadImage(moduleInfo[moduleInfo.Count - 1].imagen.data);
                            Sprite sprite = Sprite.Create(texx, new Rect(0, 0, texx.width, texx.height), new Vector2(.5f, .5f));
                            GameObject nuevo_objeto = objeto_a_instanciar;
                            nuevo_objeto.GetComponent<Image>().sprite = sprite;
                            lista_imagenes_bd.Add(nuevo_objeto);
                            GameObject objeto_instanciado = Instantiate(nuevo_objeto);
                            objeto_instanciado.transform.SetParent(carril_dibujo.transform);
                            //objeto_instanciado.transform.localPosition = lista_de_cubos_para_las_img[lista_de_cubos_para_las_img.Count-1].transform.localPosition;
                            objeto_instanciado.transform.localPosition = new Vector3(lista_de_cubos_para_las_img[lista_de_cubos_para_las_img.Count - 1].transform.localPosition.x, lista_de_cubos_para_las_img[lista_de_cubos_para_las_img.Count - 1].transform.localPosition.y, lista_de_cubos_para_las_img[lista_de_cubos_para_las_img.Count - 1].transform.localPosition.z + 2);
                            objeto_instanciado.transform.localScale = new Vector3(2, 2, 2);
                            objeto_instanciado.AddComponent<DetectarObjetoClickeado>();
                            objeto_instanciado.transform.localScale = new Vector3(2, 2, 2);
                            objeto_instanciado.tag = "Boceto";
                        }*/



                        //var StockNotJson = JsonUtility.FromJson<dibujo_reim>(result);


                    }


                }
                

            }

        }

    }

    void primera_escultura()
    {
        Texture2D texx = new Texture2D(1000, 1000);


        texx.LoadImage(lista_de_clases[0].imagen.data);
        Sprite sprite = Sprite.Create(texx, new Rect(0, 0, texx.width, texx.height), new Vector2(.5f, .5f));
        gameObject.GetComponent<Image>().sprite = sprite;
        texto.text = "" + lista_de_clases[0].nombres;
        //Debug.Log("emojis.transform.childCount: " + emojis.transform.childCount);
        Debug.Log("lista_de_emociones: "+ lista_de_emociones.Count);
            Alegria_text.text = "" + lista_de_emociones[0].Alegria;
            Tristeza_tex.text = "" + lista_de_emociones[0].Tristeza;
            Desagrado_tex.text = "" + lista_de_emociones[0].Desagrado;
            Enojo_tex.text = "" + lista_de_emociones[0].Enojo;
            Temor_tex.text= "" + lista_de_emociones[0].Temor;
        
        puesto_actual = 0;
    }
    public void cambiar_de_imagen(int numero)
    {
        if (puesto_actual+numero>=0 && puesto_actual+numero<lista_de_clases.Count)
        {
            puesto_actual = puesto_actual + numero;
            Texture2D texx = new Texture2D(1000, 1000);
            texx.LoadImage(lista_de_clases[puesto_actual].imagen.data);
            Sprite sprite = Sprite.Create(texx, new Rect(0, 0, texx.width, texx.height), new Vector2(.5f, .5f));
            gameObject.GetComponent<Image>().sprite = sprite;
            texto.text = "" + lista_de_clases[puesto_actual].nombres;
            Alegria_text.text = "" + lista_de_emociones[puesto_actual].Alegria;
            Tristeza_tex.text = "" + lista_de_emociones[puesto_actual].Tristeza;
            Desagrado_tex.text = "" + lista_de_emociones[puesto_actual].Desagrado;
            Enojo_tex.text = "" + lista_de_emociones[puesto_actual].Enojo;
            Temor_tex.text = "" + lista_de_emociones[puesto_actual].Temor;
        }
        else
        {
            Debug.Log("Ya llegaste al final o al inicio");
        }
    }
    public IEnumerator get_reacciones_de_imagenes(DibujosEstudiantes.Root clase)

    {
        Emociones_id objeto = new Emociones_id();
        //objeto.id_dibujo_reim = id;

        objeto.id_dibujo_reim = clase.id_dibujo_reim;
        


        //objeto.url = "hhtp/pruwb";
        //objeto.url = null;

        string urlAPI = url_api.url + "/Reaccion_dibujo/get_reacciones";

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
                Debug.Log("result:" + result+" con el id: "+ objeto.id_dibujo_reim);
                if (www.isDone)
                {
                    if (result != "null")// con esto evitamos que dropee errores si no encuentra un resultado al hacer la consulta
                    {

                        var cantidad = JsonConvert.DeserializeObject<List<DibujosEstudiantes.EmocionesList>>(result);
                        Debug.Log(" cantidad[0].Tristeza: " + cantidad[0].Tristeza);
                        lista_de_emociones.Add(cantidad[0]);
                        if(primera_img == false)
                        {
                            primera_img = true;
                            primera_escultura();

                        }
                        /*clase.emociones.Tristeza = cantidad[0].Tristeza;
                        clase.emociones.Alegria = cantidad[0].Alegria;
                        clase.emociones.Desagrado = cantidad[0].Desagrado;
                        clase.emociones.Temor = cantidad[0].Temor;
                        clase.emociones.Enojo = cantidad[0].Enojo;
                        Debug.Log(":clase.emociones.Tristesa "+ clase.emociones.Tristeza + ": "+ clase.emociones.Alegria + ": clase.emociones.Desagrado = cantidad.Desagrado; " + clase.emociones.Desagrado);*/

                    }
                }
                

            }

        }

    }
    public void reaccionar_imagen(int id_reaccion)
    {
        StartCoroutine(put_reaccionar_img(id_reaccion));
    }
    public IEnumerator put_reaccionar_img(int id_reaccion)    
    {
        if (id_reaccion == 1)
        {
            GameObject.Find("Tristeza").transform.GetChild(0).GetComponent<Text>().text = (int.Parse(GameObject.Find("Tristeza").transform.GetChild(0).GetComponent<Text>().text) + 1)+"";
        }
        else if (id_reaccion == 2)
        {
            GameObject.Find("Alegria").transform.GetChild(0).GetComponent<Text>().text = (int.Parse(GameObject.Find("Alegria").transform.GetChild(0).GetComponent<Text>().text) + 1) + "";
        }
        else if (id_reaccion == 3)
        {
            GameObject.Find("desagrado").transform.GetChild(0).GetComponent<Text>().text = (int.Parse(GameObject.Find("desagrado").transform.GetChild(0).GetComponent<Text>().text) + 1) + "";
        }
        else if (id_reaccion == 4)
        {
            GameObject.Find("Miedo").transform.GetChild(0).GetComponent<Text>().text = (int.Parse(GameObject.Find("Miedo").transform.GetChild(0).GetComponent<Text>().text) + 1) + "";
        }
        else if (id_reaccion == 5)
        {
            GameObject.Find("Enojo").transform.GetChild(0).GetComponent<Text>().text = (int.Parse(GameObject.Find("Enojo").transform.GetChild(0).GetComponent<Text>().text) + 1) + "";
        }

        put_reaccion_dibujo objeto = new put_reaccion_dibujo();
        objeto.idreaccion = id_reaccion;
        objeto.iddibujo = lista_de_clases[puesto_actual].id_dibujo_reim;
        objeto.idusuario = Login.usuarios_id;
        objeto.fecha = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"); ;
        string urlAPI = url_api.url + "/Reaccion_dibujo/add";

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
                if (www.isDone)
                {
                    if (result != "null")
                    {

                    }
                }


            }

        }

    }
}
