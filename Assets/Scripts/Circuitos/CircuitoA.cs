using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Playables;


public class CircuitoA : MonoBehaviour
{
    //public Transform[] prefabsCoches;
    //private Transform prefabCoche;
    public CinemachineVirtualCamera cam;
    public GameObject[] prefabsCoches;
    private GameObject prefabCoche;
    private Informacion info;
    public PlayableDirector director;
    private GameObject Canvas;
    private int contador = 0;
    // Aquí metemos el clon del prefab de coche para en caso de ser necesario retocar sus componentes
    private GameObject player;

    //Componente script a retocar

    // Start is called before the first frame update
    void Start()
    {
        Canvas = GameObject.Find("HUD");
        if (contador == 0)
        {
            empiezaAnimacion();
        }

        info = FindObjectOfType<Informacion>();
        Debug.Log("Informacion de la escena del PJ: " + info.getNameCar());

        // Le metemos un array con los prefabs de los coches
        foreach(GameObject p in prefabsCoches)
        {
            // SI el nombre del coche elegido coincide con el del prefab entonces cogera el prefab con el que coincida
            if(p.name == info.getNameCar())
            {
                prefabCoche = p;

            }

        }
        //new GameObject(info.getNameCar()) = Instantiate(prefabCoche, new Vector3(17.18f, 2, 8.51f), Quaternion.identity);

        //Instantiate(prefabCoche, new Vector3(17.18f, 2, 8.51f), Quaternion.identity).SetActive(true); //
        
        Instantiate(prefabCoche, new Vector3(-24.14f, 2, 8.5f), transform.rotation).SetActive(true);
        player = GameObject.Find(info.getNameCar()+"(Clone)");

       // cam.Follow = player.transform;
        //cam.LookAt = player.transform;

        //player.GetComponent<Component>();
        //Debug.Log("Este es el número del escenario: " + info.getNumCar());
        //
        //Debug.Log("Este es el objeto: " + info.getObjCar().name);
        //player = info.getObjCar();
        //Debug.Log(player.gameObject.name);

        //player = GameObject.Find(info.getNameCar());
        //player = info.getObjCar();
        //Debug.Log(player.gameObject.name);
        //Destroy(GameObject.Find("GameObject1"));
    }

    // Update is called once per frame
    void Update()
    {
        cam.m_Priority = 1000;
        
            cam.enabled = true;
        if (contador != 0)Canvas.SetActive(true);

    }

    void empiezaAnimacion()
    {
      
        director.Play();
       
        contador++;

    }
}
