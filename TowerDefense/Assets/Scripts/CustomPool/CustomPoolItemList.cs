using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CustomPool
{
    [CreateAssetMenu(fileName = "Custom Pool Item List", menuName = "Custom Pool Item List")]
    public class CustomPoolItemList : ScriptableObject
    {
        [SerializeField] private string _parentName;
        [SerializeField] private CustomPoolItem[] _items;

        public string ParentName => _parentName;
        public CustomPoolItem[] Items => _items;
    }
}