using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class basura_aleatoria_mapa : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> Lista_de_posiciones_de_basura = new List<GameObject>();
    public List<GameObject> basura = new List<GameObject>();
   /* public GameObject botella_de_vidrio;
    public GameObject botella_de_vidrio_amarilla;
    public GameObject botella_rota;
    public GameObject botella_verde;
    public GameObject botella_de_leche;
    public GameObject copa_roja;
    public GameObject vaso_roto;
    public GameObject vaso_roto_2;
    public GameObject vaso_roto_3;
    public GameObject vaso_grande_roto;
    public GameObject botella_de_plastico;
    public GameObject caja_de_jugo;
    public GameObject discos_cd;
    public GameObject envase_de_yogurth;
    public GameObject envases_de_detergentes;
    public GameObject peineta;
    public GameObject tapas_de_plastico;
    public GameObject vaso_de_cafe;
    public GameObject vaso_de_refesco;
    public GameObject vaso_de_plastico;*/
    Sprite sprite;
    public Transform pos_padre;
    void Start()
    {
        for(int x = 0; x < 33; x++)
        {
            //Debug.Log("GameObject.Find(spawn (" + x + ") ).GetComponent<Transform>())");
            Lista_de_posiciones_de_basura.Add(GameObject.Find("spawn (" + x + ")"));
            Destroy(Lista_de_posiciones_de_basura[x].GetComponent<SpriteRenderer>());
        }
        /*basura.Add(botella_de_vidrio);
        basura.Add(botella_de_vidrio_amarilla);
        basura.Add(botella_rota);
        basura.Add(botella_verde);
        basura.Add(botella_de_leche);
        basura.Add(copa_roja);
        basura.Add(vaso_roto);
        basura.Add(vaso_roto_2);
        basura.Add(vaso_roto_3);
        basura.Add(vaso_grande_roto);
        basura.Add(botella_de_plastico);
        basura.Add(caja_de_jugo);
        basura.Add(discos_cd);
        basura.Add(envase_de_yogurth);
        basura.Add(envases_de_detergentes);
        basura.Add(peineta);
        basura.Add(tapas_de_plastico);
        basura.Add(vaso_de_cafe);
        basura.Add(vaso_de_refesco);
        basura.Add(vaso_de_plastico);*/
        for(int x = 0; x < 20; x++)
        {
            generar_basura();
        }
        



    }
    void generar_basura()
    {
        int numero_random_basura = Random.Range(0, basura.Count);
        int numero_random_puestos = Random.Range(0,Lista_de_posiciones_de_basura.Count);
        GameObject A = Instantiate(basura[numero_random_basura], pos_padre);
        
        Destroy(A.GetComponent<Button>());
        Destroy(A.GetComponent<InstanceObject_in_map>());
        A.tag = A.tag + "EnMapa";
        sprite = A.GetComponent<Image>().sprite;
        Image pa_borrar = A.GetComponent<Image>();
        Destroy(pa_borrar);
        A.AddComponent<SpriteRenderer>().sprite = sprite;
        A.transform.localScale = new Vector3(A.transform.localScale.x*0.15f, A.transform.localScale.y * 0.15f, 0);

        A.transform.position = Lista_de_posiciones_de_basura[numero_random_puestos].transform.position;
        Lista_de_posiciones_de_basura.RemoveAt(numero_random_puestos);
        basura.RemoveAt(numero_random_basura);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
