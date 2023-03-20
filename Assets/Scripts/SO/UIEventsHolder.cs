using System;
using UnityEngine;

namespace SO
{
    [CreateAssetMenu(menuName = "SO/UIEvent", fileName = "UIEvent")]
    public class UIEventsHolder : ScriptableObject
    {
        public Action OnPlayClick;
        public Action OnWinPopup;
        public Action OnFailPopup;
        public Action OnEscapeClick;
        public bool IsEndGame;
    }
}