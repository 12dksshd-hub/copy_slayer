using System.Dynamic;
using Unity.VisualScripting;
using UnityEngine;

public class Goblin : Monster
{
    private Animator animator;
    private GoblinAnimationEventSender animationEventSender;

    private AnimationState currentAnimationState = AnimationState.idle;

    private enum AnimationState
    {
        idle,
        attack,
        hit,
        die
    }

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();

        animator = GetComponentInChildren<Animator>();
        
        animationEventSender = GetComponentInChildren<GoblinAnimationEventSender>();
        animationEventSender.OnAttackEnd += AttackEnd;
        animationEventSender.OnHitEnd += HitEnd;
    }

    protected override void Update()
    {
        base.Update();

        TryAttack();
    }

    private void TryAttack()
    {
        if(target != null && currentAnimationState == AnimationState.idle)
        {
            animator.SetTrigger("attack");
            currentAnimationState = AnimationState.attack;
        }
    }

    private void AttackEnd()
    {
        if (currentAnimationState == AnimationState.attack)
            currentAnimationState = AnimationState.idle;
    }

    public override void Hit(Damage damage)
    {
        if(currentHP > 0)
        {
            animator.SetTrigger("hit");
            currentAnimationState = AnimationState.hit;

            currentHP -= damage.GetTrueDamage();
            InvokeOnTakeDamage();

            if (currentHP <= 0)
                Die();
        }
    }

    private void HitEnd()
    {
        if (currentAnimationState == AnimationState.hit)
            currentAnimationState = AnimationState.idle;
    }

    private void Die()
    {
        animator.SetBool("die", true);
        currentAnimationState = AnimationState.die;
    }
}
