using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;


namespace Particles
{
    public class ParticleServices : SingletonBehaviour<ParticleServices>
    {
        [SerializeField]
        private ParticleView particlePrefab;

        public void InitializeSmoke(Vector3 position, IServices controller)
        {
            ParticleView smokeInstance;
            Controller = controller;
            smokeInstance = GameObject.Instantiate<ParticleView>(particlePrefab);
            smokeInstance.transform.position = position + new Vector3(0f, 2.0f, 0f);
            ParticleController particleController = new ParticleController(smokeInstance);
        }

        public IServices Controller { get; private set; }

        public void PlayerRespawnRequest()
        {
            if(Controller != null)
            {
                Controller.RespawnRequest();
            }   
        }
    }
}
