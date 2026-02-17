using UnityEngine;

public enum Handedness { Left, Right }

public class HandRef : MonoBehaviour
{
    public Handedness hand;
    public Rigidbody controllerRigidbody; // assign (usually a kinematic RB on the controller root)
}
