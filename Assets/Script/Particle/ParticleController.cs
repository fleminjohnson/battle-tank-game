using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Particles
{
    public class ParticleController
    {
        public ParticleController(ParticleView particleView, ParticleModel particleModel)
        {
            ParticleView = particleView;
            ParticleModel = particleModel;
            ParticleView.ControllerChannelInitialisation(this);
        }

        public void SmokeAboutToDestroy()
        {
            ParticleServices.Instance.PlayerRespawnRequest();
        }

        public ParticleView ParticleView { get; private set; }
        public ParticleModel ParticleModel { get; private set; }
    }
}
