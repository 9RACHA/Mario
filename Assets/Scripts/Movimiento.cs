using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    private float aceleracionFrenada = 7.0f; //Valor absoluto de la aceleracion aplicada a Mario para frenar
    private float fuerzaSalto = 6.5f;
    private float speed = 3f; //Valor absoluto de la velocidad a la que se mueve Mario

    private float actualSpeed; //Velocidad actual de Mario, depende si esta frenando o moviendo
    Animator animator; //Declarar animator
    private Rigidbody2D rb;

    //Colisionador
    Collider2D collider;

    private bool frenando = false; //Mientras frenas, mario no responde a izq o der

    //Establece unn periodo incial de cada salto
    private bool comienzoSalto;
    // Start is called before the first frame update
    void Start()
    {
        //GetComponent muy polivalente
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
       // collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded()) {
            animator.SetBool("Salto", false);
            Debug.Log("Finaliza salto");
         } else {
                Debug.Log("En el salto");
            }
        //animator.SetBool("Camina", false);
        //Transform para usarlo hay que acceder a la variabble que hereda de la clase mono beheavour
        if( ! frenando && Input.GetKey(KeyCode.LeftArrow) && actualSpeed <= 0) { //Si pulso la tecla izquierda
            // Si Mario se mueve hacia la izquierda, su velocidad sera speed, pero sin signo negativo
            actualSpeed = -speed;
            animator.SetBool("Camina", true); //Al ser V o F 
            transform.localScale = new Vector3(1, 1, 1); // Mira a la izquierda
            
        } else if( ! frenando && Input.GetKey(KeyCode.RightArrow) && actualSpeed >= 0) {
            actualSpeed = speed;

            //transform.Translate(Vector3.right * speed * Time.deltaTime);
            animator.SetBool("Camina", true);
            transform.localScale = new Vector3(-1, 1, 1); // Mira a la derecha xq la animacion de Mario estaba hacia la izquierda

        }else if (actualSpeed != 0){

            frenando = true;
            
            animator.SetBool("Frenar", true);
            animator.SetBool("Camina", false);

             if(actualSpeed > 0) {
                 actualSpeed -= aceleracionFrenada * Time.deltaTime;
             } else {
                 actualSpeed += aceleracionFrenada * Time.deltaTime;
             }
             if (Mathf.Abs(actualSpeed) < 0.01f) {
                 frenando = false;
                 animator.SetBool("Frenar", false);
                 actualSpeed = 0;
             }
             Debug.Log(actualSpeed);
        }
            
        

        transform.Translate(Vector3.left * speed * Time.deltaTime);     //Mediante translate lleva al punto de movimiento 
        
         if (Input.GetKeyDown(KeyCode.Space)){
            rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
            animator.SetBool("Salto", true);
            comienzoSalto = true;
            Invoke("finalizarComienzoSalto", 0.2f);

            Debug.Log("Comienza el salto");
        }  
    }

    private void finalizarComienzoSalto(){
        comienzoSalto = false;
    }
    private bool isGrounded() {
        if (comienzoSalto) {
            return false;
        }

        bool isGrounded = false;
        
    LayerMask mask = LayerMask.GetMask("Plataformas");
       if (collider.IsTouchingLayers(mask)) {
           ContactPoint2D[] puntosContacto = new ContactPoint2D[5];
           int numeroPuntos = collider.GetContacts(puntosContacto);

           if (numeroPuntos == 1) {
              Debug.Log(puntosContacto[0].point.y) 
           }

        }
    }
}

