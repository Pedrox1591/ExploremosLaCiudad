using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class video_reproducido : MonoBehaviour
{
    //public Vector3 posicion_original;
    //public List<GameObject> lista_objetos = new List<GameObject>();
    public GameObject slider_gris;
    
    //public AnimationClip a;
    // Start is called before the first frame update
    void Start()
    {
        //posicion_original = gameObject.transform.localPosition;
        //gameObject.AddComponent<Animation>().AddClip(a,"a");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*public void cerrar_videos()
    {
        for (int x = 0; x < lista_objetos.Count; x++)
        {
            lista_objetos[x].GetComponent<Transform>().localPosition = lista_objetos[x].GetComponent<video_reproducido>().posicion_original;
            lista_objetos[x].GetComponent<Transform>().localScale = new Vector3(0, 0, 0);
            lista_objetos[x].GetComponentInChildren<VideoPlayer>().Stop();
        }
    }
    public void al_hacer_click(){
        cerrar_videos();
        Debug.Log("si entra a la wea");
        gameObject.GetComponent<Animation>().Play("a");
        StartCoroutine(reproducir_video());
    }*/
    /*public IEnumerator reproducir_video()
    {
        yield return new WaitForSeconds(1);
        gameObject.GetComponentInChildren<VideoPlayer>().Play();
    }*/
    public void reproducir_video(VideoClip video)
    {
        slider_gris.SetActive(false);
        GetComponent<VideoPlayer>().clip = video;
        GetComponent<VideoPlayer>().Play();
    }
}
