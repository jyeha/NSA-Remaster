using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class Tower : Entity
{
    // 멤버 변수
    [SerializeField] protected int _id;
    [SerializeField] protected string _name;
    [SerializeField] protected string _rare;
    [SerializeField] protected int _level;
    [SerializeField] protected int _cost;
    [SerializeField] protected int _type;

    [SerializeField] protected int _isDeployed;

    [SerializeField] protected List<GameObject> _enemyList;

    [SerializeField] protected GameObject target;

    // 멤버 프로퍼티
    public int ID { get { return _id; } set { _id = value; } }
    public string Name { get { return _name; } set { _name = value; } }
    public string Rare { get { return _rare; } set { _rare = value; } }
    public int Level { get { return _level; } set { _level = value; } }
    public int Cost { get { return _cost; } set { _cost = value; } }
    public int Type { get { return _type; } set { _type = value; } }
    public List<GameObject> EnemyList { get { return _enemyList; } set { _enemyList = value; } }

    public void SetValue(Tower tower)
    {
        this._id = tower.ID;
        this._name = tower.Name;
        this._rare = tower.Rare;
        this._level = tower.Level;
        this._cost = tower.Cost;
        this._type = tower.Type;
        this._maxHp = tower.MaxHp;
        this._hp = tower.HP;
        this._atk = tower.ATK;
        this._def = tower.DEF;
        this._aspd = tower.ASPD;
        //_dead = tower.Dead;
    }

    void Start()
    {
        StartCoroutine("FindTarget");
    }

    public void StartAttack()
    {
        StartCoroutine("FindTarget");
        //StartCoroutine("Attack");
    }

    public override IEnumerator FindTarget()
    {
        // 공격 범위 내의 적 중에서 가장 방어지점과 가까운 적을 타겟으로 지정
        while (true)
        {
            if (_enemyList.Count == 0)
            {
                target = null;
            }
            else
            {
                target = _enemyList.OrderBy(x => x.GetComponent<Enemy>().RemainDist).First().gameObject;
            }

            if(target != null)
            {
                Addressables.InstantiateAsync("Bullet", gameObject.transform.position, Quaternion.identity);
            }

            yield return null;
        }

    }

    public override void Attack()
    {
        while (true)
        {
            if (target == null)
            {

            }
            else
            {
                // 총알을 생성해서 날리기
                Addressables.InstantiateAsync("Bullet", gameObject.transform.position, Quaternion.identity);

            }

            //yield return new WaitForSeconds(2f);
        }

    }

}
