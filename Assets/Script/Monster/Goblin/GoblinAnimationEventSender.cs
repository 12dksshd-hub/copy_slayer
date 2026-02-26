using System;
using UnityEngine;

public class GoblinAnimationEventSender : MonoBehaviour
{
    public event Action OnGiveDamage;
    public event Action OnAttackEnd;
    public event Action OnHitEnd;

    private void GiveDamage()
    {
        OnGiveDamage?.Invoke();
    }

    private void AttackEnd()
    {
        OnAttackEnd?.Invoke();
    }

    private void HitEnd()
    {
        OnHitEnd?.Invoke();
    }
}
