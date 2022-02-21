using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arbol : MonoBehaviour
{
    SpriteRenderer a;
    int layer_orderer;
    // Start is called before the first frame update
    void Start()
    {
        //a = GameObject.Find("jugador").GetComponent<SpriteRenderer>();
        layer_orderer = gameObject.GetComponent<SpriteRenderer>().sortingOrder;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerStay2D(Collider2D other) {
        if(other.name == "Jugador")
        {
            a = other.GetComponent<SpriteRenderer>();
            a.sortingOrder = layer_orderer + 1;
            Debug.Log("SE CAMBIO A :" + layer_orderer + 1);
        }
        
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Jugador")
        {
            a = other.GetComponent<SpriteRenderer>();
            a.sortingOrder = 1;
        }
        
    }
}
