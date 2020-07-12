using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateController : MonoBehaviour
{
    public GameObject _player = null;
    private EnemySpawner _spawner = null;
    public GameObject _gameOverText = null;
    public GameObject _winText = null;
    private bool _playerWon = false;
    private bool _waitingForRestart = false;

    void Start()
    {
        _spawner = GetComponent<EnemySpawner>();
    }

    void Update()
    {
        if(_player == null)
        {
            _gameOverText.SetActive(true);
            _waitingForRestart = true;

            foreach (BaseProjectile obj in FindObjectsOfType<BaseProjectile>())
            {
                Destroy(obj.gameObject);
            }

            foreach (BaseShip obj in FindObjectsOfType<BaseShip>())
            {
                if (!(obj is PlayerShip))
                {
                    Destroy(obj.gameObject);
                }
            }
        }

        if (_waitingForRestart)
        {
            if (Input.GetKey(KeyCode.R))
            {
                if (_playerWon)
                {
                    SceneManager.LoadScene("MainMenuScene");
                }
                else
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
            }
        }
    }

    public void PlayerWon()
    {
        if (_spawner.currentWaveIndex >= _spawner.enemyWaves.Length)
        {
            _playerWon = true;
            _winText.SetActive(true);

            foreach (BaseProjectile obj in FindObjectsOfType<BaseProjectile>())
            {
                Destroy(obj.gameObject);
            }

            foreach (BaseShip obj in FindObjectsOfType<BaseShip>())
            {
                if (!(obj is PlayerShip))
                {
                    Destroy(obj.gameObject);
                }
            }
        }
    }
}

