using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TutorialController : MonoBehaviour
{
    private Dictionary<KeyCode, bool> _movementKeys = new Dictionary<KeyCode, bool>()
    {
        { KeyCode.W, false },
        { KeyCode.A, false },
        { KeyCode.S, false },
        { KeyCode.D, false },
        { KeyCode.Space, false }
    };

    private int _tutorialStep = 1;
    void Start()
    {
        
    }

    void Update()
    {
        bool allKeysTouched = true;
        for (int i = 0; i < _movementKeys.Count; i++)
        {
            allKeysTouched = allKeysTouched && _movementKeys.ElementAt(i).Value;
        }

        if (allKeysTouched && _tutorialStep == 1)
        {
            _tutorialStep = 2;
        }
    }
}
