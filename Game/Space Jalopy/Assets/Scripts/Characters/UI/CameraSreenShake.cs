using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSreenShake : MonoBehaviour
{
    public Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void ShakeCamera()
    {
        anim.SetTrigger("shake");
    }
}
