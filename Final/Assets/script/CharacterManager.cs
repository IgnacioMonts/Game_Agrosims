using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    // Inicializa el array de personajes en el script
    private GameObject[] characters;

    void Start()
    {
        // Asigna los GameObjects correspondientes
        characters = new GameObject[]
        {
            GameObject.Find("hombre1"),
            GameObject.Find("hombre2"),
            GameObject.Find("hombre3"),
            GameObject.Find("mujer1"),
            GameObject.Find("mujer2"),
            GameObject.Find("mujer3")
        };

        // Activa el personaje inicial seleccionado en el menú
        ActivateCharacter(0);
        if (mainManager.Instance.mujer == 1)
        {
            ActivateCharacter(3);
        }
        else if (mainManager.Instance.mujer == 2)
        {
            ActivateCharacter(4);
        }
        else if (mainManager.Instance.mujer == 3)
        {
            ActivateCharacter(5);
        }
        else if (mainManager.Instance.hombre == 1)
        {
            ActivateCharacter(0);
        }
        else if (mainManager.Instance.hombre == 2)
        {
            ActivateCharacter(1);
        }
        else if (mainManager.Instance.hombre == 3)
        {
            ActivateCharacter(2);
        }
    }

    public void ActivateCharacter(int index)
    {
        // Apaga todos los personajes
        foreach (GameObject character in characters)
        {
            character.SetActive(false);
        }

        // Activa el personaje seleccionado
        if (index >= 0 && index < characters.Length)
        {
            characters[index].SetActive(true);
        }
    }
}
