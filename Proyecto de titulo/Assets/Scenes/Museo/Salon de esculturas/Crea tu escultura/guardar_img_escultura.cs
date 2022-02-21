using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;
using System.IO;
using System.Drawing;

public class guardar_img_escultura : MonoBehaviour

{
    [Serializable]
    public class dibujo_reim
    {
        public int id_dibujo_reim;
        public string sesion_id;
        public int usuario_id;
        public int reim_id;
        public int actividad_id;
        public Byte[] imagen;
        public string url;
        //public string url;

    }
    
    WaitForEndOfFrame frameEnd = new WaitForEndOfFrame();
    // Start is called before the first frame update
    public GameObject boton_listo;
    public GameObject boton_X;
    public GameObject undo;
    public GameObject cuadro_blanco;

    


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void guardar_img_boceto()
    {
        GameObject.Find("script_detectar_escultura").GetComponent<Script_detectar_esculturas>().funcheckList_boceto();
        StartCoroutine(TakeSnapshot(20016));

    }


    public IEnumerator TakeSnapshot(int actividad_id)
    {
        boton_listo.SetActive(false);
        boton_X.SetActive(false);
        undo.SetActive(false);
        yield return frameEnd;
        int  width = Screen.width;
        int height = Screen.height;

        Debug.Log(10+" "+Screen.height);
        Texture2D tex = new Texture2D(width,height, TextureFormat.RGB24, false);

        // Read screen contents into the texture
        tex.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        tex.Apply();
        

        // Encode texture into PNG
        byte[] bytes = tex.EncodeToJPG();
        
        //Destroy(tex);
        Texture2D texx = new Texture2D(1, 1);
        texx.LoadImage(bytes);
        Sprite sprite = Sprite.Create(texx, new Rect(0, 0, texx.width, texx.height), new Vector2(.5f, .5f));
        GameObject.Find("Imagen_tomada").GetComponent<UnityEngine.UI.Image>().sprite = sprite;
        boton_listo.SetActive(true);
        boton_X.SetActive(true);
        undo.SetActive(true);
        //Debug.Log(tex.EncodeToPNG().Length+" "+ tex.EncodeToJPG().Length+" "+ tex.EncodeToTGA().Length);
        //Bitmap objBitmap = new Bitmap("Imagen", new Size(227, 171));



        // gameObject.renderer.material.mainTexture = TakeSnapshot;
        hacer_insert_img(bytes,20016);
    }
    public void hacer_insert_img(Byte[] imagen_a_subir, int actividad_id)
    {
        StartCoroutine(Insert_img(imagen_a_subir, actividad_id));
    }
    public IEnumerator Insert_img(Byte[] imagen_a_subir, int actividad_id)
    {
        dibujo_reim objeto = new dibujo_reim();
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
                        GameObject.Find("Cuadrados de bosetos").GetComponent<DibujosEstudiantes>().obtener_img_base_de_datos(1);
                        cuadro_blanco.SetActive(false);


                        }

                    }

                }

            }

        }
   





}
