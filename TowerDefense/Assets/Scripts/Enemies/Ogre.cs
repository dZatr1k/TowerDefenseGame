using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ogre : Enemy
{
    [SerializeField] private float _spawnTime = 1f;
    [SerializeField] private GameObject _gameObject;
    private float _x;
    private int _line;
    void Start()
    {
        switch (GetComponent<Transform>().position.y)
        {
            case 1.37f:
                _line = 5;
                break;
            case 0.08f:
                _line = 4;
                break;
            case -1.26f:
                _line = 3;
                break;
            case -2.52f:
                _line = 2;
                break;
            case -3.86f:
                _line = 1;
                break;
        }
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        yield return new WaitForSeconds(_spawnTime);
        _x = GetComponent<Transform>().position.x;
        switch (_line)
        {
            case 5:
                Instantiate(_gameObject, new Vector3(_x, 0.08f), Quaternion.identity);
                break;
            case 4:
                Instantiate(_gameObject, new Vector3(_x, 1.37f), Quaternion.identity);
                Instantiate(_gameObject, new Vector3(_x, -1.26f), Quaternion.identity);
                break;
            case 3:
                Instantiate(_gameObject, new Vector3(_x, 0.08f), Quaternion.identity);
                Instantiate(_gameObject, new Vector3(_x, -2.52f), Quaternion.identity);
                break;
            case 2:
                Instantiate(_gameObject, new Vector3(_x, -1.26f), Quaternion.identity);
                Instantiate(_gameObject, new Vector3(_x, -3.86f), Quaternion.identity);
                break;
            case 1:
                Instantiate(_gameObject, new Vector3(_x, -2.52f), Quaternion.identity);
                break;
        }

        StartCoroutine(SpawnEnemies());
    }
}
