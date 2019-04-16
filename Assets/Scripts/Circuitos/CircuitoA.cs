using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Playables;
using UnityEngine.UI;


public class CircuitoA : MonoBehaviour
{
    //public Transform[] prefabsCoches;
    //private Transform prefabCoche;
    public CinemachineVirtualCamera cam;
    public GameObject[] prefabsCoches;
    private GameObject prefabCoche;
    private Informacion info;
    public PlayableDirector director;
    public GameObject canvas;
    private int contador = 0;
    // Aquí metemos el clon del prefab de coche para en caso de ser necesario retocar sus componentes
    private GameObject player;
    public GameObject mensajeStart;
    public Text message;
    //Componente script a retocar

    // Start is called before the first frame update
    void Start()
    {

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

        message = mensajeStart.GetComponent<Text>();

        //new GameObject(info.getNameCar()) = Instantiate(prefabCoche, new Vector3(17.18f, 2, 8.51f), Quaternion.identity);

        //Instantiate(prefabCoche, new Vector3(17.18f, 2, 8.51f), Quaternion.identity).SetActive(true); //

        Instantiate(prefabCoche, new Vector3(-24.14f, 2, 8.5f), transform.rotation).SetActive(true);
        
        player = GameObject.Find(info.getNameCar()+"(Clone)");
        player.GetComponent<Conducir>().enabled = false;
        cam.Follow = player.transform;
        cam.LookAt = player.transform;

       
    }

    // Update is called once per frame
    void Update()
    {
        cam.m_Priority = 1000;
        
            cam.enabled = true;

        if(director.state.ToString() == "Paused")
        {
            /*if (mensajeStart.active == true)
            {
                message.text = "3";
                message.text = "2";
                message.text = "1";
                mensajeStart.SetActive(false);
            }*/

            if (canvas.active == false)
            {
                canvas.SetActive(true);
                player.GetComponent<Conducir>().enabled = true;
            }
        }

        //Debug.Log(director.state);
        //if(contador != 0)canvas.SetActive(true);

    }



    void empiezaAnimacion()
    {

        canvas.SetActive(false);
        director.Play();
        
        contador++;

    }
}
