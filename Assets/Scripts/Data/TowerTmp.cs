using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TowerTmp
    {
        public int _maxHp;
        [SerializeField] protected int _hp;
        [SerializeField] protected int _atk;
        [SerializeField] protected int _def;
        [SerializeField] protected int _aspd;
        [SerializeField] protected bool _dead;
        [SerializeField] protected int _id;
        [SerializeField] protected string _name;
        [SerializeField] protected string _rare;
        [SerializeField] protected int _level;
        [SerializeField] protected int _cost;
        [SerializeField] protected int _type;
}
