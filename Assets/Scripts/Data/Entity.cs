using Assets.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour, IDamageable, IAttackable
{
   
    // 멤버 변수
    [SerializeField] protected int _maxHp;
    [SerializeField] protected int _hp;
    [SerializeField] protected int _atk;
    [SerializeField] protected int _def;
    [SerializeField] protected int _aspd;
    [SerializeField] protected bool _dead;

    // 멤버 프로퍼티
    public int MaxHp { get { return _maxHp; } set { _maxHp = value; } }
    public int HP { get { return _hp; } set { _hp = value; } }
    public int ATK { get { return _atk; } set { _atk = value; } }
    public int DEF { get { return _def; } set { _def = value; } }
    public int ASPD { get { return _aspd; } set { _aspd = value; } }
    public bool Dead { get { return _dead; } set { _dead = value; } }

    private void Start()
    {
        _maxHp = 100;
        _hp = 100;
        _atk = 10;
        _def = 5;
        _aspd = 10;
        _dead = false;
    }

    public virtual void ApplyDamage()
    {

    }

    public virtual void Attack()
    {

    }

    public virtual IEnumerator FindTarget()
    {
        yield return null;
    }
}