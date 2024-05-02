using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float velocidad = 5.0f; // Velocidad de movimiento
    private Animator animator; // Referencia al Animator
    private mainManager manager;

    void Start()
    {
        animator = GetComponent<Animator>(); // Obtener el componente Animator
        manager = mainManager.Instance;
    }

    void Update()
    {
        if(manager.puedeMoverse)
        {
            Vector3 movimiento = Vector3.zero; // Vector para almacenar el movimiento, inicializado a cero

            // Capturar entradas específicas del teclado
            if (Input.GetKey(KeyCode.W))
            {
                movimiento += Vector3.up;
                animator.Play("arribah1");
                animator.Play("arribah2");
                animator.Play("arribah3");
                animator.Play("arribam1");
                animator.Play("arribam2");
                animator.Play("arribam3");

            }
            else if (Input.GetKey(KeyCode.UpArrow)) //aplica movimiento con tecla arriba
            {
                movimiento += Vector3.up;
                animator.Play("arribah1");
                animator.Play("arribah2");
                animator.Play("arribah3");
                animator.Play("arribam1");
                animator.Play("arribam2");
                animator.Play("arribam3");

            }
            else if (Input.GetKey(KeyCode.S))
            {
                movimiento += Vector3.down;
                animator.Play("abajoh1");
                animator.Play("abajoh2");
                animator.Play("abajoh3");
                animator.Play("abajom1");
                animator.Play("abajom2");
                animator.Play("abajom3");


            }
            else if (Input.GetKey(KeyCode.DownArrow)) //aplica movimiento con tecla abajo
            {
                movimiento += Vector3.down;
                animator.Play("abajoh1");
                animator.Play("abajoh2");
                animator.Play("abajoh3");
                animator.Play("abajom1");
                animator.Play("abajohm2");
                animator.Play("abajohm3");


            }
            if (Input.GetKey(KeyCode.A))
            {
                movimiento += Vector3.left;
                animator.Play("izquierdah1");
                animator.Play("izquierdah2");
                animator.Play("izquierdah3");
                animator.Play("izquierdam1");
                animator.Play("izquierdam2");
                animator.Play("izquierdam3");


            }
            else if (Input.GetKey(KeyCode.LeftArrow)) //aplica movimiento con tecla izquierda
            {
                movimiento += Vector3.left;
                animator.Play("izquierdah1");
                animator.Play("izquierdah2");
                animator.Play("izquierdah3");
                animator.Play("izquierdam1");
                animator.Play("izquierdam2");
                animator.Play("izquierdam3");


            }
            else if (Input.GetKey(KeyCode.D))
            {
                movimiento += Vector3.right;
                animator.Play("derechah1");
                animator.Play("derechah2");
                animator.Play("derechah3");
                animator.Play("derecham1");
                animator.Play("derecham2");
                animator.Play("derecham3");


            }
            else if (Input.GetKey(KeyCode.RightArrow)) //aplica movimiento con tecla derecha
            {
                movimiento += Vector3.right;
                animator.Play("derechah1");
                animator.Play("derechah2");
                animator.Play("derechah3");
                animator.Play("derecham1");
                animator.Play("derecham2");
                animator.Play("derecham3");


            }

            // Aplicar movimiento si hay alguna entrada
            if (movimiento != Vector3.zero)
            {
                transform.Translate(movimiento.normalized * velocidad * Time.deltaTime);
            }
            else
            {
                animator.Play("reposoh1");
                animator.Play("reposoh2");
                animator.Play("reposoh3");
                animator.Play("reposom1");
                animator.Play("reposom2");
                animator.Play("reposom3");

            }
        }
    }
}
