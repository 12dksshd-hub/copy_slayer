using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IHP
{
    [SerializeField]
    protected float maxHP;
    protected float currentHP;

    public event Action OnTakeDamage;

    [SerializeField]
    private Animator animator;
    private PlayerAnimationEventSender animationEventSender;
    private PlayerSwordAttackStateBehavior swordAttackStateBehavior;

    private AnimationState currentAnimationState;
    [SerializeField]
    private GameObject swordAttack;

    private HashSet<Monster> detectedMonsters = new HashSet<Monster>();

    [SerializeField]
    private int attackPoint;

    public float MaxHP
    {
        get { return maxHP; }
        protected set { maxHP = value; }
    }

    public float CurrentHP
    {
        get { return currentHP; }
        protected set { currentHP = value; }
    }

    public enum AnimationState
    {
        idle,
        run,
        attack,
        hit,
        die
    }

    public AnimationState CurrentAnimationState
    {
        get
        {
            return currentAnimationState;
        }
    }

    void Awake()
    {
        CurrentHP = MaxHP;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animationEventSender = GetComponentInChildren<PlayerAnimationEventSender>();
        animationEventSender.GiveDamage += GiveDamage;

        swordAttackStateBehavior = animator.GetBehaviour<PlayerSwordAttackStateBehavior>();
        swordAttackStateBehavior.OnAttackEnd += AttackEnd;
    }

    // Update is called once per frame
    void Update()
    {
        if (detectedMonsters.Count == 0)
        {
            TryRun();
        }

        if(detectedMonsters.Count > 0)
        {
            TryAttack();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Monster detectedMonster = collision.GetComponent<Monster>();
        if (detectedMonster != null)
        {
            detectedMonster.Target = this;

            detectedMonsters.Add(detectedMonster);
            Stop();
        }
    }

    private void TryAttack()
    {
        if (currentAnimationState != AnimationState.attack)
        {
            animator.SetTrigger("attack");
            swordAttack.SetActive(true);
            currentAnimationState = AnimationState.attack;
        }
    }

    private void AttackEnd()
    {
        swordAttack.SetActive(false);
        currentAnimationState = AnimationState.idle;
    }

    private void GiveDamage()
    {
        Damage damage = new Damage(attackPoint);

        foreach(Monster detectedMonster in detectedMonsters)
        {
            detectedMonster.Hit(damage);
        }
    }

    public void Hit(Damage damage)
    {
        if (currentHP > 0)
        {
            currentHP -= damage.GetTrueDamage();
            OnTakeDamage?.Invoke();

            //if (currentHP <= 0)
            //    Die();
        }
    }

    private void TryRun()
    {
        if(currentAnimationState != AnimationState.run)
        {
            animator.SetBool("run", true);
            currentAnimationState = AnimationState.run;
        }
    }

    private void Stop()
    {
        animator.SetBool("run", false);
        currentAnimationState = AnimationState.idle;
    }
}
