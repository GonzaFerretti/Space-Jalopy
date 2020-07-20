using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Characters/BoundaryInfo")]
public class BoundaryInfo : ScriptableObject
{
    public Vector2 min;
    public Vector2 max;
}
