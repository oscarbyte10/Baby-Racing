using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    //Creamos un campo publico donde almacenar objeto de tipo transform
    public Transform fx;
    private float waitTime = 6.0f;
    private float time = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        // Mira en bucle si el pickUp debe ser creado otra vez
        //crearPickUpASeisSegundos(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            // para destruir inmediatamente 
            // DestroyInmediate
            // destruye el objeto en el siguiente loop
            Destroy(gameObject);

            // Instanciar un gameObject
            // posición en el que quiero que se cree
            // rotación en la que quiero que aparezca
            // Quaternion.identity tiene el giro 0, es decir, el que tiene el objeto fx
            Instantiate(fx, transform.position, Quaternion.identity);
        }

    }

    private void crearPickUpASeisSegundos(GameObject obj)
    {
        time += Time.deltaTime;
        if (time > waitTime)
        {
            Instantiate(obj);
            time = time - waitTime;
        }
    }
}
