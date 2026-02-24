using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    private Slider hpBar;

    [SerializeField]
    private GameObject target;
    private IHP targetHP;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hpBar = GetComponent<Slider>();
        targetHP = target.GetComponent<IHP>();
        if(targetHP != null)
        {
            UpdateHPBar();
            targetHP.OnTakeDamage += UpdateHPBar;
        }
    }

    private void UpdateHPBar()
    {
        hpBar.value = targetHP.CurrentHP / targetHP.MaxHP;
    }
}
