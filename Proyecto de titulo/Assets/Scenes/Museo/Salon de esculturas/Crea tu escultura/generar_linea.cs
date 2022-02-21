using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class generar_linea : MonoBehaviour, IDragHandler
{
    // Start is called before the first frame update
    public GameObject Linea_a_Generar;
    linea lineaa;
    Vector2 pos;
    bool a;
    public GameObject lapiz;
    public GameObject lapiz_por_fuera;
    List<GameObject> ultima_linea_generada = new List<GameObject>();
    void Start()
    {
        a = false;
        //GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, Screen.height);
        //Linea_a_Generar.AddComponent<LineRenderer>();
        //Linea_a_Generar.AddComponent<linea>();
    }
    public void OnDrag(PointerEventData data)
    {
        //a = true;
    }

    public void borrar_linea()
    {
        Destroy(ultima_linea_generada[ultima_linea_generada.Count-2]);
        Destroy(ultima_linea_generada[ultima_linea_generada.Count-1]);
        ultima_linea_generada.Remove(ultima_linea_generada[ultima_linea_generada.Count - 2]);
        ultima_linea_generada.Remove(ultima_linea_generada[ultima_linea_generada.Count-1]);
    }
    public void borrar_linea_btn_x()
    {
        
        Destroy(ultima_linea_generada[ultima_linea_generada.Count - 1]);
        ultima_linea_generada.Remove(ultima_linea_generada[ultima_linea_generada.Count - 1]);
    }
    // Update is called once per frame
    void Update()
    {
        //Touch touch;
        //Debug.Log(a+" "+ Input.GetKeyDown(KeyCode.Mouse0));
        //Debug.Log("a al inicio = " + a);
        if (Input.GetKeyDown(KeyCode.Mouse0))
            {

                //Debug.Log("esta arriba de la wa");
                //touch = Input.GetTouch(0);
                //pos = Camera.main.ScreenToWorldPoint(touch.position);
                //Debug.Log("x = " + Camera.main.ScreenToWorldPoint(Input.mousePosition).x + " y = " + Camera.main.ScreenToWorldPoint(Input.mousePosition).y);

                Vector3 DondeGenerar = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
                //Debug.Log("a: " + data.position.x + "e: " + data.position.y);
                GameObject LineaActual = Instantiate(Linea_a_Generar, DondeGenerar, transform.rotation, GameObject.Find("Cuadro_de_dibujo").transform);
                lineaa = LineaActual.GetComponent<linea>();
                lineaa.GetComponent<LineRenderer>().startWidth = 6;
                lineaa.GetComponent<LineRenderer>().endWidth = 6;
                lineaa.GetComponent<LineRenderer>().material.color = new Color32(100, 100, 100, 255);
                ultima_linea_generada.Add(LineaActual);
                //lineaa.GetComponent<LineRenderer>()



        }

        //Debug.Log("a al medio = " + a);
        if (lineaa != null && a==true)
        {
            Vector2 ratonpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            lineaa.dibujarLinea(ratonpos);
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            //Debug.Log("entra donde es null");
            lineaa = null;
            a = false;
        }
        //Debug.Log("a al final = " + a);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        a = true;
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        a = false;
    }

}
