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

            }
            else if (Input.GetKey(KeyCode.UpArrow)) //aplica movimiento con tecla arriba
            {
                movimiento += Vector3.up;
                animator.Play("arribah1");


            }
            else if (Input.GetKey(KeyCode.S))
            {
                movimiento += Vector3.down;
                animator.Play("abajoh1");



            }
            else if (Input.GetKey(KeyCode.DownArrow)) //aplica movimiento con tecla abajo
            {
                movimiento += Vector3.down;
                animator.Play("abajoh1");



            }
            if (Input.GetKey(KeyCode.A))
            {
                movimiento += Vector3.left;
                animator.Play("izquierdah1");



            }
            else if (Input.GetKey(KeyCode.LeftArrow)) //aplica movimiento con tecla izquierda
            {
                movimiento += Vector3.left;
                animator.Play("izquierdah1");


            }
            else if (Input.GetKey(KeyCode.D))
            {
                movimiento += Vector3.right;
                animator.Play("derechah1");



            }
            else if (Input.GetKey(KeyCode.RightArrow)) //aplica movimiento con tecla derecha
            {
                movimiento += Vector3.right;
                animator.Play("derechah1");



            }

            // Aplicar movimiento si hay alguna entrada
            if (movimiento != Vector3.zero)
            {
                transform.Translate(movimiento.normalized * velocidad * Time.deltaTime);
            }
            else
            {
                animator.Play("reposoh1");

            }
        }
    }
}
