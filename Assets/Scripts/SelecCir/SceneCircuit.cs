using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneCircuit : MonoBehaviour
{

    public Sprite[] sprites;
    private Image image;
    private int count = 0;
    public GameManager GM;
    // Nombre del circuito
    private Text textBox;
    // Array de circuitos
    private Circuito[] array;
    private Informacion info2;
    public GameObject objPj;
    //private GameObject car;
    // Start is called before the first frame update
    void Start()
    {

        info2 = FindObjectOfType<Informacion>();
        //Debug.Log("Informacion de la escena del PJ: " + info2.getNameCar());
        array = GM.setArrayCircuit();
        image = GameObject.Find("showCircuit").GetComponent<Image>();
        textBox = GameObject.Find("circuitName").GetComponent<Text>();
        beforeCircuit();
        //Debug.Log("Al inicio count es "+count);
    }// Start

    public void okCircuit()
    {
        
        info2.setNumCar(array[count].NumScene);
        //Debug.Log("Este es el nombre del coche: "+info.getNameCar());
        //Debug.Log("Este es el número del escenario: "+ info.getNumCar());
        // Cuando tengamos más circuitos simplemente debemos de añadir el NumScene dentro del LoadScene
        SceneManager.LoadScene(3);
        // 

    }

    // Visualizamos el circuito anterior
    public void beforeCircuit()
    {
        //Debug.Log("Arriba");
        count--;
        //Debug.Log("Cuando le damos al before count es "+count);
        if (count < 0)
        {
            //
            //Debug.Log("Cuando le damos a nextCircuit circuito es " + array[count].CircuitName);
            count =0;
            image.sprite = sprites[count];
            textBox.text = array[count].CircuitName;
            
        }
        else
        {
            //Debug.Log("Cuando le damos a beforeCircuit count es " + count);
            //Debug.Log("Cuando le damos a nextCircuit circuito es " + array[count].CircuitName);
            //Debug.Log("Sprite: " + sprites[count].name);
            image.sprite = sprites[count];
            textBox.text = array[count].CircuitName;
        }

    }//Before circuit

    // Visualizamos el siguiente circuito
    public void nextCircuit()
    {

        count++;
        Debug.Log(count);
        if(count > sprites.Length)
        {
            // No haces nada
            count = sprites.Length - 1;
        }else
        {
            //Debug.Log("Cuando le damos a nextCircuit count es " + count);
            //Debug.Log("Cuando le damos a nextCircuit circuito es " + array[count].CircuitName);
            //Debug.Log("Sprite: "+sprites[count].name);
            image.sprite = sprites[count];
            textBox.text = array[count].CircuitName;
        }

    }//Next circuit
}// Close class
