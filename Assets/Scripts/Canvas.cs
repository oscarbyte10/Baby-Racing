using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Canvas : MonoBehaviour
{
    public GameObject objRan;
    public GameObject position;
    public GameObject mapa;
    public GameObject nitro;
    private Material m;
    //Sprites in random box
    public Sprite bib;
    public Sprite ball;
    // List for Sprites
    private List<Sprite> listSprite = new List<Sprite>();
    // 
    private Image image;
    //
    

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        addInList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Adding in to list Sprite object for random choose when it's hit in pick-up
    private void addInList()
    {
        listSprite.Add(bib);
        listSprite.Add(ball);
    }

    //Add function calculate random number and it's choose in list with index
    public void chooseRandomSprite(int n)
    {
        Debug.Log("El número es:" +n);

        // Choose in list with index
        //image.sprite = listSprite[n];
    }
}
