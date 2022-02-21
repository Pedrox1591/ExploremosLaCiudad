using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vallas1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(gameObject.name == "vereda_arriba" && collision.gameObject.name == "Jugador")
        {
            collision.GetComponent<SpriteRenderer>().sortingOrder = 3;
        }
        if (gameObject.name == "vereda_abajo" && collision.gameObject.name == "Jugador")
        {
            collision.GetComponent<SpriteRenderer>().sortingOrder = 3;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Jugador")
        {
            collision.GetComponent<SpriteRenderer>().sortingOrder = 1;
        }
        
    }
}
