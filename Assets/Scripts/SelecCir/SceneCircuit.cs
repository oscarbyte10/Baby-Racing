using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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


    // Start is called before the first frame update
    void Start()
    {
        array = GM.setArrayCircuit();
        image = GameObject.Find("showCircuit").GetComponent<Image>();
        textBox = GameObject.Find("circuitName").GetComponent<Text>();
        beforeCircuit();
        //Debug.Log("Al inicio count es "+count);
    }// Start

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
