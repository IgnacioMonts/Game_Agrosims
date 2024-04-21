using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botonCultiva : MonoBehaviour
{
	public GameObject cultivo;
	public GameObject boton;
	public GameObject botonPrincipal;
	[SerializeField] private int cantidadPuntos;
	[SerializeField] private contadorMonedas puntaje;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		player Player = collision.GetComponent<player>();

		if (Player)
		{
			cultivo.SetActive(true);
			botonPrincipal.SetActive(false);
			puntaje.RestarPuntos(cantidadPuntos);
		}
		else
		{
			cultivo.SetActive(false);
		}
	}
}
