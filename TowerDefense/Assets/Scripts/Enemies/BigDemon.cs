using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigDemon : Enemy
{
    [SerializeField] private float _spawnTime = 1f;
    [SerializeField] private GameObject _topEnemy;
    [SerializeField] private GameObject _sideEnemy;
    private float _y5 = 1.37f;
    private float _y4 = 0.08f;
    private float _y3 = -1.26f;
    private float _y2 = -2.52f;
    private float _y1 = -3.86f;
    private float _x;

    private void OnDestroy()
    {
        _x = GetComponent<Transform>().position.x;

        switch (GetComponent<Transform>().position.y)
        {
            case var value when Math.Abs(value - _y5) < 0.5f:
                Instantiate(_topEnemy, new Vector3(_x, _y4), Quaternion.identity);
                Instantiate(_sideEnemy, new Vector3(_x + 1, _y5), Quaternion.identity);
                Instantiate(_sideEnemy, new Vector3(_x - 1, _y5), Quaternion.identity);
                break;
            case var value when Math.Abs(value - _y4) < 0.5f:
                Instantiate(_topEnemy, new Vector3(_x, _y5), Quaternion.identity);
                Instantiate(_topEnemy, new Vector3(_x, _y3), Quaternion.identity);
                Instantiate(_sideEnemy, new Vector3(_x + 1, _y4), Quaternion.identity);
                Instantiate(_sideEnemy, new Vector3(_x - 1, _y4), Quaternion.identity);
                break;
            case var value when Math.Abs(value - _y3) < 0.5f:
                Instantiate(_topEnemy, new Vector3(_x, _y4), Quaternion.identity);
                Instantiate(_topEnemy, new Vector3(_x, _y2), Quaternion.identity);
                Instantiate(_sideEnemy, new Vector3(_x + 1, _y3), Quaternion.identity);
                Instantiate(_sideEnemy, new Vector3(_x - 1, _y3), Quaternion.identity);
                break;
            case var value when Math.Abs(value - _y2) < 0.5f:
                Instantiate(_topEnemy, new Vector3(_x, _y3), Quaternion.identity);
                Instantiate(_topEnemy, new Vector3(_x, _y1), Quaternion.identity);
                Instantiate(_sideEnemy, new Vector3(_x + 1, _y2), Quaternion.identity);
                Instantiate(_sideEnemy, new Vector3(_x - 1, _y2), Quaternion.identity);
                break;
            case var value when Math.Abs(value - _y1) < 0.5f:
                Instantiate(_topEnemy, new Vector3(_x, _y2), Quaternion.identity);
                Instantiate(_sideEnemy, new Vector3(_x + 1, _y1), Quaternion.identity);
                Instantiate(_sideEnemy, new Vector3(_x - 1, _y1), Quaternion.identity);
                break;
        }
    }
}
