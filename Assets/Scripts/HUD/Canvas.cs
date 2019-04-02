using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Canvas : MonoBehaviour
{
    // Objetos que componen el Canvas
    public Image objRan;

    public Text position;

    public Image pNitro;
    public Image sNitro;
    public Image tNitro;

    // public GameObject mapa;
    // public GameObject nitro;
    //Sprites nitro
    public Sprite nitroVacio;
    public Sprite nitroLleno;
    //Sprites in random box
    public Sprite bib;
    public Sprite ball;
    public Sprite pacifier;
    public Sprite fbottle;
    // List for Sprites
    private List<Sprite> listSprite = new List<Sprite>();


    // Start is called before the first frame update
    void Start()
    {
        addInList();
        //objRan.sprite = SpriteInterrogante;
        pNitro.sprite = nitroVacio;
        sNitro.sprite = nitroVacio;
        tNitro.sprite = nitroVacio;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("left shift"))
        {
            // Función nitro, vaciar
            
        }
        
    }

    //Adding in to list Sprite object for random choose when it's hit in pick-up
    private void addInList()
    {
        listSprite.Add(bib);
        listSprite.Add(ball);
        listSprite.Add(pacifier);
        listSprite.Add(fbottle);
    }

    //Add function calculate random number and it's choose in list with index
    public void chooseRandomSprite(int n)
    {
        Debug.Log("El número es:" +n);

        // Choose in list with index
        objRan.sprite = listSprite[n];
    }

    public int comprobarNitroVacio()
    {
        if(tNitro.sprite == nitroVacio)
        {
            //está vacío, envíamos un 3
            //comprobamos el siguiente 
            return 3;
        }
        else if (sNitro.sprite == nitroVacio)
        {
            //está vacío, envíamos un 2
            //comprobamos el siguiente
            return 2;
        }
        else if (pNitro.sprite == nitroVacio)
        {
            // está vacío, envíamos un 1
            return 1;
        }

        return 0;
    }

    public int comprobarNitroLleno()
    {
        if (pNitro.sprite == nitroLleno)
        {
            //está lleno, envíamos un 1
            //comprobamos el siguiente 
            return 1;
        }
        else if (sNitro.sprite == nitroLleno)
        {
            //está lleno, envíamos un 2
            //comprobamos el siguiente
            return 2;
        }
        else if (tNitro.sprite == nitroLleno)
        {
            // está lleno, envíamos un 3
            return 3;
        }

        return 0;
    }

    public void vaciarNitro(int n)
    {
        // si n = 1
        // vaciamos solamente el primer nitro
        if (n == 1)
        {
            pNitro.sprite = nitroVacio;
        }

        // si n = 2
        // vaciamos solamente el segundo nitro
        if (n == 2)
        {
            sNitro.sprite = nitroVacio;
        }

        // si n = 3
        // vaciamos solamente el tercer nitro
        if (n == 3)
        {
            tNitro.sprite = nitroVacio;
        }
    }

    public void llenarNitro(int n)
    {
        // si n = 1
        // llenamos solamente el primer nitro
        if(n == 1)
        {
            pNitro.sprite = nitroLleno;
        }
        // si n = 2
        // llenamos solamente el segundo nitro
        if (n == 2)
        {
            sNitro.sprite = nitroLleno;
        }
        // si n = 3
        // llenamos solamente el tercer nitro
        if (n == 3)
        {
            tNitro.sprite = nitroLleno;
        }
    }
}
