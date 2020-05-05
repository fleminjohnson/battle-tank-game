using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Particles
{
    public class ParticleController
    {
        public ParticleController(ParticleView particleView)
        {
            ParticleView = particleView;
            ParticleView.ControllerChannelInitialisation(this);
        }

        public void SmokeAboutToDestroy()
        {
            ParticleServices.Instance.PlayerRespawnRequest();
        }
        public ParticleView ParticleView { get; private set; }
    }
}
