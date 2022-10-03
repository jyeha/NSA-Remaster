using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Data
{
    public class Collider : MonoBehaviour
    {
        [SerializeField] protected List<GameObject> _enemyList;

        void Start()
        {
            _enemyList = gameObject.transform.parent.GetComponent<Tower>().EnemyList;
        }

        void OnTriggerEnter2D(Collider2D o)
        {
            if (o.tag == "Enemy")
            {
                _enemyList.Add(o.gameObject);
            }
        }

        void OnTriggerExit2D(Collider2D o)
        {
            if (o.tag == "Enemy")
            {
                _enemyList.Remove(o.gameObject);
            }
        }
    }
}