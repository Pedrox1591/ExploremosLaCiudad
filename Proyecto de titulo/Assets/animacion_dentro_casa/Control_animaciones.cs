using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control_animaciones : MonoBehaviour
{
    public List<GameObject> frutas_reciclables = new List<GameObject>();
    public GameObject botella;
    public GameObject fruta_seleccionada;
    public GameObject Posicion_para_comer_fruta;
    public AudioClip audio_comer;
    public AudioClip Audio_beber;
    public AudioSource audio_source;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void animar()
    {
        int numero_random = Random.Range(0, frutas_reciclables.Count);
        fruta_seleccionada = frutas_reciclables[numero_random];
        fruta_seleccionada.transform.localPosition = Posicion_para_comer_fruta.transform.localPosition;
        StartCoroutine(animaciones());
    }
    public IEnumerator animaciones()
    {
        GetComponent<Animator>().Play("caminar_a_cocina");
        yield return new WaitForSeconds(7);
        
        fruta_seleccionada.GetComponent<Animator>().Play("mover_comida");
        yield return new WaitForSeconds(1);
        sonidos(audio_comer);
        yield return new WaitForSeconds(3);
        botella.GetComponent<Animator>().Play("mover_comida");
        yield return new WaitForSeconds(1);
        sonidos(Audio_beber);
        yield return new WaitForSeconds(4);

        fruta_seleccionada.SetActive(true);
        botella.SetActive(true);
        fruta_seleccionada.transform.localPosition = fruta_seleccionada.GetComponent<movimiento_frutas>().pos_original.localPosition;
        
        botella.transform.localPosition = botella.GetComponent<movimiento_frutas>().pos_original.localPosition;
    }
    public void sonidos(AudioClip sonido)
    {
        //AudioClip sonido_instanciado = Instantiate(sonido);
        audio_source.clip = sonido;
        audio_source.Play();

        //Destroy(sonido_instanciado);
    }

}
