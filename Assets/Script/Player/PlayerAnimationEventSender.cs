using System;
using UnityEngine;

public class PlayerAnimationEventSender : MonoBehaviour
{
    public event Action GiveDamage;

    private void OnGiveDamage()
    {
        GiveDamage?.Invoke();
    }
}
