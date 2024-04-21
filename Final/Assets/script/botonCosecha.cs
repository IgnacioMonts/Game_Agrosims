using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botonCosecha : MonoBehaviour
{
    public GameObject cultivo;
		public int monedas = 0;

    //una referencia a una instancia unica
    public static botonCosecha instance;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		player Player = collision.GetComponent<player>();

		if (Player)
		{
			cultivo.SetActive(false);
			monedas = monedas + 100;
			HUD.instance.ActualizarMonedas();
		}
		else
		{
			cultivo.SetActive(true);
		}
	}
}
