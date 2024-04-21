using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botonCosecha : MonoBehaviour
{
    public GameObject cultivo;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		player Player = collision.GetComponent<player>();

		if (Player)
		{
			cultivo.SetActive(false);
		}
		else
		{
			cultivo.SetActive(true);
		}
	}
}
