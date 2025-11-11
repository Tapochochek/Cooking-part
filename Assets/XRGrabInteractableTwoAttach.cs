using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
          
public class XRGrabInteractableTwoAttach : XRGrabInteractable
{
    public Transform leftAttachTansform;
    public Transform rightAttachTansform;
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        if(args.interactorObject.transform.gameObject.tag == "Left hand")
        {
            attachTransform = leftAttachTansform;
        }
        else if(args.interactableObject.transform.gameObject.tag == "Right hand")
        {
            attachTransform = rightAttachTansform;
        }
        base.OnSelectEntered(args);
    }
}
