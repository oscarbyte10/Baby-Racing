using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PickUp : MonoBehaviour
{
    //Creamos un campo publico donde almacenar objeto de tipo transform
    public Transform fx;
    private float waitTime = 6.0f;
    private float time = 0.0f;

    // Canvas
    private Canvas c = new Canvas();

    // Start is called before the first frame update
    void Start()
    {
        c = GameObject.Find("Canvas").GetComponent<Canvas>();
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

            //Como UnityEngine y System tienen cada uno una clase Random, especificamos 
            // que clase queremos que utilice añadiendo en este caso System.Random cuando 
            // creemos la variable Random.

            System.Random rnd = new System.Random();

            int n = rnd.Next(0, 3);


            //Debug.Log("Número generado es:" + n);
            /* 
             * Por cada pick-up destruido se creará un objeto random.
             * Desde aquí vamos a llamar al canvas y elegir el objeto, una vez elegido, 
             * el objeto será creado por ahora desde aquí.
             * 
             */
            // No devuelve ningún valor, cambia el sprite de image, desde la clase Canvas
            // Choose in list with index
            c.chooseRandomSprite(n);


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
