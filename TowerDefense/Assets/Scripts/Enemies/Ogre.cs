using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ogre : Enemy
{
    [SerializeField] private float _spawnTime = 1f;
    [SerializeField] private GameObject _gameObject;
    [SerializeField] private Transform _spawnPoint5;
    [SerializeField] private Transform _spawnPoint4;
    [SerializeField] private Transform _spawnPoint3;
    [SerializeField] private Transform _spawnPoint2;
    [SerializeField] private Transform _spawnPoint1;
    private float _y5;
    private float _y4;
    private float _y3;
    private float _y2;
    private float _y1;
    private float _x;
    private int _line;

    void Start()
    {
        _y5 = _spawnPoint5.position.y;
        _y4 = _spawnPoint4.position.y;
        _y3 = _spawnPoint3.position.y;
        _y2 = _spawnPoint2.position.y;
        _y1 = _spawnPoint1.position.y;
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        yield return new WaitForSeconds(_spawnTime);
        _x = GetComponent<Transform>().position.x;

        switch (GetComponent<Transform>().position.y)
        {
            case var value when value == _y5:
                Instantiate(_gameObject, new Vector3(_x, _y4), Quaternion.identity);
                break;
            case var value when value == _y4:
                Instantiate(_gameObject, new Vector3(_x, _y5), Quaternion.identity);
                Instantiate(_gameObject, new Vector3(_x, _y3), Quaternion.identity);
                break;
            case var value when value == _y3:
                Instantiate(_gameObject, new Vector3(_x, _y4), Quaternion.identity);
                Instantiate(_gameObject, new Vector3(_x, _y2), Quaternion.identity);
                break;
            case var value when value == _y2:
                Instantiate(_gameObject, new Vector3(_x, _y3), Quaternion.identity);
                Instantiate(_gameObject, new Vector3(_x, _y1), Quaternion.identity);
                break;
            case var value when value == _y1:
                Instantiate(_gameObject, new Vector3(_x, _y2), Quaternion.identity);
                break;
        }
        StartCoroutine(SpawnEnemies());
    }
}