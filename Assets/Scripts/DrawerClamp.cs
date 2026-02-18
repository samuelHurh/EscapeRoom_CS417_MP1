using UnityEngine;

public class DrawerClamp : MonoBehaviour
{
    [SerializeField] Transform railOrigin;                 // usually the cabinet frame
    [SerializeField] Vector3 railDirectionLocal = Vector3.forward;
    [SerializeField] float min = 0f;
    [SerializeField] float max = 0.4f;

    void Awake()
    {
        if (!railOrigin) railOrigin = transform.parent;
    }

    void LateUpdate()
    {
        Vector3 dir = railOrigin.TransformDirection(railDirectionLocal).normalized;

        Vector3 p = transform.position;
        float t = Vector3.Dot(p - railOrigin.position, dir);
        t = Mathf.Clamp(t, min, max);

        transform.position = railOrigin.position + dir * t;
    }
}
