using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Grab : MonoBehaviour
{
    private XRSimpleInteractable interactable;
    private GrabController grabController;
    private bool isGrabbing;
    private Vector3 handPosition;

    private void Start()
    {
        interactable = GetComponent<XRSimpleInteractable>();
        grabController = GetComponentInParent<GrabController>();
        isGrabbing = false;
    }

    public void Grabbing()
    {
        isGrabbing = true;
        handPosition = InteractorPosition();
        grabController.Grab();
    }

    private Vector3 InteractorPosition()
    {
        List<XRBaseInteractor> interactors = interactable.hoveringInteractors;
        if (interactors.Count > 0)
        {
            return interactors[0].transform.position;
        }
        else
        {
            return handPosition;
        }
    }

    private void Update()
    {
        if (isGrabbing)
        {
            Vector3 delta = handPosition - InteractorPosition();
            grabController.Pull(delta);
            handPosition = InteractorPosition();
        }
    }

    public void Release()
    {
        isGrabbing = false;
        grabController.Release();
    }

}
