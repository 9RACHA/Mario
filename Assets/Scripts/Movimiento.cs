using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    private float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Transform para usarlo hay que acceder a la variabble que hereda de la clase mono beheavour
        if(Input.GetKey(KeyCode.LeftArrow)) { //Si pulso la tecla izquierda
            transform.Translate(Vector3.left * speed * Time.deltaTime);     //Transform para usarlo hay que acceder a la variable que hereda de la clase MonoBehaviour
        } else if(Input.GetKey(KeyCode.RightArrow)) {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }
}
