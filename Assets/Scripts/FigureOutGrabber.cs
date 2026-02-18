using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

[RequireComponent(typeof(XRBaseInteractable))]
public class FigureOutGrabber : MonoBehaviour
{
    public XRDirectInteractor leftDirect;
    public XRDirectInteractor rightDirect;
    public Rigidbody leftRB;
    public Rigidbody rightRB;
    public FireControl fcRef;

    private IXRSelectInteractor primaryInteractor;
    private XRBaseInteractable interactable;

    private void Awake()
    {
        interactable = GetComponent<XRBaseInteractable>();
    }

    public void OnGrab(SelectEnterEventArgs args)
    {
        // First hand wins (0 -> 1). After selectEntered, the list already includes the new interactor.
        if (interactable.interactorsSelecting.Count == 1)
        {
            primaryInteractor = args.interactorObject;
            ApplyHand(primaryInteractor);
        }
    }

    public void OnRelease(SelectExitEventArgs args)
    {
        // Only care if primary released
        if (args.interactorObject != primaryInteractor)
            return;

        // Promote remaining hand if still held
        if (interactable.interactorsSelecting.Count > 0)
        {
            primaryInteractor = interactable.interactorsSelecting[0];
            ApplyHand(primaryInteractor);
        }
        else
        {
            primaryInteractor = null;
        }
    }

    public void OnActivate(ActivateEventArgs args)
    {
        if (args.interactorObject != primaryInteractor)
            return;

        fcRef.Fire();
    }

    private void ApplyHand(IXRSelectInteractor interactor)
    {
        var grabber = interactor.transform.GetComponentInParent<XRDirectInteractor>();

        if (grabber == leftDirect)
            fcRef.SetHandRigidBody(leftRB, true);
        else if (grabber == rightDirect)
            fcRef.SetHandRigidBody(rightRB, false);
    }
}
