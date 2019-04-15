using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { INTRO, MAIN_MENU }

public delegate void OnStateChangeHandler();

public class GameManager : MonoBehaviour
{

    // GameManager create
    protected GameManager() { }
    private static GameManager instance = null;
    public event OnStateChangeHandler OnStateChange;
    public GameState gameState { get; private set; }


    public int numeroDeCircuitos = 2;
    private string[] arrayNameCircuits = {"Cubo y pala", "Guarderia"};
    int numScene = 4;

    

    

    public static GameManager Instance
    {
        get
        {
            if (GameManager.instance == null)
            {
                DontDestroyOnLoad(GameManager.instance);
                GameManager.instance = new GameManager();
            }
            return GameManager.instance;
        }

    }


    public void SetGameState(GameState state)
    {
        this.gameState = state;
        OnStateChange();
    }


    public Circuito[] setArrayCircuit()
    {
        Circuito[] circuitos = new Circuito[numeroDeCircuitos];
        for(int i=0; i < numeroDeCircuitos; i++)
        {
            //Debug.Log(i);
            circuitos[i] = new Circuito(arrayNameCircuits[i], numScene);
            //Debug.Log("Circuitos creados: "+arrayNameCircuits[i]+" con escenario numero "+numScene);
            numScene++;
        }

        return circuitos;
    }

    // Start is called before the first frame update
    void Start()
    {
        //setArrayCircuit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
