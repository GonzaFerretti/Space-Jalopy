using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryChecker : MonoBehaviour
{
    public BoundaryInfo boundaryInfo;
    public Vector2 padding;
    public void Update()
    {
        if (!IsInRange(boundaryInfo.min.x + padding.x, boundaryInfo.max.x - padding.x, transform.position.x) || !IsInRange(boundaryInfo.min.y + padding.y, boundaryInfo.max.y- padding.y, transform.position.y))
        {
            ClampPosition();
        }
    }

    public void ClampPosition()
    {
        Vector3 finalPosition;
        finalPosition.x = Mathf.Clamp(transform.position.x, boundaryInfo.min.x + padding.x, boundaryInfo.max.x - padding.x);
        finalPosition.y = Mathf.Clamp(transform.position.y, boundaryInfo.min.y + padding.y, boundaryInfo.max.y - padding.y);
        finalPosition.z = transform.position.z;
        transform.position = finalPosition;
    }

    public bool IsInRange(float min, float max, float num)
    {
        return num < max && num > min;
    }
}
