using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PocketAnItem : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Item"))
            Destroy(collision.transform.gameObject);
    }
}
