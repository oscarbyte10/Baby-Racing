using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScenePjCar : MonoBehaviour
{
    //public GameObject coche1;
    //public GameObject coche2;
    //public int length;
    public GameObject[] coches;
    Transform auxCar = null;
    float x = 0f;
    float y = 0f;
    float z = 0f;
    // Objeto vacío del que recogemos sus coordenadas para colocar los coches que estamos cambiando
    private Text textBox;
    private Vector3 inicial = new Vector3(0f,2.5f,0f);
    private int count = -1;

    

    // Start is called before the first frame update
    void Start()
    {
        textBox = GameObject.Find("carName").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void nextCar()
    {
        //Debug.Log("Siguiente");

        /*
         * Si tenemos un coche ya en la posición inicial y queremos cambiar al siguiente coche debemos de
         * devolver al coche que hay a su posición anterior.
         * Para ello comprobamos si count es mayor de -1, si es así entonces le añadimos al coche la posición
         * que tenía antes de haber sido movido.
         * 
         */
        if(count > -1)
        {
            coches[count].transform.position = new Vector3(x, y, z);
           // Debug.Log("Ahora el coche " + count + " a vuelto a la posición anterior: " + coches[count + 1].transform.position);

        }
        // le sumamos uno para coger el coche que le sigue al que había anteriormente
        count++;
        // Creamos un tranform auxiliar
        auxCar = coches[count].transform;
        // Creamos las coordenadas, en las que guardamos el vector 3 anterior en el que estaba el coche
        x = auxCar.position.x;
        y = auxCar.position.y;
        z = auxCar.position.z;

        // Debug.Log("Guardamos las coordenadas donde estaba el coche: "+x+", "+y+", "+z);
        // Debug.Log("Ahora el coche "+count+" estara en la posición inicial: "+inicial);

        // Mueve el coche a la nueva posición, que es la 0, 2.5, 0 que corresponde a la plataforma inicial
        // la que vamos a ver en el juego
        showCarName(coches[count].gameObject);
        coches[count].transform.position = inicial;
    }

    public void beforeCar()
    {
        /*
         * Si tenemos un coche ya en la posición inicial y queremos cambiar al anterior coche debemos de
         * devolver al coche que hay a su posición anterior.
         * Para ello comprobamos si count es mayor de -1, si es así entonces le añadimos al coche la posición
         * que tenía antes de haber sido movido.
         * 
         */
        //Debug.Log(count);

        if (count > -1)
        {
            coches[count].transform.position = new Vector3(x, y, z);
            //Debug.Log("Ahora el coche " + count + " a vuelto a la posición anterior: " + coches[count].transform.position);

        }
        //Debug.Log("Anterior");
        count--;

        //Debug.Log(count);
        // Creamos un tranform auxiliar
        auxCar = coches[count].transform;
        // Creamos las coordenadas, en las que guardamos el vector 3 anterior en el que estaba el coche
        x = auxCar.position.x;
        y = auxCar.position.y;
        z = auxCar.position.z;

        // Debug.Log("Guardamos las coordenadas donde estaba el coche: " + x + ", " + y + ", " + z);
        // Debug.Log("Ahora el coche " + count + " estara en la posición inicial: " + inicial);

        // Mueve el coche a la nueva posición, que es la 0, 2.5, 0 que corresponde a la plataforma inicial
        // la que vamos a ver en el juego
        showCarName(coches[count]);

        coches[count].transform.position = inicial;


    }

    public void ok()
    {
        string name = coches[count].gameObject.name;
        //Una vez elegido pasamos a la escena de seleccionar circuito
        SceneManager.LoadScene(2);
        Debug.Log(name);
    }

    // Adding car name in textbox
    public void showCarName(GameObject car)
    {
        Debug.Log(car.name);
        //textBox.text = car.name;
        textBox.text = car.name;
    }

}
