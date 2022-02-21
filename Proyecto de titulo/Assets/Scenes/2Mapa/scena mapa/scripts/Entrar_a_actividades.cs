
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Entrar_a_actividades : MonoBehaviour
{
    public GameObject boton_actividad;
    public Text texto;
    public int numero;
    public GameObject Energia_Faltante;
    
    public GameObject puerta;
    public GameObject Jugador_animacion;
    public GameObject jugador;
    public GameObject main_camera;
    public GameObject camera_2;
    public GameObject camera_3;
    public GameObject script_control_animaciones;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "La casa de juanito")
        {
            boton_actividad.SetActive(true);
            texto.text = "¿Quieres entrar a " + other.name + "?";
            Debug.Log("Entro a la casa de juanito");
            numero = 3;

        }
        if (other.gameObject.name == "La casa de maria")
        {
            boton_actividad.SetActive(true);
            texto.text = "¿Quieres entrar a " + other.name + "?";
            Debug.Log("Entro a la casa de maria");
            numero = 5;

        }
        if (other.gameObject.name == "Tu casa")
        {
            boton_actividad.SetActive(true);
            texto.text = "¿Quieres entrar a " + other.name + "?";
            //Debug.Log("Entro a la casa de juanito");
            numero = 50;


        }
        if (other.gameObject.name == "collider_detras_casa")
        {
            Debug.Log("Entro detras de su casa");
            //GameObject.Find("Tu casa").GetComponent<Renderer>().material.color.a= 0.5f;
        }

        if (other.gameObject.name == "Al museo")
        {
            boton_actividad.SetActive(true);
            texto.text = "¿Quieres entrar a " + other.name + "?";
            //Debug.Log("Entro a al museo");
            numero = 9;
        }

        if (other.gameObject.name == "La casa de Marcelo")
        {
            boton_actividad.SetActive(true);
            texto.text = "¿Quieres entrar a " + other.name + "?";
            //Debug.Log("Entro a al museo");
            numero = 5;
        }

        if (other.gameObject.name == "La casa de Susana")
        {
            boton_actividad.SetActive(true);
            texto.text = "¿Quieres entrar a " + other.name + "?";
            Debug.Log("Entro a al museo");
            numero = 3;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        boton_actividad.SetActive(false);
        numero =0;
    }
    public void boton_amarillo(){
        if(numero != 0 && numero != 50){
            if (inventario_reim.actual_comida -20 >=0)
            {
                SceneManager.LoadScene(numero);
            }
            else
            {
                Energia_Faltante.SetActive(true);
                eliminar_obj(Energia_Faltante);
            }
            
        }else if(numero == 50)
        {
            if (inventario_reim.validar_comida())
            {
                Jugador_animacion.SetActive(true);
                main_camera.SetActive(false);
                camera_2.SetActive(true);
                StartCoroutine(entrar_a_casa());
            }
            



        }
    }
    public IEnumerator entrar_a_casa()
    {
        jugador.transform.localPosition = new Vector3(jugador.transform.localPosition.x, jugador.transform.localPosition.y +300, jugador.transform.localPosition.z);
        Jugador_animacion.GetComponent<Animator>().Play("Entrar_a_casa");
        puerta.GetComponent<Animator>().Play("abrir_puerta");
        camera_2.GetComponent<Animator>().Play("mover_camera");
        yield return new WaitForSeconds(2);
        camera_2.SetActive(false);
        camera_3.SetActive(true);
        script_control_animaciones.GetComponent<Control_animaciones>().animar();
        yield return new WaitForSeconds(16);
        camera_2.SetActive(true);
        camera_3.SetActive(false);
        camera_2.GetComponent<Animator>().Play("mover_camara_salir_casa");
        StartCoroutine(Desactivar_camara());
        



    }
    public IEnumerator Desactivar_camara()
    {

        yield return new WaitForSeconds(1);
        Jugador_animacion.GetComponent<Animator>().Play("Salir_de_casa");

        yield return new WaitForSeconds(1);
        main_camera.SetActive(true);
        camera_2.SetActive(false);
        jugador.transform.localPosition = Jugador_animacion.transform.localPosition;
        Jugador_animacion.SetActive(false);
        puerta.GetComponent<Animator>().Play("Cerrar_puerta");
        inventario_reim.actual_comida = inventario_reim.actual_comida + 10;
        GameObject.Find("script_inventario_reim").GetComponent<inventario_reim>().insertElement((int)inventario_reim.actual_comida,600233);
        GameObject.Find("barra_comida").GetComponent<Image>().fillAmount = inventario_reim.actual_comida / 100;


    }
    public IEnumerator eliminar_obj(GameObject a)
    {
        yield return new WaitForSeconds(3);
        a.SetActive(false);
    }
}
