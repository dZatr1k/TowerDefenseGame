using UnityEngine;

public class Elf : Thrower
{
    [SerializeField] private float _stunTime;
    [SerializeField] private float _stunChance;

    public float StunTime => _stunTime;
    public float StunChance => _stunChance;
}
