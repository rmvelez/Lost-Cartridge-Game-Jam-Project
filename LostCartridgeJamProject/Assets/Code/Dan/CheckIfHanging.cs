using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfHanging : MonoBehaviour
{
    public static bool isInAir = false;
    public Transform footPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InAirCheck();
        IsHangining();
    }

    private void InAirCheck()
    {
        RaycastHit hit;
        Ray ray = new Ray(footPos.position, Vector3.down);
        Physics.Raycast(ray, out hit);

        isInAir = Vector3.Distance(hit.point, footPos.position) > 0.05;
    }

    private void IsHangining()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        
        if (isInAir && Grapple.holdingWall)
        {
            rb.velocity = Vector3.zero;
            //Freeze constraints unless attacked/jumping/regrappling
            rb.useGravity = false;
        }
        else
        {
            if (!isInAir && Grapple.holdingWall) Grapple.holdingWall = false;
            Grapple.holdingWall = false;
            rb.useGravity = true;
        }
    }
}
