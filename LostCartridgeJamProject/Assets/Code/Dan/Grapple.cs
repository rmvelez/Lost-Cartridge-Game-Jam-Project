using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour
{
    public static bool holdingWall = false;
    public float timeToMove;

    private RaycastHit target;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        PullToward();
    }

    private void PullToward()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            target = LineOfSight.hit;
            StartCoroutine(MoveObjectTowardsOther(!target.transform.CompareTag("Item")));
        }
    }

    private IEnumerator MoveObjectTowardsOther(bool movePlayer)
    {
        holdingWall = true;
        float timeElapsed = 0;
        Vector3 origin = movePlayer ? transform.position : target.point;
        Vector3 end = movePlayer ? target.point : transform.position;

        while (timeElapsed < timeToMove)
        {
            if(movePlayer)
                transform.position = Vector3.Lerp(origin, end + Vector3.down * 0.5f, timeElapsed / timeToMove);
            else
                target.transform.position = Vector3.Lerp(origin, end + Vector3.up * 1.5f, timeElapsed / timeToMove);
            //add case for pulling enemy
            timeElapsed += Time.deltaTime;

            yield return new WaitForEndOfFrame();
        }
        if (movePlayer)
            transform.position = target.point + Vector3.down * 0.5f;
        else
            target.transform.position = transform.position + Vector3.up * 1.5f;
    }
}
