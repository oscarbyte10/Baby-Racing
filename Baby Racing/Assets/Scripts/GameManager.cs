using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private GameObject ob1;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        ob1 = GameObject.FindGameObjectWithTag("Acelerador");
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
