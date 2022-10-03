using Assets.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Enemy : Entity, IMoveable, IDamageable
{
    private enum State { Move, Blocked, Attack, Killed, Arrived }

    [SerializeField] protected float _moveSpeed;
    [SerializeField] private Vector3 _moveDirection;
    [SerializeField] private Animator _animator;

    // waypoint 관련
    private Transform[] _wayPoints;
    private int _currentIndex = 0;
    private float _remainDist = 0;

    public float MoveSpeed { get { return _moveSpeed; } set { _moveSpeed = value; } }
    public Vector3 MoveDirection { get { return _moveDirection; } set { _moveDirection = value; } }
    public float RemainDist { get { return _remainDist; } set { _remainDist = value; } }

    private void Start()
    {
        _maxHp = 100;
        _hp = 100;
        _atk = 10;
        _def = 5;
        _aspd = 10;
        _dead = false;
        _moveSpeed = 50.0f;

        //if(TryGetComponent<Animator>(out var animator))
        //{
        //    _animator = animator;
        //}
    }

    void Awake()
    {
        if (TryGetComponent<Animator>(out var animator))
        {
            _animator = animator;
        }
    }

    private void Update()
    {
        Move();
        //SetAnimator();
    }

    public void SetValue()
    {

    }

    public void SetRoute(Transform[] waypoints)
    {
        _wayPoints = waypoints;

        transform.position = waypoints[_currentIndex].position;
        
        SetNextWayPoint();
        StartCoroutine("EnemyMovement");
    }

    private IEnumerator EnemyMovement()
    {
        while (true)
        {
            // 목표 waypoint에 거의 도착했다면 다음 waypoint로 방향 설정
            if (Vector3.Distance(transform.position, _wayPoints[_currentIndex].position) < 0.02f * _moveSpeed)
            {
                SetNextWayPoint();
            }

            // 남은 경로 계산
            _remainDist = 0;
            _remainDist += Vector3.Distance(transform.position, _wayPoints[_currentIndex].position);
            for (int i = _currentIndex; i < _wayPoints.Length - 1; i++)
            {
                _remainDist += Vector3.Distance(_wayPoints[_currentIndex].position, _wayPoints[_currentIndex + 1].position);
            }

            //if (_remainDist == 0) isArrived = true;

            yield return null;
        }
    }

    private void SetNextWayPoint()
    {
        // 방어지점 이전의 waypoint까지의 이동
        if (_currentIndex < _wayPoints.Length)
        {
            transform.position = _wayPoints[_currentIndex].position;

            _currentIndex++;

            // 방향 설정 후 이동
            Vector3 direction = (_wayPoints[_currentIndex].position - transform.position).normalized;
            _moveDirection = direction;

            SetAnimator();
        }
        else
        {
            // 방어지점에 도착
            //OnDie(EnemyDestroyType.Arrive);
        }
    }

    private void SetAnimator()
    {
        // animator 지정
        if (_moveDirection == Vector3.up)
        {
            _animator.SetTrigger("Up");
        }
        else if (_moveDirection == Vector3.down)
        {
            _animator.SetTrigger("Down");
        }
        else if (_moveDirection == Vector3.left)
        {
            _animator.SetTrigger("Left");
        }
        else if (_moveDirection == Vector3.right)
        {
            _animator.SetTrigger("Right");
        }
    }

    public void Move()
    {
        transform.position += _moveDirection * _moveSpeed * Time.deltaTime;
    }
}