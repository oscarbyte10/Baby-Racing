using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animaciones : MonoBehaviour
{

    private GameObject cocheMesh;
    private Rigidbody coche;
    public float tilt;
    private Animator anim;

    private float _aceleracion = 0f;
    private float _giro = 0f;


    // Start is called before the first frame update
    void Start()
    {
        cocheMesh = this.gameObject;
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        coche = transform.root.GetComponent<Rigidbody>();
        if(coche.velocity.sqrMagnitude > 5f)
        {
            anim.SetFloat("giro", _giro); //al giro del animator
        }
        else
        {
            anim.SetFloat("giro", 0); //al giro del animator
        }

        _giro = Input.GetAxis("Horizontal");
        _aceleracion = Input.GetAxis("Vertical");


        anim.SetFloat("aceleracion", _aceleracion);

    }
}
