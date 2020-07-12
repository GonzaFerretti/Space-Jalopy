using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateController : MonoBehaviour
{
    public GameObject _player = null;
    private EnemySpawner _spawner = null;
    public GameObject _gameOverText = null;
    public GameObject _winText = null;
    private bool _waitingForRestart = false;

    void Start()
    {
        Time.timeScale = 1;
        _spawner = GetComponent<EnemySpawner>();
    }

    void Update()
    {
        if(_player == null)
        {
            Time.timeScale = 0;
            _gameOverText.SetActive(true);
            _waitingForRestart = true;
        }

        if(_spawner.currentWaveIndex > _spawner.enemyWaves.Length)
        {
            Time.timeScale = 0;
            _winText.SetActive(true);
        }

        if (_waitingForRestart && Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
