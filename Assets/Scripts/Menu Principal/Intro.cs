using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{

    GameManager GM;

    void Awake()
    {
        GM = GameManager.Instance;

        GM.OnStateChange += HandleOnStateChange;

        Debug.Log("Current game state when Awakes: " + GM.gameState);
    }

    public void HandleOnStateChange()
    {
        GM.SetGameState(GameState.MAIN_MENU);
        Debug.Log("Handling state change to: " + GM.gameState);
        Invoke("LoadLevel", 3f);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    // Carga la escena del index que se le ha dicho
    public void LoadByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    // Función para salir del juego, sale completamente del juego
    public void Salir()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }
}
