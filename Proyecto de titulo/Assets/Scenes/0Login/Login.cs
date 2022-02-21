using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[Serializable] 

public class Usuarito
{
    public int id;
    public string loginame;
    public string password;
    public string nombres;
    public string username;
}

public class Login : MonoBehaviour
{
    public InputField userInput;
    public InputField passwordInput;

    public static int usuarios_id;
    public static string usernames;
    public void login()
    {
        Usuarito usuario;
        usuario = new Usuarito();
        usuario.loginame = userInput.GetComponent<InputField>().text;
        usuario.password = passwordInput.GetComponent<InputField>().text;
        StartCoroutine(Post(usuario));
    }
    public void URL(string UrlUlearnet)
    {
        Application.OpenURL(UrlUlearnet);
    }

    public IEnumerator Post(Usuarito usuario)
    {
        string urlAPI = url_api.url+"/login/600";
        Debug.Log(urlAPI);

        var jsonData = JsonUtility.ToJson(usuario);

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
                        var usuarios = JsonUtility.FromJson<Usuarito>(result);
                        Debug.Log("Bienvenido: " + usuario.nombres);
                        Debug.Log(result);
                        usuarios_id = usuarios.id;
                        Login.usernames = userInput.GetComponent<InputField>().text;
                        SceneManager.LoadScene(1);

                    }
                }
            }
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

