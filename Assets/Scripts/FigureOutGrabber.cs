using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Attachment;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class FigureOutGrabber : MonoBehaviour
{

    public XRDirectInteractor leftDirect;
    public XRDirectInteractor rightDirect;
    public Rigidbody leftRB;
    public Rigidbody rightRB;
    public FireControl fcRef;
    public void OnGrab(SelectEnterEventArgs args)
    {
        var interactor = args.interactorObject;
        var grabber = interactor.transform.GetComponent<XRDirectInteractor>();

        if (grabber == leftDirect)
        {
            fcRef.SetHandRigidBody(leftRB, true);
        } else
        {
            fcRef.SetHandRigidBody(rightRB, false);
        }
    }
}
