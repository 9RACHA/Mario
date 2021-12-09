using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    private float fuerzaSalto = 6.5f;
    private float speed = 5f;
    Animator animator; //Declarar animator
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        //GetComponent muy polivalente
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Camina", false);
        //Transform para usarlo hay que acceder a la variabble que hereda de la clase mono beheavour
        if(Input.GetKey(KeyCode.LeftArrow)) { //Si pulso la tecla izquierda
            transform.Translate(Vector3.left * speed * Time.deltaTime);     //Mediante translate lleva al punto de movimiento 
            animator.SetBool("Camina", true); //Al ser V o F 
            transform.localScale = new Vector3(1, 1, 1); // Mira a la izquierda
            
        } else if(Input.GetKey(KeyCode.RightArrow)) {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            animator.SetBool("Camina", true);
            transform.localScale = new Vector3(-1, 1, 1); // Mira a la derecha xq la animacion de Mario estaba hacia la izquierda

        } if (Input.GetKeyDown(KeyCode.Space)){
            rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        
          
        }
    }
}
