using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Data
{
    [Serializable]
    public struct Wave
    {
        public float spawnCycle;
        public int maxEnemyCount;
        public int enemyID;
        public Transform[] wayPoints;

        public Wave(float _spawnCycle, int _maxEnemyCount, int _enemyID, Transform[] _wayPoints)
        {
            this.spawnCycle = _spawnCycle;
            this.maxEnemyCount = _maxEnemyCount;
            this.enemyID = _enemyID;
            this.wayPoints = _wayPoints;
        }
    }
}