using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Particles
{

    public class ParticleView : MonoBehaviour
    {
        private ParticleController particleController;
        private void Start()
        {
            StartCoroutine(LifeTime(2f));
        }

        private IEnumerator LifeTime(float time)
        {
            yield return new WaitForSeconds(time);
            particleController.SmokeAboutToDestroy();
            Destroy(gameObject);
        }

        public void ControllerChannelInitialisation(ParticleController particleController)
        {
            this.particleController = particleController;
        }
    }
}
