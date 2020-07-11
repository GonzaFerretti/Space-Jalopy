using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinigameArrow : MonoBehaviour
{
    public MinigameDirection direction;
    public Image img;

    public void Init(MinigameDirection _direction)
    {
        img = GetComponent<Image>();
        direction = _direction;
        img.sprite = _direction.icon;
    }

    public bool Check()
    {
        return Input.GetKeyDown(direction.arrowKey);
    }
}
