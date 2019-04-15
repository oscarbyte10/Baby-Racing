using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CircuitoA : MonoBehaviour
{
    //public Transform[] prefabsCoches;
    //private Transform prefabCoche;
    public CinemachineVirtualCamera cam;
    public GameObject[] prefabsCoches;
    private GameObject prefabCoche;
    private Informacion info;
    // Aquí metemos el clon del prefab de coche para en caso de ser necesario retocar sus componentes
    private GameObject player;

    //Componente script a retocar

    // Start is called before the first frame update
    void Start()
    {
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

        cam.Follow = player.transform;
        cam.LookAt = player.transform;

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
        
    }


}
