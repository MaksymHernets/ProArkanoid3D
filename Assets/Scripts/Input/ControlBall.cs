using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBall : MonoBehaviour
{
    public delegate void Move(float x);
    public event Move EventMove;

    private RaycastHit raycasthit;

    private float distance = 1.3f;

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out raycasthit);
            if ( Mathf.Abs(raycasthit.point.x) < distance ) { EventMove(raycasthit.point.x); }
        }
    }
}
