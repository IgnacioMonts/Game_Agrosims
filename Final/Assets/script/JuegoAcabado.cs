using System.Collections;
using System.Collections.Generic;
using TMPro; //Para InputField
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement; //Para UnityRequest
using System.Text;

public class JuegoAcabado : MonoBehaviour
{
    public struct DatosFinales
    {
        public string idPartida;
        public int total;
        public int decisionesBuenas;
        public int decisionesMalas;
        public int decisionesNeutras;
    }

    //Corrutina para enviar datos JSON al servidor
    public void EnviarJSON()
    {
        StartCoroutine(EnviarJSONServidor());
    }

    // Corrutina para enviar JSON al servidor
    IEnumerator EnviarJSONServidor()
    {
        //Llenar la estructura de datos con lo que el usuario escribió
        DatosFinales datos;

        datos.idPartida = PlayerPrefs.GetString("idPartida");
        datos.total = mainManagerDinero.Instance.dinero;
        datos.decisionesBuenas = mainManagerDinero.Instance.decisionesBuenas;
        datos.decisionesMalas = mainManagerDinero.Instance.decisionesMalas;
        datos.decisionesNeutras = mainManagerDinero.Instance.decisionesNeutras;

        string datosJSON = JsonUtility.ToJson(datos); 
        print("JSON enviado: " + datosJSON);

        //Mandamos directamente la cadena del JSON al servidor y el tipo de dato que estamos enviando
        //lo corremos en el servidor con node.js
        UnityWebRequest request = UnityWebRequest.Post("http://3.226.32.1:8080/salir", datosJSON, "application/json");
        // // Set the data and content type
        // byte[] bodyRaw = Encoding.UTF8.GetBytes(datosJSON);
        // request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        // request.SetRequestHeader("Content-Type", "application/json");
        
        // // Explicitly set HTTP version to 1.1
        // request.SetRequestHeader("HTTP-Version", "HTTP/1.1");

        yield return request.SendWebRequest();

        request.Dispose(); // Libera la memoria
    }
}