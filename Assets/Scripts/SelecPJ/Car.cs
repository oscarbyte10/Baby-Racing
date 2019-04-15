using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    private string nameObj;
    private GameObject coche;

    public Car()
    {

    }

    public Car(string n, GameObject obj)
    {
        Name = n;
        Coche = obj;
    }

    public string Name { get => nameObj; set => nameObj = value; }
    public GameObject Coche { get => coche; set => coche = value; }
    
}
