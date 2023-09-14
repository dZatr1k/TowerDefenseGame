using System;
using System.Collections.Generic;
using UnityEngine;

namespace CustomPool
{
    public class CustomPool : MonoBehaviour
    {
        [SerializeField] private List<CustomPoolItemList> _list;

        private List<GameObject> _cacheObjects;

        private void Start()
        {
            _cacheObjects = new List<GameObject>();

            foreach (var item in _list)
            {
                var parent = new GameObject(item.ParentName);
                foreach (var objects in item.Items)
                {
                    for (int i = 0; i < objects.Count; i++)
                    {
                        var spawnedObject = Instantiate(objects.Prefab, Vector3.zero, 
                            Quaternion.identity, parent.transform);
                        spawnedObject.SetActive(false);
                        _cacheObjects.Add(spawnedObject);
                    }
                }
            }
        }

        public GameObject Instantiate()
        {
            throw new NotImplementedException("CustomPool.Instatiate is not implemented");
        }
    }
}