using FishNet.Physics;
using FishNet.StringFields;
using UnityEngine;

namespace FishNet.SceneComponents
{
    public class SceneTransition : MonoBehaviour
    {
        [SerializeField] private PhysicsTrigger _trigger;

        private void OnEnable()
        {
            _trigger.Entered += OnEntered;
        }

        private void OnDisable()
        {
            _trigger.Entered -= OnEntered;
        }

        private void OnEntered()
        {
            var sceneLoader = new SceneLoader();
            
            sceneLoader.Load(SceneNames.Game);
        }
    }
}