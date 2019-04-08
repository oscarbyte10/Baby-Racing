using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToonShaderScript : MonoBehaviour
{

    private Light light = null;
    // Start is called before the first frame update
    private void OnEnable()
    {
        light = this.GetComponent<Light>();
    }

    // Update is called once per frame
    private void Update()
    {
        Shader.SetGlobalVector("_ToonLightDirection", -this.transform.forward);
    }
}
