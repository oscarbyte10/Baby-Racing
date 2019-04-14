using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chooseCircuit : MonoBehaviour
{

    private Button[] arrayButton;
    // Start is called before the first frame update
    void Start()
    {
        arrayButton = GetComponentsInChildren<Button>();
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
}
