using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneCircuit : MonoBehaviour
{

    private Button[] arrayButton;
    public Sprite[] sprites;
    private Image image;
    private int count = 0;
    private Circuito c;
    public GameManager GM;
    

    // Nombre del circuito
    private Text textBox;

    // Start is called before the first frame update
    void Start()
    {
        GM.setArrayCircuit();
        arrayButton = GetComponentsInChildren<Button>();
        image = GameObject.Find("showCircuit").GetComponent<Image>();
        textBox = GameObject.Find("circuitName").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void showButtonsInConsole()
    {
        for (int i = 0; i < arrayButton.Length; i++)
        {
            //Debug.Log(arrayButton[i].gameObject.name);
        }
    }

    // Visualizamos el circuito anterior
    public void beforeCircuit()
    {
        //Debug.Log("Arriba");
        count--;

        if (count < 0)
        {
            // No haces nada
            count++;
        }
        else
        {
            //Debug.Log("Sprite: " + sprites[count].name);
            image.sprite = sprites[count];
            c = GM.circuitos[count];
            //Debug.Log(c.CircuitName);
            //Debug.Log(c.NumScene);
        }
    }

    // Visualizamos el siguiente circuito
    public void nextCircuit()
    {
        //Debug.Log("Abajo");

        count++;

        if(count >= sprites.Length)
        {
            // No haces nada
            count--;
        }else
        {
            //Debug.Log("Sprite: "+sprites[count].name);
            image.sprite = sprites[count];
            c = GM.circuitos[count];
            //Debug.Log(c.CircuitName);
            //Debug.Log(c.NumScene);
        }

    }


}
