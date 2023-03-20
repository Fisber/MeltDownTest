using System;
using SO;
using UnityEngine;

namespace DefaultNamespace
{
    public class SceneInitializer : MonoBehaviour
    {
        [SerializeField] private UIEventsHolder UIEventsHolder;
        
        private GameObject Arena;
        private GameObject Player;
        private GameObject Looper;

        private void Start()
        {
            UIEventsHolder.OnPlayClick += InstantiateArena;
            UIEventsHolder.OnPlayClick += InstantiatePlayer;
            UIEventsHolder.OnPlayClick += InstantiateLooper;
        }

        private void OnDestroy()
        {
            UIEventsHolder.OnPlayClick -= InstantiateArena;
            UIEventsHolder.OnPlayClick -= InstantiatePlayer;
            UIEventsHolder.OnPlayClick -= InstantiateLooper;
        }


        private void InstantiateArena()
        {
            var arena = Resources.Load("Prefabs/Arena") as GameObject;

            Arena = Instantiate(arena, Vector3.zero, Quaternion.identity);
        }

        private void InstantiatePlayer()
        {
            var player = Resources.Load("Prefabs/PlayerHolder") as GameObject;

            Player = Instantiate(player, Vector3.zero, Quaternion.identity);
        }

        private void InstantiateLooper()
        {
            var looper = Resources.Load("Prefabs/LooperHolder") as GameObject;

            Looper = Instantiate(looper, Vector3.zero, Quaternion.identity);
        }
    }
}