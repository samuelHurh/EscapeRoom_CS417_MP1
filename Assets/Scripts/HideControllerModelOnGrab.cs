using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

[RequireComponent(typeof(XRDirectInteractor))]
public class HideControllerModelOnGrab : MonoBehaviour
{
    [SerializeField] private GameObject controllerModelRoot;

    private XRDirectInteractor direct;

    private void Awake()
    {
        direct = GetComponent<XRDirectInteractor>();
    }

    private void OnEnable()
    {
        direct.selectEntered.AddListener(OnSelectEntered);
        direct.selectExited.AddListener(OnSelectExited);
    }

    private void OnDisable()
    {
        direct.selectEntered.RemoveListener(OnSelectEntered);
        direct.selectExited.RemoveListener(OnSelectExited);
    }

    private void OnSelectEntered(SelectEnterEventArgs args)
    {
        // Hide when this hand grabs anything
        if (controllerModelRoot != null)
            controllerModelRoot.SetActive(false);
    }

    private void OnSelectExited(SelectExitEventArgs args)
    {
        // Show again when this hand releases
        // (This fires when it stops selecting its current object)
        if (controllerModelRoot != null)
            controllerModelRoot.SetActive(true);
    }
}
