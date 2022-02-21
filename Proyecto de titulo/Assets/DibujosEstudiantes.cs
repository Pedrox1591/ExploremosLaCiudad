using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Networking;
using Newtonsoft.Json;
using System.Linq;

public class DibujosEstudiantes : MonoBehaviour
{

    [Serializable]
    public class Obtener_Dibujo_Reim
    {
        public int usuario_id;
        public int reim_id;
        public int actividad_id;
        public string nombres;
        
        //public string url;

    }
    public class Imagen
    {
        public string type { get; set; }
        public byte[] data { get; set; }
    }
    public class EmocionesList
    {
        public int id_dibujo_reim { get; set; }
        public int Tristeza { get; set; }
        public int Alegria { get; set; }
        public int Desagrado { get; set; }
        public int Temor { get; set; }
        public int Enojo { get; set; }

    }
    public class Root
    {
        public int id_dibujo_reim { get; set; }
        public int usuario_id { get; set; }
        public Imagen imagen { get; set; }
        public string nombres { get; set; }
        //public EmocionesList emociones { get; set; }

        public object ID { get; internal set; }
    }





    // Start is called before the first frame update
    public List<GameObject> lista_de_cubos_para_las_img = new List<GameObject>();
    public List<GameObject> lista_imagenes_locales = new List<GameObject>();
    public List<GameObject> lista_imagenes_bd = new List<GameObject>();
    public GameObject carril_dibujo;
    public GameObject Contend;
    public GameObject objeto_a_instanciar;
    void Start()
    {
        agregar_cuadrado_para_la_posicion(lista_imagenes_locales.Count-1);

        
        for(int x=0;x<lista_imagenes_locales.Count; x++)
        {
            GameObject objeto_instanciado = Instantiate(lista_imagenes_locales[x]);
            objeto_instanciado.transform.SetParent(carril_dibujo.transform);
            objeto_instanciado.transform.localPosition = new Vector3(lista_de_cubos_para_las_img[x].transform.localPosition.x, lista_de_cubos_para_las_img[x].transform.localPosition.y, lista_de_cubos_para_las_img[x].transform.localPosition.z+2);
            Debug.Log("lista_de_cubos_para_las_img[x]: " + lista_de_cubos_para_las_img[x].name);
            objeto_instanciado.transform.localScale = new Vector3(2,2,2);
            objeto_instanciado.AddComponent<DetectarObjetoClickeado>();
            objeto_instanciado.tag = "Boceto";

        }
        Debug.Log("Imagenes obtenidas_por_la_bd");
        obtener_img_base_de_datos(0);
    }
    public void agregar_cuadrado_para_la_posicion(int cantidad_a_repetir)
    {
        for (int x = 0; x < cantidad_a_repetir; x++)
        {
            Contend.GetComponent<RectTransform>().sizeDelta = new Vector2(Contend.GetComponent<RectTransform>().sizeDelta.x + 250, Contend.GetComponent<RectTransform>().sizeDelta.y);
            //carril_dibujo.GetComponent<RectTransform>().sizeDelta = new Vector2(carril_dibujo.GetComponent<RectTransform>().sizeDelta.x + 250, carril_dibujo.GetComponent<RectTransform>().sizeDelta.y);
            GameObject copia_basura = lista_de_cubos_para_las_img[lista_de_cubos_para_las_img.Count - 1];
            GameObject nuevo_cubo_basura = Instantiate(copia_basura, carril_dibujo.transform);
            nuevo_cubo_basura.name = "Cuadrado (" + ((int)lista_de_cubos_para_las_img.Count + 1) + ")";
            nuevo_cubo_basura.transform.localPosition = new Vector3(nuevo_cubo_basura.transform.localPosition.x - 250, nuevo_cubo_basura.transform.localPosition.y, nuevo_cubo_basura.transform.localPosition.z);
            lista_de_cubos_para_las_img.Add(nuevo_cubo_basura);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void obtener_img_base_de_datos(int opc)
    {
        StartCoroutine(get_img_bd(opc,20016));
    }
    public IEnumerator get_img_bd(int opc,int actividad_id)
    {
        Obtener_Dibujo_Reim objeto = new Obtener_Dibujo_Reim();
        //objeto.id_dibujo_reim = id;
        
        objeto.usuario_id = Login.usuarios_id;
        objeto.reim_id = 600;
        objeto.actividad_id = actividad_id;
        
        //objeto.url = "hhtp/pruwb";
        //objeto.url = null;

        string urlAPI = url_api.url + "/Dibujo_reim/getxusuario";

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
                Debug.Log("result:" +result);
                if (www.isDone)
                {
                    if (result != "null")// con esto evitamos que dropee errores si no encuentra un resultado al hacer la consulta
                    {
                        if(opc == 0)
                        {
                            var moduleInfo = JsonConvert.DeserializeObject<List<Root>>(result);
                            //var groupedModuleInfo = moduleInfo.GroupBy(m => m.ID).ToArray();
                            //var groupedJson = JsonConvert.SerializeObject(groupedModuleInfo);
                            Debug.Log("Largo: " + moduleInfo.Count);
                            Debug.Log(moduleInfo[0].usuario_id);
                            agregar_cuadrado_para_la_posicion(moduleInfo.Count);
                            for (int x = 0; x < moduleInfo.Count; x++)
                            {

                                Texture2D texx = new Texture2D(1000, 1000);


                                texx.LoadImage(moduleInfo[x].imagen.data);
                                Sprite sprite = Sprite.Create(texx, new Rect(0, 0, texx.width, texx.height), new Vector2(.5f, .5f));
                                GameObject nuevo_objeto = objeto_a_instanciar;
                                nuevo_objeto.GetComponent<Image>().sprite = sprite;
                                lista_imagenes_bd.Add(nuevo_objeto);
                                GameObject objeto_instanciado = Instantiate(nuevo_objeto);
                                objeto_instanciado.transform.SetParent(carril_dibujo.transform);
                                objeto_instanciado.transform.localPosition = new Vector3(lista_de_cubos_para_las_img[x + 4].transform.localPosition.x, lista_de_cubos_para_las_img[x + 4].transform.localPosition.y, lista_de_cubos_para_las_img[x + 4].transform.localPosition.z + 2);
                                objeto_instanciado.transform.localScale = new Vector3(2, 2, 2);
                                objeto_instanciado.AddComponent<DetectarObjetoClickeado>();
                                objeto_instanciado.tag = "Boceto";
                            }
                        }
                        if(opc == 1)
                        {
                            var moduleInfo = JsonConvert.DeserializeObject<List<Root>>(result);
                            agregar_cuadrado_para_la_posicion(1);
                            Texture2D texx = new Texture2D(1000, 1000);


                            texx.LoadImage(moduleInfo[moduleInfo.Count-1].imagen.data);
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
                        }
                        


                        //var StockNotJson = JsonUtility.FromJson<dibujo_reim>(result);


                    }

                }

            }

        }

    }
}
