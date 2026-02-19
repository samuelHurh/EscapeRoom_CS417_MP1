using UnityEngine;


public class SafeButton : MonoBehaviour
{
    public UpdatedDisplay udRef;
    
    // // Start is called once before the first execution of Update after the MonoBehaviour is created
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
    public void OnButtonPress0(bool isUp)
    {
        if (isUp)
        {
            udRef.UpdateDisplay(1, 0);
        } else
        {
            udRef.UpdateDisplay(-1, 0);
        }

        
    }
    public void OnButtonPress1(bool isUp)
    {
        if (isUp)
        {
            udRef.UpdateDisplay(1, 1);
        } else
        {
            udRef.UpdateDisplay(-1, 1);
        }

        
    }
    public void OnButtonPress2(bool isUp)
    {
        if (isUp)
        {
            udRef.UpdateDisplay(1, 2);
        } else
        {
            udRef.UpdateDisplay(-1,2);
        }

        
    }
}
