using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculo : MonoBehaviour
{

    // Creamos la variable de la clase de script que vamos a coger variables
    private Conducir obj;
    
    private float p = 0;
    // Start is called before the first frame update
    void Start()
    {
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Ejemplo 1 ----------------------------------
            // Cogemos el objeto, y lo metemos en el objeto
            obj = other.gameObject.GetComponent<Conducir>();
            // Sacamos las variables de el objeto
            p = obj.velocity;
            p = p + 5000;

            // Le asignamos a la variable de dicho objeto el nuevo valor
            obj.velocity = p;

            //obj.power = obj.power * 40000;



            // NOTAS
            //Debug.Log("Caballos: "+obj.enginePower);
            //Debug.Log("Energia: " + obj.power);

            Debug.Log("Acelerando");
        }
    }
}
