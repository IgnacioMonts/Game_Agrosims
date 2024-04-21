using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cultivoInicial : MonoBehaviour
{
	Animator anim;
	// Start is called before the first frame update
	void Start()
	{
		anim = gameObject.GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{
		// se activa con el click izquierdo del mouse
		if(Input.GetMouseButtonDown(0)){
			anim.SetBool("Inicial", true);
		} else {
			anim.SetBool("Inicial", false);
		}
	}

	void FixedUpdate()
	{
		// cuando termina la animacion bool pasa a true
		if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0)) {
			anim.SetBool("Final", true);
		}
	}
}
