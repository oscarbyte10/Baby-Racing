using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{

    public Transform hoverPoint;
    private RaycastHit hit;
    public bool isGround;
    public float elevation;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Physics.Raycast(hoverPoint.transform.position, -transform.up, out hit, elevation))
        {
            isGround = true;
        }
        else
        {
            isGround = false;

        }
        Debug.DrawRay(hit.point, hit.normal, Color.red);

    }
}
