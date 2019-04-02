using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuPausa : MonoBehaviour
{

    [SerializeField] private GameObject pausaMenuUI;

    [SerializeField] private bool esPausa;

    void Star() { }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            esPausa = !esPausa;
        }

        if (esPausa)
        {
            activarMenu();
        }
        else
        {
            desactivarMenu();
        }
    }
    

    void activarMenu()
    {
        Time.timeScale = 0;
        pausaMenuUI.SetActive(true);
    }

    void desactivarMenu()
    {
        Time.timeScale = 1;
        pausaMenuUI.SetActive(false);
    }

    public void continuar(int indiceEscena)
    {
        SceneManager.LoadScene(indiceEscena);
    }
}
