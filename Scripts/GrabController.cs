using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabController : MonoBehaviour
{
    public GameObject xrRig;

    private int grabCount;
    private Rigidbody rigidbody;

    private void Start()
    {
        if (xrRig == null)
        {
            xrRig = GameObject.Find("XR Origin");
        }
        grabCount = 0;
        rigidbody = xrRig.GetComponent<Rigidbody>();
    }

    public void Grab()
    {
        grabCount++;
        rigidbody.isKinematic = true;
    }

    public void Pull(Vector3 distance)
    {
        xrRig.transform.Translate(distance);
    }

    public void Release()
    {
        grabCount--;
        if (grabCount == 0)
        {
            rigidbody.isKinematic = false;
        }
    }

    private void Update()
    {

    }
}
