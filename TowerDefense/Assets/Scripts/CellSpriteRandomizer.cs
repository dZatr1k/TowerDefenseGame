using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellSpriteRandomizer : MonoBehaviour
{
    [SerializeField] private Sprite[] _cellSprites;

    private SpriteRenderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();

        int numOfSprite = Random.Range(0, _cellSprites.Length);
        _renderer.sprite = _cellSprites[numOfSprite];
    }
}
