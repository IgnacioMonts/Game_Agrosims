using System.Collections;
using System.Collections.Generic;
using TMPro; //Para InputField
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement; //Para UnityRequest
using System.Text;


public class InicioJuego : MonoBehaviour
{
    [SerializeField] private TMP_InputField ifUsuario;

    //Estructura de datos para enviar datos JSON
    public struct DatosUsuario
    {
        public string usuario;
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
        DatosUsuario datos;
        datos.usuario = ifUsuario.text.ToString(); 

        string datosJSON = JsonUtility.ToJson(datos); 
        print("JSON enviado: " + datosJSON);

        //Mandamos directamente la cadena del JSON al servidor y el tipo de dato que estamos enviando
        //lo corremos en el servidor con node.js
        UnityWebRequest request = UnityWebRequest.Post("http://localhost:4000/check", datosJSON, "application/json");
        // // Set the data and content type
        // byte[] bodyRaw = Encoding.UTF8.GetBytes(datosJSON);
        // request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        // request.SetRequestHeader("Content-Type", "application/json");
        
        // // Explicitly set HTTP version to 1.1
        // request.SetRequestHeader("HTTP-Version", "HTTP/1.1");

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            PlayerPrefs.SetString("usuario", datos.usuario);
            string respuesta = request.downloadHandler.text;
            print("Respuesta: " + respuesta);
            PlayerPrefs.SetString("idPartida", respuesta);
            SceneManager.LoadScene("Requerimientos");
        }
        else
        {
            string respuesta = request.downloadHandler.text;
            print("Respuesta: " + respuesta);
        }
        request.Dispose(); // Libera la memoria
    }
}