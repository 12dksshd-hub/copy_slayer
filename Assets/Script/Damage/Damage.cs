using UnityEngine;

public struct Damage
{
    private float damage;

    public Damage(float damage)
    {
        this.damage = damage;
    }

    public float GetTrueDamage()
    {
        return damage;
    }
}
