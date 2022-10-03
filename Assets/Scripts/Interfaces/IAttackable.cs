using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Interfaces
{
    public interface IAttackable
    {
        //void FindTarget();
        void Attack();

        IEnumerator FindTarget();
    }
}