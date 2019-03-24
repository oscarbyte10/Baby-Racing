using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Canvas : MonoBehaviour
{
    // Objetos que componen el Canvas
    public Image objRan;
    public Text position;
    // public GameObject mapa;
    // public GameObject nitro;
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
        //objRan.sprite = bib;
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetKey("space"))
        {
            chooseRandomSprite(1);
        }*/
        
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
}
