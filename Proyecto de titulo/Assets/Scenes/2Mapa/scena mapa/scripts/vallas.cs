using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vallas : MonoBehaviour
{
    // Start is called before the first frame update
    SpriteRenderer jugador;
    void Start()
    {
        jugador = GameObject.Find("Jugador").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Aumenta en 1");
        jugador.sortingOrder = jugador.sortingOrder + 1;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Decrese en 1");
        jugador.sortingOrder = jugador.sortingOrder - 1;
    }
}
