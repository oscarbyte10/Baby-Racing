using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Informacion : MonoBehaviour
{

    private string car;
    private GameObject objeto;
    private int numScene;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void sendBetweenScene()
    {
        Debug.Log("La información.");
    }

    public void setNameCar(string n)
    {
        //Debug.Log("La información.");
        car = n;
    }

    public void setNumCar(int num)
    {
        //Debug.Log("La información.");
        numScene = num;
    }

    public void setObjCar(GameObject obj)
    {
        //Debug.Log("La información.");
        objeto = obj;
    }

    public string getNameCar()
    {
        //Debug.Log("La información.");
        return car;
    }

    public int getNumCar()
    {
        //Debug.Log("La información.");
        return numScene;
    }

    public GameObject getObjCar()
    {
        //Debug.Log("La información.");
        return objeto;
    }


}
