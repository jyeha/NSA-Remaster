/* Enemy의 정보를 저장하는 스크립트 */
/* cost: 적을 죽이면 획득할 수 있는 코스트 */
/* waypoint: 적이 이동해야하는 경로 포인트를 저장*/
/* Remain Distance: 방어지점까지의 경로 중 남은 거리 */
/* isArrived: 적이 방어지점에 도착하였는가? */
/* speed: 적의 이동 속도 */
/* currentIndex: waypoint 중 목표 waypoint의 번호 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyDestroyType { Kill = 0, Arrive }

public class past_Enemy : MonoBehaviour
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

    // 적의 이동 경로 설정 및 이동 시작
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
            // 목표 waypoint에 거의 도착했다면 다음 waypoint로 방향 설정
            if(Vector3.Distance(transform.position, waypoints[currentIndex].position) < 0.02f * movement.MoveSpeed){
                NextDirection();
            }

            // 남은 경로 계산
            RemainDistance = 0;
            RemainDistance += Vector3.Distance(transform.position, waypoints[currentIndex].position);
            for(int i=currentIndex;i<waypointCount-1;i++){
                RemainDistance += Vector3.Distance(waypoints[currentIndex].position, waypoints[currentIndex+1].position);
            }

            if(RemainDistance == 0) isArrived = true;

            yield return null;
        }
    }

    // 다음 waypoint로의 방향을 설정
    // 만약 방어지점에 도착할 경우 적을 삭제
    private void NextDirection(){
        // 방어지점 이전의 waypoint까지의 이동
        if(currentIndex < waypointCount - 1){
            transform.position = waypoints[currentIndex].position;

            currentIndex++;
            // 방향 설정 후 이동
            Vector3 direction = (waypoints[currentIndex].position - transform.position).normalized;
            movement.MoveTo(direction);
        }
        else{
            // 마지막 waypoint(방어지점)에 도착
            cost = 0;
            OnDie(EnemyDestroyType.Arrive);
        }
    }

    // 적의 죽음 처리
    // Arrive type - cost 0 으로 삭제
    // Kill type - cost n 으로 삭제
    public void OnDie(EnemyDestroyType type){
        enemyspawner.DestroyEnemy(type, this, cost);
    }

}