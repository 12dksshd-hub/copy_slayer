using System;
using UnityEngine;

public class GoblinAnimationEventSender : MonoBehaviour
{
    public event Action OnAttackEnd;
    public event Action OnHitEnd;

    private void AttackEnd()
    {
        OnAttackEnd?.Invoke();
    }

    private void HitEnd()
    {
        OnHitEnd?.Invoke();
    }
}
