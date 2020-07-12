using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public GameObject _tutorial_image_1 = null;
    public GameObject _tutorial_image_2 = null;
    public GameObject _tutorial_image_3 = null;
    public GameObject _playerShip = null;

    private int _tutorialStep = 1;

    void Start()
    {
        
    }

    void Update()
    {
        if(_tutorialStep == 1)
        {
            bool allKeysTouched = true;

            for (int i = 0; i < _movementKeys.Count; i++)
            {
                allKeysTouched = allKeysTouched && _movementKeys.ElementAt(i).Value;
            }

            if (allKeysTouched && _tutorialStep == 1)
            {
                _tutorialStep = 2;

                _tutorial_image_1.SetActive(false);

                _tutorial_image_2.SetActive(true);

                _playerShip.GetComponent<PlayerShip>().monoprop.Break();
            }

            if (Input.GetKey(KeyCode.W) && _movementKeys[KeyCode.W] == false)
            {
                _movementKeys[KeyCode.W] = true;
            }
            if (Input.GetKey(KeyCode.A) && _movementKeys[KeyCode.A] == false)
            {
                _movementKeys[KeyCode.A] = true;
            }
            if (Input.GetKey(KeyCode.S) && _movementKeys[KeyCode.S] == false)
            {
                _movementKeys[KeyCode.S] = true;
            }
            if (Input.GetKey(KeyCode.D) && _movementKeys[KeyCode.D] == false)
            {
                _movementKeys[KeyCode.D] = true;
            }
            if (Input.GetKey(KeyCode.Space) && _movementKeys[KeyCode.Space] == false)
            {
                _movementKeys[KeyCode.Space] = true;
            }
        }
        else if(_tutorialStep == 2)
        {
            if (_playerShip.GetComponent<PlayerShip>().PartsFullyOkAndNotRepairing())
            {
                _tutorialStep = 3;
                _tutorial_image_2.SetActive(false);

                _tutorial_image_3.SetActive(true);

                Invoke("GoToPlayScene", 7.5f);
            }
        }
    }

    private void GoToPlayScene()
    {
        SceneManager.LoadScene("Scene");
    }
}
