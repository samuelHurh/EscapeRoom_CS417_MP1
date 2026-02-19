using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class SafeManager : MonoBehaviour
{
    public int firstVal;
    public int secondVal;
    public int thirdVal;

    public int[] SafeUnlockCode = {1, 2, 3};

    public XRGrabInteractable drawerRef;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        firstVal = 0;
        secondVal = 0;
        thirdVal = 0;
        drawerRef.enabled = false;
    }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    public void UpdateVal(int newVal, int idx)
    {
        if (idx == 0)
        {
            firstVal = newVal;
        } else if (idx == 1)
        {
            secondVal = newVal;
        } else
        {
            thirdVal = newVal;
        }
        CheckCombo();
    }

    public void CheckCombo()
    {
        if (firstVal == SafeUnlockCode[0] &&
            secondVal == SafeUnlockCode[1] &&
            thirdVal == SafeUnlockCode[2])
        {
            drawerRef.enabled = true;
        }   
    }
}
