using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botonCosecha : MonoBehaviour
{
    public GameObject cultivo;
		public GameObject boton;
		public GameObject botonPrincipal;
		[SerializeField] private int cantidadPuntos;
		[SerializeField] private contadorMonedas puntaje;
		[SerializeField] private int cantidadCultivos;
		[SerializeField] private contadorCultivos puntajeCultivos;


	private void OnTriggerEnter2D(Collider2D collision)
	{
		player Player = collision.GetComponent<player>();

		if (Player)
		{
			cultivo.SetActive(false);
			boton.SetActive(true);
			botonPrincipal.SetActive(false);
			puntaje.SumarPuntos(cantidadPuntos);
			puntajeCultivos.SumarPuntos(cantidadCultivos);
		}
		else
		{
			cultivo.SetActive(true);
		}
	}
}
