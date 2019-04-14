using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circuito : MonoBehaviour
{
    private string circuitName;
    private int numScene;
    public Circuito()
    {

    }

    public Circuito(string name, int num)
    {
        CircuitName = name;
        NumScene = num;
    }

    public string CircuitName { get => circuitName; set => circuitName = value; }
    public int NumScene { get => numScene; set => numScene = value; }
}
