using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy;

namespace Enemy.State
{
    [RequireComponent(typeof(EnemyView))]
    public class EnemyState : MonoBehaviour
    {
        protected EnemyView enemyView;

        private void Awake()
        {
            enemyView = GetComponent<EnemyView>();
        }
        public virtual void EnemyEnteringState() 
        {
            this.enabled = true;
        }
        public virtual void EnemyExitingState() 
        {
            this.enabled = false;
        }

        public virtual void Tick() { }
    }
}
