using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    
    
    //Referencia al objeto que debe seguir la camara;
    public Transform player;

    private float minX = -4.3f;
    private float maxX = 4.3f;

    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
        {
            Debug.Log("Camara: la variable player no esta inicializada");
        }

       
    }

    // Update is called once per frame
    void Update()
    {
        float xPlayer = player.position.x;
        if (xPlayer < minX){
            xPlayer = minX;
        } else if (xPlayer > maxX){
            xPlayer = maxX;
        }
        
        transform.position = new Vector3(xPlayer, transform.position.y, transform.position.z); //Camara
    }
}
