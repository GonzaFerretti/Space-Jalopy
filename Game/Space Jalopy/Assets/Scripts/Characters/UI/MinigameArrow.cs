using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinigameArrow : MonoBehaviour
{
    public MinigameDirection direction;
    public Image img;
    private void Start()
    {
        img = GetComponent<Image>();
    }

    public void Init(MinigameDirection _direction)
    {
        direction = _direction;
        img.sprite = _direction.icon;
    }

    public bool Check()
    {
        return Input.GetKeyDown(direction.arrowKey);
    }
}
