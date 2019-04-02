using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculos : MonoBehaviour
{

    private ManuCar car;
    // Start is called before the first frame update
    void Start()
    {
        car = GetComponent<ManuCar>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Hacer función que le devuelva un valor a la clase ConducirCoche
    // dicho valor será el impulso que tomara en cierto tiempo, igual que el nitro

}
