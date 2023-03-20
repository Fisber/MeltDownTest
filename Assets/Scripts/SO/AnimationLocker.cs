using UnityEngine;

namespace SO
{
    [CreateAssetMenu(menuName = "SO/AnimationLocker", fileName = "AnimationLocker")]
    public class AnimationLocker : ScriptableObject
    {
        public bool IsCrunch;
        public bool IsJumping;
    }
}