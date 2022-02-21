using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class memorize_test_secuencial : MonoBehaviour
{
    
    public int nivel_actual;
    public List<GameObject> secuencia_memorize_numeros_a_limpiar = new List<GameObject>() { };
    public List<GameObject> secuencia_memorize3x3 = new List<GameObject>(){};
    public List<GameObject> secuencia_memorize4x4 = new List<GameObject>() { };
    public List<GameObject> secuencia_memorize5x5 = new List<GameObject>() { };
    public List<GameObject> secuencia_memorize6x6 = new List<GameObject>() { };
    public List<GameObject> secuencia_memorize7x7 = new List<GameObject>() { };
    public List<GameObject> secuencia_memorize8x8 = new List<GameObject>() { };
    public List<GameObject> secuencia_memorize9x9 = new List<GameObject>() { };
    public static List<GameObject> secuencia_memorize_copia = new List<GameObject>(){};
    public Sprite imagenACambiar;
    public Sprite imagen_original;
    public static bool nivel_en_juego;
    bool nivel_en_proceso;
    public GameObject cuadrado3x3;
    public GameObject cuadrado4x4;
    public GameObject cuadrado5x5;
    public GameObject cuadrado6x6;
    public GameObject cuadrado7x7;
    public GameObject cuadrado8x8;
    public GameObject cuadrado9x9;
    public GameObject boton_jugar;
    public GameObject haz_perdido;
    public GameObject volver_a_jugar;
    public GameObject nivel_completado;
    public GameObject GameTiempo_barra;
    public GameObject corazon1;
    public GameObject corazon2;
    public GameObject corazon3;
    public prueba_sinmov objeto = new prueba_sinmov();
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
    int opc;
    GameObject Padre_a_ocupar;
    public GameObject lista_de_cubos3x3_Padre;
    public List<GameObject> ListaCubos3x3;
    public GameObject lista_de_cubos4x4_Padre;
    public List<GameObject> ListaCubos4x4;
    public GameObject lista_de_cubos5x5_Padre;
    public List<GameObject> ListaCubos5x5;
    public GameObject lista_de_cubos6x6_Padre;
    public List<GameObject> ListaCubos6x6;
    public GameObject lista_de_cubos7x7_Padre;
    public List<GameObject> ListaCubos7x7;
    public GameObject lista_de_cubos8x8_Padre;
    public List<GameObject> ListaCubos8x8;
    public GameObject lista_de_cubos9x9_Padre;
    public List<GameObject> ListaCubos9x9;



    /*public GameObject sonido1;
    public GameObject sonido2;
    public GameObject sonido3;
    public GameObject sonido4;
    public GameObject sonido5;
    public GameObject sonido6;
    public GameObject sonido7;
    public GameObject sonido_error;
    public GameObject sonido_final;*/
    int var1;
    int var2;
    
    //List<GameObject> lista_musica = new List<GameObject>();
    public bool nivel_en_pre_juego;
    public static bool nivel_completado_bool;

    // Start is called before the first frame update
    void llenar_listas_gameobject()
    {
        for (int x = 0; x < lista_de_cubos3x3_Padre.transform.childCount; x++)
        {
            ListaCubos3x3.Add(lista_de_cubos3x3_Padre.transform.GetChild(x).gameObject);
        }

        for (int x = 0; x < lista_de_cubos4x4_Padre.transform.childCount; x++)
        {
            ListaCubos4x4.Add(lista_de_cubos4x4_Padre.transform.GetChild(x).gameObject);
        }

        for (int x = 0; x < lista_de_cubos5x5_Padre.transform.childCount; x++)
        {
            ListaCubos5x5.Add(lista_de_cubos5x5_Padre.transform.GetChild(x).gameObject);
        }

        for (int x = 0; x < lista_de_cubos6x6_Padre.transform.childCount; x++)
        {
            ListaCubos6x6.Add(lista_de_cubos6x6_Padre.transform.GetChild(x).gameObject);
        }

        for (int x = 0; x < lista_de_cubos7x7_Padre.transform.childCount; x++)
        {
            ListaCubos7x7.Add(lista_de_cubos7x7_Padre.transform.GetChild(x).gameObject);
        }

        for (int x = 0; x < lista_de_cubos8x8_Padre.transform.childCount; x++)
        {
            ListaCubos8x8.Add(lista_de_cubos8x8_Padre.transform.GetChild(x).gameObject);
        }

        for (int x = 0; x < lista_de_cubos9x9_Padre.transform.childCount; x++)
        {
            ListaCubos9x9.Add(lista_de_cubos9x9_Padre.transform.GetChild(x).gameObject);
        }
    }
    void Start()
    {
        llenar_listas_gameobject();

        //nivel_en_pre_juego = false;
        nivel_completado_bool = false;
        //rellenar_musica();
        var2 =6;
        opc = 0;
        nivel_en_proceso = false;
        resultado_mov = "No aplica";
        vidas = 3;
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
    /*void rellenar_musica(){
        lista_musica.Add(sonido1);
        lista_musica.Add(sonido2);
        lista_musica.Add(sonido3);
        lista_musica.Add(sonido4);
        lista_musica.Add(sonido5);
        lista_musica.Add(sonido6);
        lista_musica.Add(sonido7);
    }*/
    /*void escuchar_sonido(){
        Instantiate(lista_musica[var2]);
        //Instantiate(sonido2);
        lista_musica.RemoveAt(var2);
        if(lista_musica.Count==0){
            rellenar_musica();
            var2=6;
        }else{
            var2 = var2-1;
        }
        
    }*/
    /*void reiniciar_secuencia(){
        lista_musica.Clear();
        rellenar_musica();
        var2=6;
    }*/
    
    void Update()
    {
        ///tiempo_espera = tiempo_espera+1*Time.deltaTime;
        //Debug.Log(tiempo_espera);
        //if(nivel_en_proceso==true){
            //StartCoroutine(cambiar_imagenes());
            /*if(opc <nivel_actual){
                //Debug.Log("Se ha cambiado el sprite del index: "+opc+ "el nivel actual es: "+nivel_actual);
                cambiar_imagen(opc);
                tiempo_espera = tiempo_espera+1*Time.deltaTime;
                if(tiempo_espera >1){
                    cambiar_imagen_a_original(opc);
                    opc = opc+1;
                    tiempo_espera = 0;
                }
            }else{
                
                nivel_en_juego=true;
                nivel_en_proceso=false;
                opc =0;
            }*/
        //}
        if(nivel_en_juego == true){
                //Debug.Log(secuencia.Count);
                tiempo_muerte = tiempo_muerte +1*Time.deltaTime;
                if(secuencia_memorize_copia.Count<var1){
                    Debug.Log("Se instancia un sonido");
                    var1 = var1-1;
                    //escuchar_sonido();
                }
                if(secuencia_memorize_copia.Count==0){
                    //reiniciar_secuencia();
                    nivel_completado.SetActive(true);
                    //Debug.Log("la lista quedo vacia");
                    tiempo_al_final = tiempo_al_final + 1 * Time.deltaTime;
                    if(tiempo_al_final>1 || tiempo>0){
                        GameTiempo_barra.SetActive(true);
                        nivel_terminado_volver_original();
                        tiempo = tiempo + 1 * Time.deltaTime;
                        texto.text = tiempo+"s";
                        barra_De_tiempo.fillAmount = tiempo/tiempo_maximo;
                        if(tiempo>2f){
                            GameTiempo_barra.SetActive(false);
                            tiempo = 0.0f;
                            tiempo_al_final = 0.0f;
                            nivel_en_juego=false;
                            nivel_actual = nivel_actual+1; 
                            if(nivel_actual==10){
                            cuadrado3x3.SetActive(false);
                            cuadrado4x4.SetActive(true); 
                            }
                            else if(nivel_actual==17){
                            cuadrado4x4.SetActive(false);
                            cuadrado5x5.SetActive(true); 
                            }
                            else if(nivel_actual==26){
                            cuadrado5x5.SetActive(false);
                            cuadrado6x6.SetActive(true); 
                            }
                            else if(nivel_actual==37){
                            cuadrado6x6.SetActive(false);
                            cuadrado7x7.SetActive(true); 
                            }
                            else if(nivel_actual==49){
                            cuadrado7x7.SetActive(false);
                            cuadrado8x8.SetActive(true); 
                            }
                            else if(nivel_actual==81){
                            cuadrado8x8.SetActive(false);
                            cuadrado9x9.SetActive(true); 
                            }
                            Debug.Log("se llama al siguente nivel: " + nivel_actual);
                            siguiente_nivel();
                            nivel_completado.SetActive(false);
                            
                            
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
                        //Instantiate(sonido_error);
                    }
                    else if(vidas ==1){
                        corazon1.SetActive(true);
                        corazon2.SetActive(false);
                        corazon3.SetActive(false);
                        //Instantiate(sonido_error);
                    }
                    else if(vidas ==0){
                        corazon1.SetActive(false);
                        corazon2.SetActive(false);
                        corazon3.SetActive(false);
                        //Instantiate(sonido_final);
                    }  
            }
        
        if(vidas ==0){
            nivel_terminado_volver_original();
            haz_perdido.SetActive(true);
            volver_a_jugar.SetActive(true);
            nivel_en_juego = false;
            resultado_mov = nivel_actual.ToString();
            objeto.InsertTouch(1);
            vidas =3;
        }
    }
    public void volver_a_jugarr(){

        cuadrado3x3.SetActive(true);
        cuadrado4x4.SetActive(false);
        cuadrado5x5.SetActive(false);
        cuadrado6x6.SetActive(false);
        cuadrado7x7.SetActive(false);
        cuadrado8x8.SetActive(false);
        cuadrado9x9.SetActive(false);
        haz_perdido.SetActive(false);
        nivel_actual = 1;
        nivel_en_juego = false;
        nivel_en_proceso = false;
        //nivel_en_pre_juego
        CrearLista();
        siguiente_nivel();
        volver_a_jugar.SetActive(false);
        resultado_mov = "No aplica";
    }
    /*void rellenar_listas(List<int> a, int b){
        a.Clear();
        for (int x = 0;x<b;x++){
            a.Add(x);
        }
    }*/


    void cambiar_imagen(int numero_random_func){
        Debug.Log("al cubo: "+ (secuencia_memorize_copia[numero_random_func]).name+" se le deberia cambiar el sprite, su padre es: "+secuencia_memorize_copia[numero_random_func].transform.parent.name);
        (secuencia_memorize_copia[numero_random_func]).GetComponent<Image>().sprite = imagenACambiar; 
    }
    void cambiar_imagen_a_original(GameObject obj){
        //Debug.Log("GameObject.Find("+secuencia_memorize[x]+").GetComponent<Image>().sprite = imagen_original");
         obj.GetComponent<Image>().sprite = imagen_original; 
    }

    

    public void CrearLista(){
        secuencia_memorize3x3.Clear();
        secuencia_memorize4x4.Clear();
        secuencia_memorize5x5.Clear();
        secuencia_memorize6x6.Clear();
        secuencia_memorize7x7.Clear();
        secuencia_memorize8x8.Clear();
        secuencia_memorize9x9.Clear();
        /*Debug.Log(secuencia_memorize.Count+" aaa"+lista_de_cubos9x9.Count);
        int opc1 = lista_de_cubos9x9.Count;
        for (int x = 0;x<opc1;x++){
            int numero_random = Random.Range(0,lista_de_cubos9x9.Count);
            secuencia_memorize.Add(lista_de_cubos[lista_de_cubos9x9[numero_random]]);
            
            lista_de_cubos9x9.RemoveAt(numero_random);
        }*/
        boton_jugar.SetActive(false);
        int opc1 = ListaCubos3x3.Count;
        //Debug.Log(secuencia_memorize.Count+" "+lista_de_cubos9x9.Count);
        for (int x = 0;x<opc1;x++){
            int numero_random = Random.Range(0,ListaCubos3x3.Count);
            secuencia_memorize3x3.Add(ListaCubos3x3[numero_random]);
            secuencia_memorize4x4.Add(ListaCubos4x4[numero_random]);
            secuencia_memorize5x5.Add(ListaCubos5x5[numero_random]);
            secuencia_memorize6x6.Add(ListaCubos6x6[numero_random]);
            secuencia_memorize7x7.Add(ListaCubos7x7[numero_random]);
            secuencia_memorize8x8.Add(ListaCubos8x8[numero_random]);
            secuencia_memorize9x9.Add(ListaCubos9x9[numero_random]);
            ListaCubos3x3.RemoveAt(numero_random);
            ListaCubos4x4.RemoveAt(numero_random);
            ListaCubos5x5.RemoveAt(numero_random);
            ListaCubos6x6.RemoveAt(numero_random);
            ListaCubos7x7.RemoveAt(numero_random);
            ListaCubos8x8.RemoveAt(numero_random);
            ListaCubos9x9.RemoveAt(numero_random);
        }
        opc1 = ListaCubos4x4.Count;

        for (int x = 0;x<opc1;x++){
            int numero_random = Random.Range(0, ListaCubos4x4.Count);
            
            secuencia_memorize4x4.Add(ListaCubos4x4[numero_random]);
            secuencia_memorize5x5.Add(ListaCubos5x5[numero_random]);
            secuencia_memorize6x6.Add(ListaCubos6x6[numero_random]);
            secuencia_memorize7x7.Add(ListaCubos7x7[numero_random]);
            secuencia_memorize8x8.Add(ListaCubos8x8[numero_random]);
            secuencia_memorize9x9.Add(ListaCubos9x9[numero_random]);
            ListaCubos4x4.RemoveAt(numero_random);
            ListaCubos5x5.RemoveAt(numero_random);
            ListaCubos6x6.RemoveAt(numero_random);
            ListaCubos7x7.RemoveAt(numero_random);
            ListaCubos8x8.RemoveAt(numero_random);
            ListaCubos9x9.RemoveAt(numero_random);
        }
        opc1 = ListaCubos5x5.Count;
        for (int x = 0;x<opc1;x++){
            int numero_random = Random.Range(0, ListaCubos5x5.Count);
            
            secuencia_memorize5x5.Add(ListaCubos5x5[numero_random]);
            secuencia_memorize6x6.Add(ListaCubos6x6[numero_random]);
            secuencia_memorize7x7.Add(ListaCubos7x7[numero_random]);
            secuencia_memorize8x8.Add(ListaCubos8x8[numero_random]);
            secuencia_memorize9x9.Add(ListaCubos9x9[numero_random]);
            ListaCubos5x5.RemoveAt(numero_random);
            ListaCubos6x6.RemoveAt(numero_random);
            ListaCubos7x7.RemoveAt(numero_random);
            ListaCubos8x8.RemoveAt(numero_random);
            ListaCubos9x9.RemoveAt(numero_random);
        }
        opc1 = ListaCubos6x6.Count;
        for (int x = 0;x<opc1;x++){
            int numero_random = Random.Range(0, ListaCubos6x6.Count);
            
            secuencia_memorize6x6.Add(ListaCubos6x6[numero_random]);
            secuencia_memorize7x7.Add(ListaCubos7x7[numero_random]);
            secuencia_memorize8x8.Add(ListaCubos8x8[numero_random]);
            secuencia_memorize9x9.Add(ListaCubos9x9[numero_random]);
            ListaCubos6x6.RemoveAt(numero_random);
            ListaCubos7x7.RemoveAt(numero_random);
            ListaCubos8x8.RemoveAt(numero_random);
            ListaCubos9x9.RemoveAt(numero_random);
        }
        opc1 = ListaCubos7x7.Count;
        for (int x = 0;x<opc1;x++){
            int numero_random = Random.Range(0, ListaCubos7x7.Count);
            
            secuencia_memorize7x7.Add(ListaCubos7x7[numero_random]);
            secuencia_memorize8x8.Add(ListaCubos8x8[numero_random]);
            secuencia_memorize9x9.Add(ListaCubos9x9[numero_random]);
            ListaCubos7x7.RemoveAt(numero_random);
            ListaCubos8x8.RemoveAt(numero_random);
            ListaCubos9x9.RemoveAt(numero_random);
        }
        opc1 = ListaCubos8x8.Count;
        for (int x = 0;x<opc1;x++){
            int numero_random = Random.Range(0, ListaCubos8x8.Count);
            
            secuencia_memorize8x8.Add(ListaCubos8x8[numero_random]);
            secuencia_memorize9x9.Add(ListaCubos9x9[numero_random]);
            ListaCubos8x8.RemoveAt(numero_random);
            ListaCubos9x9.RemoveAt(numero_random);
        }
        opc1 = ListaCubos9x9.Count;
        for (int x = 0;x<opc1;x++){
            int numero_random = Random.Range(0, ListaCubos9x9.Count);
            
            secuencia_memorize9x9.Add(ListaCubos9x9[numero_random]);
            ListaCubos9x9.RemoveAt(numero_random);
        }
        //Debug.Log(secuencia_memorize.Count+" "+ ListaCubos9x9.Count);
        nivel_actual = 1;
        llenar_listas_gameobject();
        siguiente_nivel();

        
        
    }
    void siguiente_nivel(){
        secuencia_memorize_numeros_a_limpiar.Clear();
        secuencia_memorize_copia.Clear();
        if (nivel_actual < 10)
        {

            Padre_a_ocupar = lista_de_cubos3x3_Padre;
            for (int x = 0; x < nivel_actual; x++)
            {
                secuencia_memorize_copia.Add(secuencia_memorize3x3[x]);
                secuencia_memorize_numeros_a_limpiar.Add(secuencia_memorize3x3[x]);
            }
            
        }
        else if (nivel_actual < 17)//pasamos a matriz 4x4
        {
            Padre_a_ocupar = lista_de_cubos4x4_Padre;
            for (int x = 0; x < nivel_actual; x++)
            {
                secuencia_memorize_copia.Add(secuencia_memorize4x4[x]);
                secuencia_memorize_numeros_a_limpiar.Add(secuencia_memorize4x4[x]);
            }
        }
        else if(nivel_actual < 26)//pasamos a matriz 4x4
        {
            Padre_a_ocupar = lista_de_cubos5x5_Padre;
            for (int x = 0; x < nivel_actual; x++)
            {
                secuencia_memorize_copia.Add(secuencia_memorize5x5[x]);
                secuencia_memorize_numeros_a_limpiar.Add(secuencia_memorize5x5[x]);
            }
        }
        else if(nivel_actual < 37)//pasamos a matriz 4x4
        {
            Padre_a_ocupar = lista_de_cubos6x6_Padre;
            for (int x = 0; x < nivel_actual; x++)
            {
                secuencia_memorize_copia.Add(secuencia_memorize6x6[x]);
                secuencia_memorize_numeros_a_limpiar.Add(secuencia_memorize6x6[x]);
            }
        }
        else if(nivel_actual < 49)//pasamos a matriz 4x4
        {
            Padre_a_ocupar = lista_de_cubos7x7_Padre;
            for (int x = 0; x < nivel_actual; x++)
            {
                secuencia_memorize_copia.Add(secuencia_memorize7x7[x]);
                secuencia_memorize_numeros_a_limpiar.Add(secuencia_memorize7x7[x]);
            }
        }
        else if(nivel_actual <81)//pasamos a matriz 4x4
        {
            Padre_a_ocupar = lista_de_cubos8x8_Padre;
            for (int x = 0; x < nivel_actual; x++)
            {
                secuencia_memorize_copia.Add(secuencia_memorize8x8[x]);
                secuencia_memorize_numeros_a_limpiar.Add(secuencia_memorize8x8[x]);
            }
        }
        else if(nivel_actual >=81)//pasamos a matriz 4x4
        {
            Padre_a_ocupar = lista_de_cubos9x9_Padre;
            for (int x = 0; x < nivel_actual; x++)
            {
                secuencia_memorize_copia.Add(secuencia_memorize9x9[x]);
                secuencia_memorize_numeros_a_limpiar.Add(secuencia_memorize9x9[x]);
            }
        }
        llenar_segunda_secuencia();
        StartCoroutine(cambiar_imagenes());

    }
    void llenar_segunda_secuencia(){
        /*secuencia_memorize_copia.Clear();
        for(int x = 0;x<nivel_actual;x++){
            secuencia_memorize_copia.Add(secuencia_memorize[x]);
            Debug.Log("la secuencia es: "+x+" "+secuencia_memorize_copia[x]);
        }*/
        //nivel_en_proceso=true;
        //var1 = secuencia_memorize_copia.Count;
    }
    public IEnumerator cambiar_imagenes()
    {
        Debug.Log("secuencia_memorize_copia.coun: " + secuencia_memorize_copia.Count);
        int x = 0;
        while(x<secuencia_memorize_copia.Count)
        {
            cambiar_imagen(x);
            //Debug.Log("Deberia estar cambiando la img");
            yield return new WaitForSecondsRealtime(1);
            cambiar_imagen_a_original(secuencia_memorize_copia[x]);
            x++;
        }
        nivel_en_juego = true;
        nivel_en_proceso = false;
        var1 = secuencia_memorize_copia.Count;
    }
    void nivel_terminado_volver_original()
    {
        
        for (int x = 0;x< Padre_a_ocupar.transform.childCount; x++)
        {
            cambiar_imagen_a_original(Padre_a_ocupar.transform.GetChild(x).gameObject);
        }
    }

}