using System;
using UnityEngine;

namespace SO
{
    [CreateAssetMenu(menuName = "SO/MoveEvents")]
    public class MoveEventHolder : ScriptableObject
    {
        public Action OnJumpNext;
        public Action OnJumpPrevious;
        public Action OnCrunch;
        public Action UnOnCrunch;
    }
}