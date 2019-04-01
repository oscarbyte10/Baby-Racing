using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Transform[] waypoints = this.GetComponentsInChildren<Transform>();

        foreach (Transform wp in waypoints)
        {
            Gizmos.DrawSphere(wp.position, 1.0f);
            Gizmos.color = Color.red;
        }
    }

}