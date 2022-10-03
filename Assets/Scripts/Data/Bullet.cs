using Assets.Scripts.Interfaces;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Data
{
    public class Bullet : MonoBehaviour, IMoveable
    {
        [SerializeField] protected float _moveSpeed;
        [SerializeField] private Vector3 _moveDirection;
        [SerializeField] private int _damage;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Move()
        {
            transform.position += _moveDirection * _moveSpeed * Time.deltaTime;
        }

        void OnTriggerEnter2D(Collider2D o)
        {
            if (!o.CompareTag("Enemy")) return;
            //if (o.transform != target) return;

            o.GetComponent<Enemy>().ApplyDamage();
        }
    }
}