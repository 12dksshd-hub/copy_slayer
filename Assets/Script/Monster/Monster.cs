using System;
using UnityEngine;

public abstract class Monster : MonoBehaviour, IHP
{
    [SerializeField]
    protected float maxHP;
    protected float currentHP;

    public event Action OnTakeDamage;

    protected float damage;

    protected Player target;

    [SerializeField]
    private float speed;
    private bool enableAutoMove = true;

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

    public Player Target
    {
        set
        {
            target = value;
        }
    }

    public bool EnableAutoMove
    {
        get { return enableAutoMove; }
        set
        {
            enableAutoMove = value;
        }
    }

    protected virtual void Awake()
    {
        currentHP = maxHP;
    }

    protected virtual void Start()
    {
        
    }

    protected virtual void Update()
    {
        if (enableAutoMove == true)
            Move();
    }

    public abstract void Hit(Damage damage);

    protected void InvokeOnTakeDamage()
    {
        OnTakeDamage?.Invoke();
    }

    private void Move()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
