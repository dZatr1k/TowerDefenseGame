using UnityEngine;

public class LevelEndChecker : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private GameObject _levelCompletePanel;
    
    private Enemy[] _enemies;
    private int _diedEnemies = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            FinishLevel();
        }
    }

    private void OnEnable()
    {
        GameLoop.OnWavesSpawned += TryCompleteLevel;
    }

    private void OnDisable()
    {
        GameLoop.OnWavesSpawned -= TryCompleteLevel;

        if (_enemies == null)
            return;

        for (int i = 0; i < _enemies.Length; i++)
        {
            _enemies[i].OnDied -= CheckEnemies;
        }
    }

    private void FinishLevel()
    {
        Time.timeScale = 0;
        _gameOverPanel.SetActive(true);
    }

    private void SubscribeToEnemiesDeath()
    {
        for (int i = 0; i < _enemies.Length; i++)
        {
            _enemies[i].OnDied += CheckEnemies;
        }

        _diedEnemies = 0;
    }

    private void CheckEnemies()
    {
        _diedEnemies++;
        if(_diedEnemies == _enemies.Length)
        {
            TryCompleteLevel();
        }
    }

    private void TryCompleteLevel()
    {
        _enemies = FindObjectsOfType<Enemy>();

        if(_enemies == null) 
        {
            CompleteLevel();
        }
        else
        {
            SubscribeToEnemiesDeath();
        }
    }

    private void CompleteLevel()
    {
        _levelCompletePanel.SetActive(true);
        if (UnlockLevelData.UnlockLevelsCount == LevelData.LevelIndex) 
        {
            UnlockCardsData.UnlockCardsCount++;
            UnlockLevelData.UnlockLevelsCount++;
        }
    }
}
