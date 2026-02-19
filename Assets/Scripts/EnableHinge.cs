using UnityEngine;

public class EnableHinge : MonoBehaviour
{
    public HingeJoint myHinge;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Lock();
    }

    public void Lock()
    {
        float current = myHinge.angle;

        JointLimits limits = myHinge.limits;
        limits.min = current;
        limits.max = current;

        myHinge.limits = limits;
        myHinge.useLimits = true;
    }
    public void Unlock()
    {
        JointLimits limits = myHinge.limits;
        limits.min = 135f;   // your door range
        limits.max = 0f;

        myHinge.limits = limits;
    }

}
