using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class CharacterStats : MonoBehaviour
{
    private EntityFX fx;
    
    [Range(1, 100)] [SerializeField] private float dmgPercent;
    [Range(1, 100)] [SerializeField] private float healthPercent;
    public bool isInvincible { get; private set; }
    
    [Header("Offensive Stats")]
    public Stat damage;
   
    
    [Header("Defensive Stats")]
    public Stat maxHealth;
   
    
    public int currentHealth;
    
    public System.Action onHealthChanged;
    public bool isDead { get; private set; }

    protected virtual void Start()
    {
        currentHealth = GetMaxHealthValue();

        fx=GetComponent<EntityFX>();
    }

    private void Update()
    {
        
    }

    public virtual void IncreaseStatBy(int _modifier, Stat _statToModify)
    {
        StatMod(_modifier,_statToModify);
    }

    private void StatMod(int _modifier, Stat _statToModify)
    {
        _statToModify.AddModifier(_modifier);
    }
    
    private IEnumerator StatModCoroutine(int _modifier, float _duration, Stat _statToModify)
    {
        _statToModify.AddModifier(_modifier);

        yield return new WaitForSeconds(_duration);
        
        _statToModify.RemoveModifier(_modifier);
    }
    
    public virtual void DoDamage(CharacterStats _targetStats)
    {
        if (_targetStats.TryGetComponent<Entity>(out Entity e))
            e.SetupKnockbackDir(transform);

        int totalDamage = damage.GetValue();
       
        fx.CreateHitFX(_targetStats.transform);
        _targetStats.TakeDamage(totalDamage);
        
    } 
    
    public virtual void TakeDamage(int _damage)
    {
        if(isInvincible)
            return;
        
        DecreaseHealthBy(_damage);
        
        if (TryGetComponent<Entity>(out Entity e))
            e.DamageImpact();
        if (fx != null)
            fx.StartCoroutine("FlashFX");
        if (currentHealth <= 0)
            Die();
        
    }

    public virtual void IncreaseHealthBy(int _amount)
    {
        currentHealth += _amount;

        if (currentHealth > GetMaxHealthValue())
            currentHealth = GetMaxHealthValue();
        if (onHealthChanged != null)
            onHealthChanged();
    }
    
    protected virtual void DecreaseHealthBy(int _damage)
    {
        currentHealth -= _damage;
        
        if(_damage > 0)
            fx.CreatePopUpText(_damage.ToString());
        if (onHealthChanged != null)
            onHealthChanged();
    }
    
    protected virtual void Die()
    {
        isDead = true;
    }
    
    public void KillEntity()
    {
        if (!isDead)
            Die();
    }
    
    public int GetMaxHealthValue() => maxHealth.GetValue() ;
    
    public void MakeInvincible(bool _invincible) => isInvincible = _invincible;

    public virtual void IncreaseDmgPercent()
    {
        damage.AddModifier(Mathf.RoundToInt(damage.GetValue()*(dmgPercent/100)));
    }
    
    public virtual void IncreaseHealthPercent()
    {
        currentHealth += Mathf.RoundToInt(maxHealth.GetValue() * (healthPercent / 100));
    }
    
}