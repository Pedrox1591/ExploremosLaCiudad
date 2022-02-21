using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class linea : MonoBehaviour
{
    // Start is called before the first frame update
    LineRenderer Linea;
    List<Vector2> puntos = new List<Vector2>();
    Vector2 ultimopunto;
    private void Awake()
    {
        Linea = GetComponent<LineRenderer>();
    }
    public void dibujarLinea(Vector2 ratonpos)
    {
        if (puntos == null)
        {
            puntos = new List<Vector2>();
            dibujarPunto(ratonpos);
            return;
        }
        if (Vector2.Distance(ultimopunto,ratonpos) >= 0.05f){
            dibujarPunto(ratonpos);

        }
    }
    public void dibujarPunto(Vector2 punto)
    {
        puntos.Add(punto);
        Linea.positionCount = puntos.Count;
        Linea.SetPosition(puntos.Count - 1, punto);
        ultimopunto = punto;
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
