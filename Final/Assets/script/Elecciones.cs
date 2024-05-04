using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class Elecciones : MonoBehaviour
{
    public struct DatosFinales
    {
        public int idElecciones;
        public string financiamiento;
        public string seguro;
        public string agricultura;
        public string idPartida;
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
        datos.idElecciones = PlayerPrefs.GetInt("idElecciones");
        datos.idPartida = PlayerPrefs.GetString("idPartida");

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
        UnityWebRequest request = UnityWebRequest.Post("http://3.226.32.1:8080/elecciones", datosJSON, "application/json");

        yield return request.SendWebRequest();

        request.Dispose(); // Libera la memoria
    }

}