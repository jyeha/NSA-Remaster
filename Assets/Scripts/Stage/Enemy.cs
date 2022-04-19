using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyDestroyType { Kill = 0, Arrive }

public class Enemy : MonoBehaviour
{
    private int waypointCount;
    private Transform[] waypoints;
    private int currentIndex = 0;
    private ObjectMove movement;
    private EnemySpawner enemyspawner;
    
    
    [SerializeField]
    private int cost = 10;

    public float RemainDistance = 0;
    public bool isArrived = false;
    public float speed;

    public void Setup(EnemySpawner enemyspawner, Transform[] waypoint){

        movement = GetComponent<ObjectMove>();
        this.enemyspawner = enemyspawner;

        waypointCount = waypoint.Length;
        this.waypoints = waypoint;

        transform.position = waypoints[currentIndex].position;

        StartCoroutine("EnemyMove");
    }

    private IEnumerator EnemyMove(){
        NextDirection();

        while(true){
            if(Vector3.Distance(transform.position, waypoints[currentIndex].position) < 0.02f * movement.MoveSpeed){
                NextDirection();
            }
            RemainDistance = 0;
            RemainDistance += Vector3.Distance(transform.position, waypoints[currentIndex].position);
            for(int i=currentIndex;i<waypointCount-1;i++){
                RemainDistance += Vector3.Distance(waypoints[currentIndex].position, waypoints[currentIndex+1].position);
            }

            if(RemainDistance == 0) isArrived = true;

            yield return null;
        }
    }

    private void NextDirection(){
        if(currentIndex < waypointCount - 1){
            transform.position = waypoints[currentIndex].position;

            currentIndex++;
            Vector3 direction = (waypoints[currentIndex].position - transform.position).normalized;
            movement.MoveTo(direction);
        }
        else{
            cost = 0;
            OnDie(EnemyDestroyType.Arrive);
        }
    }

    public void OnDie(EnemyDestroyType type){
        enemyspawner.DestroyEnemy(type, this, cost);
    }

}