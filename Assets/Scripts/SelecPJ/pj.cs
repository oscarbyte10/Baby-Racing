using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pj : MonoBehaviour
{

    public Rigidbody body;
    private Vector3 m_EulerAngleVelocity;
    // Start is called before the first frame update
    void Start()
    {
        //body = GetComponent<Rigidbody>();
        // Velocidad del angulo
        m_EulerAngleVelocity = new Vector3(0, 30, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // calculamos el vector de la posición relativa
        //Vector3 relativePos = body.transform.position;
        // Calculamos rotación
        //Quaternion rotation = Quaternion.LookRotation(relativePos);
        // Añadimos rotación
        //body.MoveRotation(rotation);

    }

    void FixedUpdate()
    {
        Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.deltaTime);
        body.MoveRotation(body.rotation * deltaRotation);
    }
}
