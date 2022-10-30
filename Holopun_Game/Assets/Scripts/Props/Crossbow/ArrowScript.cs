using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private BoxCollider myColl;
    public void DesactiveCollisions()
    {
        myColl.enabled = false;
        rb.useGravity = false;
        rb.isKinematic = true;
    }

    public void ActiveCollisions()
    {
        myColl.enabled = true;
        rb.useGravity = true;
        rb.isKinematic = false;

        rb.AddForce(transform.forward * 20, ForceMode.Impulse);
    }
}
