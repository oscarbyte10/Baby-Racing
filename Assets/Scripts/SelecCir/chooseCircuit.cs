using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chooseCircuit : MonoBehaviour
{

    private Button[] arrayButton;
    public Sprite[] sprites;
    private Image image;
    private int count = 0;


    // Start is called before the first frame update
    void Start()
    {
        arrayButton = GetComponentsInChildren<Button>();
        image = GameObject.Find("showCircuit").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void showButtonsInConsole()
    {
        for (int i = 0; i < arrayButton.Length; i++)
        {
            Debug.Log(arrayButton[i].gameObject.name);
        }
    }

    // Visualizamos el circuito anterior
    public void beforeCircuit()
    {
        Debug.Log("Arriba");
        count--;

        if (count < 0)
        {
            // No haces nada
            count++;
        }
        else
        {
            Debug.Log("Sprite: " + sprites[count].name);
            image.sprite = sprites[count];
        }
    }

    // Visualizamos el siguiente circuito
    public void nextCircuit()
    {
        Debug.Log("Abajo");

        count++;

        if(count >= sprites.Length)
        {
            // No haces nada
            count--;
        }else
        {
            Debug.Log("Sprite: "+sprites[count].name);
            image.sprite = sprites[count];
            
        }

        
       
    }


}
