using UnityEngine;

public abstract class Monster : MonoBehaviour
{
    [SerializeField]
    protected float maxHP;
    protected float currentHP;

    protected float damage;

    protected Player target;

    [SerializeField]
    private float speed;
    private bool enableAutoMove = true;

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

    protected virtual void Start()
    {
        currentHP = maxHP;
    }

    protected virtual void Update()
    {
        if (enableAutoMove == true)
            Move();
    }

    public abstract void Hit(Damage damage);

    private void Move()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
