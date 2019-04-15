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
        m_EulerAngleVelocity = new Vector3(0, 50, 0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.deltaTime);
        body.MoveRotation(body.rotation * deltaRotation);
    }
}
