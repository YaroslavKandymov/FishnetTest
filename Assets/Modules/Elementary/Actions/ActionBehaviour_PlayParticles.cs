using UnityEngine;

namespace Elementary
{
    [AddComponentMenu("Elementary/Action «Play Particles»")]
    public sealed class ActionBehaviour_PlayParticles : ActionBehaviour   {
        [Space]
        [SerializeField]
        private ParticleSystem[] particleSystems;

        public override void Do()
        {
            for (int i = 0, count = this.particleSystems.Length; i < count; i++)
            {
                var particleSystem = this.particleSystems[i];
                particleSystem.Play(withChildren: true);
            }
        }
    }
}