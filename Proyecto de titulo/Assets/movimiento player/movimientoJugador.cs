using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movimientoJugador : MonoBehaviour
{
    public Joystick joystick;
    public int velocidad;
    public Rigidbody2D rb;
    public bool confisicas;
    private Animator animator;
    float tiempo;
    prueba objeto;
    public GameObject RecojerBasura;

    public GameObject Text_que_sube;
    public GameObject audio_objeto_recojido;
    public AnimationClip movimiento_basura;

    public GameObject mochila;
    public int estado_de_caminata;

    public static Vector3 pos_jugador;
    public static bool primer_inicio;
    
    //Image imagen;
    // Start is called before the first frame update
    void Start()
    {
        if(primer_inicio == true)
        {
            transform.localPosition = pos_jugador;
            //primer_inicio = true;
            Debug.Log("primerrrr inicioooooooooo");

        }
        else
        {
            primer_inicio = true;
        }
        
        pos_jugador = transform.localPosition;
        estado_de_caminata = 1;
        animator = GetComponent<Animator>();
        objeto = gameObject.GetComponent<prueba>();
    }


    // Update is called once per frame
    void Update()
    {
        pos_jugador = transform.localPosition;
    }
    private void FixedUpdate()
    {

        Vector2 direction = Vector2.up * joystick.Vertical + Vector2.right * joystick.Horizontal;
        //Debug.Log(direction);
        if (confisicas)
        {
            rb.AddForce(direction * velocidad * Time.fixedDeltaTime, ForceMode2D.Impulse);

        }
        else
        {
            
            gameObject.transform.Translate(direction * velocidad * Time.deltaTime);

            if (direction.x != 0 || direction.y != 0)
            {
                tiempo = tiempo + 1;

                animarmovimiento(direction);

                if (tiempo < 2)
                {
                    objeto.InsertTouch_movimiento(estado_de_caminata, "Movimiento_personaje");
                }
                else if (tiempo > 5)
                {
                    tiempo = 0;
                }
            }
            else
            {
                animator.SetLayerWeight(1, 0);
            }


        }
    }
    public void animarmovimiento(Vector2 direccionn){
        animator.SetLayerWeight(1,1);
        animator.SetFloat("x",direccionn.x);
        animator.SetFloat("y",direccionn.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag =="BasuraPlasticoEnMapa" || collision.tag == "BasuraVidrioEnMapa" || collision.tag == "BasuraPapelEnMapa")
        {
            //RecojerBasura.SetActive(true);
            Text_que_sube.GetComponent<Animator>().Play("a");
            
            reproducir_audio();
            //collision.GetComponent<prueba>().insertElement(collision.GetComponent<prueba>().cantidad_obtenida_get + 1, collision.GetComponent<prueba>().idElemento);
            StartCoroutine(esperar_segundos(collision.GetComponent<prueba>()));
            //Debug.Log("la cantidad del objeto "+collision.name+" es: " + collision.GetComponent<prueba>().cantidad_obtenida_get+"ahora sera: "+ collision.GetComponent<prueba>().cantidad_obtenida_get+1);

            Sprite spritee = collision.GetComponent<SpriteRenderer>().sprite;
            collision.gameObject.transform.SetParent(GameObject.Find("Canvas").transform);


            Destroy(collision.gameObject.GetComponent<SpriteRenderer>());
            collision.gameObject.AddComponent<Image>();
            collision.gameObject.GetComponent<Image>().sprite = spritee;
            collision.gameObject.AddComponent<Animation>();
            collision.gameObject.GetComponent<Animation>().AddClip(movimiento_basura,"movimiento_basura");
            collision.gameObject.GetComponent<Animation>().Play("movimiento_basura");

            StartCoroutine(DestruirObjeto(collision.gameObject,4));
            //Destroy(collision.gameObject);
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //if(collision.tag == "Zona_reciclaje")
        //{
            //RecojerBasura.SetActive(false);
            //Debug.Log("Entro em ña zona de reciclaje");
        //}
    }
    public IEnumerator DestruirObjeto(GameObject a,int tiempo)
    {
        //Debug.Log("Entro al Ienumerator");
        //a.transform.localScale = new Vector3(0,0,0);
        yield return new WaitForSeconds(tiempo);
        //Debug.Log("Despues de 5 segundos se debio eliminar esta verga wey");
        DestroyImmediate(a,true);
        

    }

    void reproducir_audio()
    {
        GameObject a = (Instantiate(audio_objeto_recojido));
        
        StartCoroutine(Eliminar_sonido(a));

    }
    public IEnumerator Eliminar_sonido(GameObject a)
    {
        //Debug.Log("Entro al Ienumerator");
        yield return new WaitForSeconds(5);
        //Debug.Log("Despues de 5 segundos se debio eliminar esta verga wey");
        DestroyImmediate(a,true);
        Text_que_sube.GetComponent<Animator>().Play("b");
        
    }
    public IEnumerator esperar_segundos(prueba a)
    {
        a.get(true);
        a.InsertTouch(1,"Objeto obtenido en mapa");
        yield return new WaitForSeconds(4);
        
        mochila.GetComponent<objetos_mochila>().get_objetos();
    }
    
}
