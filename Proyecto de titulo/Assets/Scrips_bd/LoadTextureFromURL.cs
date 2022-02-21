using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(UnityEngine.UI.Image))]




public class LoadTextureFromURL : MonoBehaviour
{
    //UnityEngine.UI.Image _img;
    List<String>  lista_imagenes = new List<String>();

    void Start()
    {
        
        //_img = GetComponent<UnityEngine.UI.Image>();
        
    }

    public void Download(string url)
    {
        StartCoroutine(LoadFromWeb(url));
    }

    IEnumerator LoadFromWeb(string url)
    {
        UnityWebRequest wr = new UnityWebRequest(url);
        DownloadHandlerTexture texDl = new DownloadHandlerTexture(true);
        wr.downloadHandler = texDl;
        yield return wr.Send();
        if (wr.result == UnityWebRequest.Result.ConnectionError)
        {
            Texture2D t = texDl.texture;
            Sprite s = Sprite.Create(t, new Rect(0, 0, t.width, t.height),
                                     Vector2.zero, 1f);
            //lista_imagenes.Add(s);
        }
    }
    

}
