using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketManager : MonoBehaviour
{

    [SerializeField] private FireControl fcRef;
    public void DestroyInserted(SelectEnterEventArgs args)
    {
        Destroy(args.interactableObject.transform.gameObject);
        fcRef.IncrementAmmoCount();
    }
}
