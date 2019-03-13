using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    // Ponemos las llantas izquierda y derecha delanteras
    public WheelCollider Llanta1;
    public WheelCollider Llanta2;
    // la velocidad del coche
    public int velocidad = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Calculamos el empuje de las ruedas
        // dependiendo de que controles toquemos.

        Llanta1.motorTorque = velocidad * Input.GetAxis("Vertical");
        Llanta2.motorTorque = velocidad * Input.GetAxis("Horizontal");
    }
}
