using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketManager : MonoBehaviour
{

    [SerializeField] private FireControl fcRef;
    public void DestroyInserted(SelectEnterEventArgs args)
    {
        int ammo_amt;
        if (args.interactableObject.transform.gameObject.tag == "shell")
        {
            ammo_amt = 1;
        } else
        {
            ammo_amt = 5;
        }
        Destroy(args.interactableObject.transform.gameObject);
        fcRef.AddAmmo(ammo_amt);
    }
}
