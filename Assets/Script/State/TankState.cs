using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

namespace Tank.State
{
    [RequireComponent(typeof(TankView))]
    public class TankState : MonoBehaviour
    {
        protected TankView tankView;
        [SerializeField]
        protected TankColor tankColor;
        private void Awake()
        {
            tankView = GetComponent<TankView>();
        }
        public virtual void OnEnterState() 
        {
            this.enabled = true;
        }
        public virtual void OnExitState() 
        {
            this.enabled = false;
        }
        public virtual void Tick() { }
    }
}