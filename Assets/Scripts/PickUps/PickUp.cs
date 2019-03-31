using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    //Creamos un campo publico donde almacenar objeto de tipo transform
    public Transform fx;
    private float waitTime = 6.0f;
    private float time = 0.0f;

    private GameObject obj;
    private Canvas c;
    // Start is called before the first frame update
    void Start()
    {
        obj = GameObject.Find("HUD");
        c = obj.GetComponent<Canvas>();
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

            if(this.gameObject.CompareTag("Nitro"))
            {
                int num = c.comprobarNitroVacio();
                c.llenarNitro(num);

            }else
            {
                // Genera un número random y elige uná imagen al azar que mostrara
                System.Random rand = new System.Random();
                int num = rand.Next(0,3);
                //
                c.chooseRandomSprite(num);
            }

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
