using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CustomPool
{
    [Serializable]
    public class CustomPoolItem
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private int _count;

        public GameObject Prefab => _prefab;
        public int Count => _count;
    }
}