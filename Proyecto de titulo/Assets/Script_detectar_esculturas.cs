using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_detectar_esculturas : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject checkList_boceto;
    public GameObject checkList_objetos;
    public bool bool_checkList_boceto;
    public bool bool_checkList_objetos;
    void Start()
    {
        //bool_checkList_boceto = false;
        //bool_checkList_objetos = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void funcheckList_boceto()
    {
        checkList_boceto.SetActive(true);
        bool_checkList_boceto = true;
    }
    public void funcheckList_objetos()
    {
        checkList_objetos.SetActive(true);
        bool_checkList_objetos = true;
    }
}
