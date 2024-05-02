using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class Elecciones : MonoBehaviour
{
    public struct DatosFinales
    {
        public string financiamiento;
        public string seguro;
        public string agricultura;
    }

    //Corrutina para enviar datos JSON al servidor
    public void EnviarJSON()
    {
        StartCoroutine(EnviarJSONServidor());
    }

    // Corrutina para enviar JSON al servidor
    IEnumerator EnviarJSONServidor()
    {

        DatosFinales datos = new DatosFinales();

        if(mainManager.Instance.financiamientoValor == 1)
        {
            //set active true para formal
            datos.financiamiento = "Formal";

        }
        else if(mainManager.Instance.financiamientoValor == 2)
        {
            datos.financiamiento = "Informal";
        }
        else if(mainManager.Instance.financiamientoValor == 3)
        {
            datos.financiamiento = "Verqor";
        }

        if(mainManager.Instance.seguro == true)
        {
            //set active true para seguro
            datos.seguro = "Si";
        }
        else
        {
            datos.seguro = "No";
        }

        if(mainManager.Instance.agricultura == true)
        {
            datos.agricultura = "Regenerativa";
        }
        else
        {
            datos.agricultura = "Tradicional";
        }

        //Llenar la estructura de datos con lo que el usuario escribió

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

