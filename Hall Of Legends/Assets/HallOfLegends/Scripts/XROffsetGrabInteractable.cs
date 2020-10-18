using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class XROffsetGrabInteractable : XRGrabInteractable
{
    Vector3 initialAttachLocalPos;
    Quaternion initialAttachLocalRot;

    // Start is called before the first frame update
    void Start()
    {
        //If an attached tranform is not found. Create one.
        if (!attachTransform)
        {
            //Create a new GameObject named Grab Pivot as a child of this object.
            GameObject grab = new GameObject("Grab Pivot");

            //Ensure that the loca position and rotation is zero
            grab.transform.SetParent(transform, false);

            //Set the attched tranform to the new gameobject.
            attachTransform = grab.transform;
        }

        initialAttachLocalPos = attachTransform.localPosition;
        initialAttachLocalRot = attachTransform.localRotation;
    }

    protected override void OnSelectEnter(XRBaseInteractor interactor)
    {
        if (interactor is XRDirectInteractor)
        {
            attachTransform.position = interactor.transform.position;
            attachTransform.rotation = interactor.transform.rotation;
        }else
            {
                attachTransform.localPosition = initialAttachLocalPos;
                attachTransform.localRotation = initialAttachLocalRot;
            }
        base.OnSelectEnter(interactor);
    }
}
