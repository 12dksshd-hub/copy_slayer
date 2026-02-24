using System;
using UnityEngine;

public interface IHP
{
    public float MaxHP
    {
        get;
    }

    public float CurrentHP
    {
        get;
    }

    public event Action OnTakeDamage;
}
