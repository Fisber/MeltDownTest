
using System;
using SO;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameStatusController: MonoBehaviour
    {
        [SerializeField] private UIEventsHolder UIEventsHolder;
        [SerializeField] private bool IsLooperHand;
        [SerializeField] private bool IsWinDock;
        
        private void OnTriggerEnter(Collider other)
        {
            if (UIEventsHolder.IsEndGame)
            {
                return;
            }

            if (IsWinDock )
            {
                UIEventsHolder.IsEndGame = true;
                UIEventsHolder.OnWinPopup?.Invoke();
            }

            if (IsLooperHand)
            {
                UIEventsHolder.IsEndGame = true;
                UIEventsHolder.OnFailPopup?.Invoke();
            }
        }
    }
}