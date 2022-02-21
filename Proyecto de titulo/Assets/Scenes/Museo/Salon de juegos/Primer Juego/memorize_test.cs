using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class memorize_test : MonoBehaviour
    {
    public int nivel_actual;
    List<GameObject> lista_de_cubos3x3 = new List<GameObject>();
    List<GameObject> lista_de_cubos4x4 = new List<GameObject>();
    List<GameObject> lista_de_cubos5x5 = new List<GameObject>();
    List<GameObject> lista_de_cubos6x6 = new List<GameObject>();
    List<GameObject> lista_de_cubos7x7 = new List<GameObject>();
    List<GameObject> lista_de_cubos8x8 = new List<GameObject>();
    List<GameObject> lista_de_cubos9x9 = new List<GameObject>();
    List<string> lista_de_cubos = new List<string>(){"Cuadrado (0)","Cuadrado (1)","Cuadrado (2)","Cuadrado (3)","Cuadrado (4)","Cuadrado (5)","Cuadrado (6)","Cuadrado (7)",
        "Cuadrado (8)","Cuadrado (9)","Cuadrado (10)","Cuadrado (11)","Cuadrado (12)","Cuadrado (13)","Cuadrado (14)","Cuadrado (15)","Cuadrado (16)","Cuadrado (17)","Cuadrado (18)",
        "Cuadrado (19)","Cuadrado (20)","Cuadrado (21)","Cuadrado (22)","Cuadrado (23)","Cuadrado (24)","Cuadrado (25)","Cuadrado (26)","Cuadrado (27)","Cuadrado (28)","Cuadrado (29)",
        "Cuadrado (30)","Cuadrado (31)","Cuadrado (32)","Cuadrado (33)","Cuadrado (34)","Cuadrado (35)","Cuadrado (36)","Cuadrado (37)","Cuadrado (38)","Cuadrado (39)","Cuadrado (40)",
        "Cuadrado (41)","Cuadrado (42)","Cuadrado (43)","Cuadrado (44)","Cuadrado (45)","Cuadrado (46)","Cuadrado (47)","Cuadrado (48)","Cuadrado (49)","Cuadrado (50)","Cuadrado (51)",
        "Cuadrado (52)","Cuadrado (53)","Cuadrado (54)","Cuadrado (55)","Cuadrado (56)","Cuadrado (57)","Cuadrado (58)","Cuadrado (59)","Cuadrado (60)","Cuadrado (61)","Cuadrado (62)",
        "Cuadrado (63)","Cuadrado (64)","Cuadrado (65)","Cuadrado (66)","Cuadrado (67)","Cuadrado (68)","Cuadrado (69)","Cuadrado (70)","Cuadrado (71)","Cuadrado (72)","Cuadrado (73)",
        "Cuadrado (74)","Cuadrado (75)","Cuadrado (76)","Cuadrado (77)","Cuadrado (78)","Cuadrado (79)","Cuadrado (80)","Cuadrado (81)"};
    public static List<GameObject> secuencia = new List<GameObject>(){};
    public Sprite imagenACambiar;
    public Sprite imagen_original;
    public static bool nivel_en_juego;
    public GameObject cuadrado3x3;
    public GameObject cuadrado4x4;
    public GameObject cuadrado5x5;
    public GameObject cuadrado6x6;
    public GameObject cuadrado7x7;
    public GameObject cuadrado8x8;
    public GameObject cuadrado9x9;
    GameObject Padre_a_ocupar;
    public GameObject boton_jugar;
    public GameObject haz_perdido;
    public GameObject volver_a_jugar;
    public GameObject nivel_completado;
    public GameObject GameTiempo_barra;
    public GameObject corazon1;
    public GameObject corazon2;
    public GameObject corazon3;
    public prueba_sinmov objeto;
    public Sprite corazon;
    public Sprite corazon_roto;
    public static int vidas;
    public Text texto;
    float tiempo=0.0f;
    float tiempo_espera=0.0f;
    public Image barra_De_tiempo;
    public float tiempo_maximo = 2.0f;
    float tiempo_al_final=0.0f;
    float tiempo_muerte=0.0f;
    public static string resultado_mov;
    public bool nivel_en_pre_juego;
    public static bool nivel_completado_bool;
    // Start is called before the first frame update


    void Start()
    {
        nivel_completado_bool = false;
        nivel_en_pre_juego = false;
        resultado_mov = "No aplica";
        vidas = 3;
        rellenar_listas(lista_de_cubos3x3, cuadrado3x3);
        rellenar_listas(lista_de_cubos4x4, cuadrado4x4);
        rellenar_listas(lista_de_cubos5x5, cuadrado5x5);
        rellenar_listas(lista_de_cubos6x6, cuadrado6x6);
        rellenar_listas(lista_de_cubos7x7, cuadrado7x7);
        rellenar_listas(lista_de_cubos8x8, cuadrado8x8);
        rellenar_listas(lista_de_cubos9x9, cuadrado9x9);
        nivel_en_juego = false;
        nivel_actual = 1;
        //CrearLista();
        //nivel 1 = 3x3 scuencia de 3 cubos
        //nivel 2 = 3x3 secuencia de 4 cubos
        //nivel 3 = 4x4 secuencia de 5 cubos
        //nivel 4 = 4x4 secuencia de 6 cubos
        //nivel 5 = 5x5 secuencia de 7 cubos
        //nivel 6 = 5x5 secuencia de 8 cubos
        //nivel 7 = 6x6 secuencia de 9 cubos
        //nivel 8 = 6x6 secuencia de 10 cubos
        //nivel 9 = 7x7 secuencia de 11 cubos
        //nivel 10 = 7x7 secuencia de 12 cubos
    }

    // Update is called once per frame
    void Update()
    {
        tiempo_espera = tiempo_espera+1*Time.deltaTime;
        //Debug.Log(tiempo_espera);
        if(tiempo_espera>1 && nivel_en_pre_juego== true){
            for(int x = 0;x<secuencia.Count;x++){
                (secuencia[x]).GetComponent<Image>().sprite = imagen_original;
            }
            nivel_en_juego = true;
        }
        else if(tiempo_espera>2){
            tiempo_espera=0.0f;
        }
        if(nivel_en_juego == true){
            //Debug.Log(secuencia.Count);
            tiempo_muerte = tiempo_muerte +1*Time.deltaTime;
            if(secuencia.Count==0){
                nivel_completado.SetActive(true);
                nivel_completado_bool = true;
                //Debug.Log("la lista quedo vacia");
                tiempo_al_final = tiempo_al_final + 1 * Time.deltaTime;
                if(tiempo_al_final>1 || tiempo>0){
                    GameTiempo_barra.SetActive(true);
                    nivel_terminado_volver_original();
                    tiempo = tiempo + 1 * Time.deltaTime;
                    texto.text = tiempo+"s";
                    barra_De_tiempo.fillAmount = tiempo/tiempo_maximo;
                    if(tiempo>2f){
                        //Debug.Log("entro al if que me esta dando el problema");
                        GameTiempo_barra.SetActive(false);
                        tiempo = 0.0f;
                        tiempo_al_final = 0.0f;
                        nivel_en_juego=false;
                        nivel_actual = nivel_actual+1; 
                        if(nivel_actual==3){
                        cuadrado3x3.SetActive(false);
                        cuadrado4x4.SetActive(true); 
                        }
                        if(nivel_actual==5){
                        cuadrado4x4.SetActive(false);
                        cuadrado5x5.SetActive(true); 
                        }
                        if(nivel_actual==7){
                        cuadrado5x5.SetActive(false);
                        cuadrado6x6.SetActive(true); 
                        }
                        if(nivel_actual==9){
                        cuadrado6x6.SetActive(false);
                        cuadrado7x7.SetActive(true); 
                        }
                        if(nivel_actual==11){
                        cuadrado7x7.SetActive(false);
                        cuadrado8x8.SetActive(true); 
                        }
                        if(nivel_actual==13){
                        cuadrado8x8.SetActive(false);
                        cuadrado9x9.SetActive(true); 
                        }
                        //Debug.Log("crear_lista");
                        CrearLista();
                        nivel_completado.SetActive(false);
                        nivel_completado_bool = false;
                        //Debug.Log("nivel_completado.false");

                    }
                } 
            }
                if(vidas ==3){
                    corazon1.SetActive(true);
                    corazon2.SetActive(true);
                    corazon3.SetActive(true);
                }
                else if(vidas ==2){
                    corazon1.SetActive(true);
                    corazon2.SetActive(true);
                    corazon3.SetActive(false);
                }
                else if(vidas ==1){
                    corazon1.SetActive(true);
                    corazon2.SetActive(false);
                    corazon3.SetActive(false);
                }
                else if(vidas ==0){
                    corazon1.SetActive(false);
                    corazon2.SetActive(false);
                    corazon3.SetActive(false);
                }  
        }
        if(vidas ==0 ){
            haz_perdido.SetActive(true);
            nivel_terminado_volver_original();
            volver_a_jugar.SetActive(true);
            nivel_en_juego = false;
            resultado_mov = nivel_actual.ToString();
            objeto.InsertTouch(1);
            //
        }
    }
    public void volver_a_jugarr(){
        vidas = 3;
        nivel_completado.SetActive(false);
        cuadrado3x3.SetActive(true);
        cuadrado4x4.SetActive(false);
        cuadrado5x5.SetActive(false);
        cuadrado6x6.SetActive(false);
        cuadrado7x7.SetActive(false);
        cuadrado8x8.SetActive(false);
        cuadrado9x9.SetActive(false);
        haz_perdido.SetActive(false);
        nivel_actual=1;
        CrearLista();
        volver_a_jugar.SetActive(false);
        resultado_mov = "No aplica";
    }
    void rellenar_listas(List<GameObject> a,GameObject Padre){
        a.Clear();
        for (int x = 0;x< Padre.transform.childCount; x++){
            a.Add(Padre.transform.GetChild(x).gameObject);
        }
    }
    public void CrearLista(){
        secuencia.Clear();

        cubos.volver_a_original=false;
        if(nivel_actual == 0 || nivel_actual ==1 || nivel_actual ==2){
            Debug.Log("ENTRA AL IF");
            Padre_a_ocupar = cuadrado3x3;
            for (int x = 0;x<nivel_actual+2;x++){
                int numero_random = Random.Range(0,lista_de_cubos3x3.Count);
                secuencia.Add(lista_de_cubos3x3[numero_random]);
                Debug.Log("se añade a la lista: "+lista_de_cubos[numero_random]);
                lista_de_cubos3x3[numero_random].GetComponent<Image>().sprite = imagenACambiar;
                
                lista_de_cubos3x3.RemoveAt(numero_random);
            }
            tiempo_espera = 0.0f;
            nivel_en_pre_juego = true;
            //nivel_en_juego = true;
            rellenar_listas(lista_de_cubos3x3,cuadrado3x3);
            Debug.Log("El nivel actual es: "+nivel_actual);
            boton_jugar.SetActive(false);
            
        }
        else if(nivel_actual ==3 || nivel_actual ==4){
            Debug.Log("ENTRA AL IF");
            Padre_a_ocupar = cuadrado4x4;
            for (int x = 0;x<nivel_actual+2;x++){
                int numero_random = Random.Range(0,lista_de_cubos4x4.Count);
                secuencia.Add(lista_de_cubos4x4[numero_random]);
                Debug.Log("se añade a la lista: "+lista_de_cubos[numero_random]);
                (lista_de_cubos4x4[numero_random]).GetComponent<Image>().sprite = imagenACambiar;
                
                lista_de_cubos4x4.RemoveAt(numero_random);
            }
            tiempo_espera=0.0f;
            nivel_en_pre_juego = true;
            //nivel_en_juego =true;
            rellenar_listas(lista_de_cubos4x4,cuadrado4x4);
        }
        else if(nivel_actual ==5 || nivel_actual ==6){
            Debug.Log("ENTRA AL IF");
            Padre_a_ocupar = cuadrado5x5;
            for (int x = 0;x<nivel_actual+2;x++){
                int numero_random = Random.Range(0,lista_de_cubos5x5.Count);
                secuencia.Add(lista_de_cubos5x5[numero_random]);
                Debug.Log("se añade a la lista: "+lista_de_cubos[numero_random]);
                (lista_de_cubos5x5[numero_random]).GetComponent<Image>().sprite = imagenACambiar;
                
                lista_de_cubos5x5.RemoveAt(numero_random);
            }
            tiempo_espera=0.0f;
            nivel_en_pre_juego = true;
            //nivel_en_juego = true;
            rellenar_listas(lista_de_cubos5x5,cuadrado5x5);
        }
        else if(nivel_actual ==7 || nivel_actual ==8){
            Debug.Log("ENTRA AL IF");
            Padre_a_ocupar = cuadrado6x6;
            for (int x = 0;x<nivel_actual+2;x++){
                int numero_random = Random.Range(0,lista_de_cubos6x6.Count);
                secuencia.Add(lista_de_cubos6x6[numero_random]);
                Debug.Log("se añade a la lista: "+lista_de_cubos[numero_random]);
                lista_de_cubos6x6[numero_random].GetComponent<Image>().sprite = imagenACambiar;
                
                lista_de_cubos6x6.RemoveAt(numero_random);
            }
            tiempo_espera=0.0f;
            nivel_en_pre_juego = true;
            //nivel_en_juego = true;
            rellenar_listas(lista_de_cubos6x6,cuadrado6x6);
        }
        else if(nivel_actual ==9 || nivel_actual ==10){
            Debug.Log("ENTRA AL IF");
            Padre_a_ocupar = cuadrado7x7;
            for (int x = 0;x<nivel_actual+2;x++){
                int numero_random = Random.Range(0,lista_de_cubos7x7.Count);
                secuencia.Add(lista_de_cubos7x7[numero_random]);
                Debug.Log("se añade a la lista: "+lista_de_cubos[numero_random]);
                (lista_de_cubos7x7[numero_random]).GetComponent<Image>().sprite = imagenACambiar;
                                lista_de_cubos7x7.RemoveAt(numero_random);
            }
            tiempo_espera=0.0f;
            nivel_en_pre_juego = true;
            //nivel_en_juego = true;
            rellenar_listas(lista_de_cubos7x7,cuadrado7x7);
        }
        else if(nivel_actual ==11 || nivel_actual ==12){
            Debug.Log("ENTRA AL IF");
            Padre_a_ocupar = cuadrado8x8;
            for (int x = 0;x<nivel_actual+2;x++){
                int numero_random = Random.Range(0,lista_de_cubos8x8.Count);
                secuencia.Add(lista_de_cubos8x8[numero_random]);
                Debug.Log("se añade a la lista: "+lista_de_cubos[numero_random]);
                (lista_de_cubos8x8[numero_random]).GetComponent<Image>().sprite = imagenACambiar;
                
                lista_de_cubos8x8.RemoveAt(numero_random);
            }
            tiempo_espera=0.0f;
            nivel_en_pre_juego = true;
            //nivel_en_juego = true;
            rellenar_listas(lista_de_cubos8x8,cuadrado8x8);
        }
        else if(nivel_actual ==13 || nivel_actual ==14){
            Debug.Log("ENTRA AL IF");
            Padre_a_ocupar = cuadrado9x9;
            for (int x = 0;x<nivel_actual+2;x++){
                int numero_random = Random.Range(0,lista_de_cubos9x9.Count);
                secuencia.Add(lista_de_cubos9x9[numero_random]);
                Debug.Log("se añade a la lista: "+lista_de_cubos[numero_random]);
                (lista_de_cubos9x9[numero_random]).GetComponent<Image>().sprite = imagenACambiar;
                
                lista_de_cubos9x9.RemoveAt(numero_random);
            }
            tiempo_espera=0.0f;
            nivel_en_pre_juego = true;
            //nivel_en_juego = true;
            rellenar_listas(lista_de_cubos9x9,cuadrado9x9);
        }

    }
    void nivel_terminado_volver_original()
    {

        for (int x = 0; x < Padre_a_ocupar.transform.childCount; x++)
        {
            (Padre_a_ocupar.transform.GetChild(x).gameObject).GetComponent<Image>().sprite = imagen_original;
        }
    }
}
