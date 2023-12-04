using FishNet.Managing;
using FishNet.Transporting;
using GameElements.Unity;
using UnityEngine;

namespace FishNet.Game
{
    public class NetworkGameStateMachine : MonoBehaviour
    {
        [SerializeField] private MonoGameContext _gameContext;
        [SerializeField] private NetworkManager _networkManager;

        private void Awake()
        {
            _gameContext.LoadGame();
            _gameContext.InitGame();
            _gameContext.ReadyGame();
            
            _networkManager.ClientManager.OnClientConnectionState += ClientConnectionState;
        }

        private void OnDisable()
        {
            _gameContext.FinishGame();
        }

        private void ClientConnectionState(ClientConnectionStateArgs args)
        {
            _networkManager.ClientManager.OnClientConnectionState -= ClientConnectionState;

            _gameContext.StartGame();
        }
    }
}