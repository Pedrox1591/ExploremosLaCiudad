using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class Login_invitado : MonoBehaviour
{
    // Start is called before the first frame update
    [Serializable]
    public class pertenece
    {
        public string fecha;
        public int usuario_id;
        public string colegio_id;
        public string nivel_id;
        public string letra_id;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void get_ultimo_id_fun()
    {
        StartCoroutine(Insertar_usuario());
    }
    public IEnumerator updatear_usuario(int id)
    {
        Usuarito objeto = new Usuarito();
        objeto.id = id;
        objeto.nombres = "Guest_" + id;
        objeto.username = "Guest_" + id;
        Login.usernames = objeto.username;
        string urlAPI = url_api.url + "/invitado/updatear_usuario";
        Debug.Log(urlAPI);

        var jsonData = JsonUtility.ToJson(objeto);

        using (UnityWebRequest www = UnityWebRequest.Post(urlAPI, jsonData))
        {
            www.SetRequestHeader("content-type", "application/json");
            www.uploadHandler.contentType = "application/json";
            www.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(jsonData));
            yield return www.SendWebRequest();

            if (www.isNetworkError)
            {
                Debug.Log(www.error);
                Debug.Log("error!");
            }

            else
            {
                if (www.isDone)
                {
                    var result = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                    if (result != null)
                    {
                        //var usuarios = JsonUtility.FromJson<Usuarito>(result);
                        //Debug.Log("Bienvenido: " + usuario.nombre);
                        Debug.Log("el result es: "+result);
                        
                        //SceneManager.LoadScene(1);

                    }
                }
            }
        }
    }
    public IEnumerator Insertar_usuario()
    {
        int random = UnityEngine.Random.Range(0 ,1000);
        Usuarito objeto = new Usuarito();
        objeto.nombres = "Guest_"+random;
        objeto.username = "Guest_" + random;
        string urlAPI = url_api.url + "/invitado/insert_guest";
        Debug.Log(urlAPI);

        var jsonData = JsonUtility.ToJson(objeto);

        using (UnityWebRequest www = UnityWebRequest.Post(urlAPI, jsonData))
        {
            www.SetRequestHeader("content-type", "application/json");
            www.uploadHandler.contentType = "application/json";
            www.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(jsonData));
            yield return www.SendWebRequest();

            if (www.isNetworkError)
            {
                Debug.Log(www.error);
                Debug.Log("error!");
            }

            else
            {
                if (www.isDone)
                {
                    var result = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                    if (result != null)
                    {
                        //var usuarios = JsonUtility.FromJson<Usuarito>(result);
                        //Debug.Log("Bienvenido: " + usuario.nombre);
                        Debug.Log("el result es: " + result);
                        Login.usuarios_id = Int32.Parse(result);
                        StartCoroutine(updatear_usuario(Int32.Parse(result)));
                        StartCoroutine(Añadir_a_curso(Login.usuarios_id));
                        //SceneManager.LoadScene(1);

                    }
                }
            }
        }

    }
    public IEnumerator Añadir_a_curso(int id_guest)
    {
        pertenece objeto = new pertenece();
        objeto.fecha = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
        objeto.usuario_id = id_guest;
        objeto.colegio_id = "99";
        objeto.nivel_id ="1";
        objeto.letra_id ="2";
        string urlAPI = url_api.url + "/invitado/guest_a_colegio";
        Debug.Log(urlAPI);

        var jsonData = JsonUtility.ToJson(objeto);

        using (UnityWebRequest www = UnityWebRequest.Post(urlAPI, jsonData))
        {
            www.SetRequestHeader("content-type", "application/json");
            www.uploadHandler.contentType = "application/json";
            www.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(jsonData));
            yield return www.SendWebRequest();

            if (www.isNetworkError)
            {
                Debug.Log(www.error);
                Debug.Log("error!");
            }

            else
            {
                if (www.isDone)
                {
                    var result = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                    if (result != null)
                    {
                        Debug.Log("el result es: " + result);
                        SceneManager.LoadScene(1);

                    }
                }
            }
        }

    }
}
