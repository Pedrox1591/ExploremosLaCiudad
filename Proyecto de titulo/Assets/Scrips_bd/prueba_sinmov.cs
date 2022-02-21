using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class prueba_sinmov : MonoBehaviour,IPointerClickHandler {
    //public int idReim; 
    public int idActividad;
    public int idElemento;
    //public int Correcta;
    //public int idUser;
    //public int idPer;
    //public string Resultado;
    public int TipoRegistro;
    

    public void InsertTouch(int Correctaa) {
        AlumnoRespuestaActividad ARA;
        ARA = new AlumnoRespuestaActividad();
        ARA.id_reim = 600;
        ARA.id_actividad = idActividad;
        ARA.id_elemento = idElemento;
        ARA.datetime_touch = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
        ARA.Eje_X = Convert.ToInt32(Input.mousePosition.x);
        ARA.Eje_Y = Convert.ToInt32(Input.mousePosition.y);
        ARA.Eje_Z = Convert.ToInt32(Input.mousePosition.z);
        ARA.correcta = Correctaa;
        ARA.id_user = Login.usuarios_id;
        ARA.id_per = url_api.periodo;
        if(idActividad == 20011)
        {
            ARA.resultado = memorize_test.resultado_mov;
        }
        else if(idActividad == 20012)
        {
            ARA.resultado = memorize_test_secuencial.resultado_mov;
        }
        
        ARA.Tipo_Registro = TipoRegistro;
        StartCoroutine(Post(ARA));
    }

    public IEnumerator Post(AlumnoRespuestaActividad ARA) {
        string urlAPI = url_api.url+"/alumno_respuesta/add";

        var jsonData = JsonUtility.ToJson(ARA);

        using (UnityWebRequest www = UnityWebRequest.Post(urlAPI, jsonData)) {
            www.SetRequestHeader("content-type", "application/json");
            www.uploadHandler.contentType = "application/json";
            www.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(jsonData));
            yield return www.SendWebRequest();

            if (www.isNetworkError) {
                Debug.Log(www.error);
                Debug.Log("error!");
            }
            else {
                if (www.isDone) {
                    var result = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                    if (result != null) {
                        //var AlumnoRespuesta = JsonUtility.FromJson<AlumnoRespuestaActividad>(result);                                         
                    }
                }
            }
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if(memorize_test.nivel_en_juego ==true){
            if(cubos.var==1){
                InsertTouch(1);
                Debug.Log("Se inserto como correcto");
            }
            if(cubos.var==0){
                InsertTouch(2);
                Debug.Log("Se inserto como incorrecto");
            }
            
        }else{
            InsertTouch(0);
            Debug.Log("Se inserto como nulo");
        }
        
    }
    /*public void OnEndDrag(PointerEventData eventData){
        
        if(objeto.variable_muy_variable==1){
            InsertTouch(1);
            Debug.Log("se inserta como correcto");
        }   
        else if(objeto.variable_muy_variable==2){
            InsertTouch(0);
            objeto.variable_muy_variable =0;
            Debug.Log("se inserta como incorrecto");
        }
        else{
            InsertTouch(2);
            Debug.Log("No aplica el num es: "+objeto.variable_muy_variable);
        }

    }*/

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }
}
