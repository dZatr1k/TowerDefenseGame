using UnityEngine;

public class Elf : Thrower
{
    [SerializeField] private float _stunTime;

    public float StunTime => _stunTime;
}
