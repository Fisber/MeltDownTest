using System;
using UnityEngine;

namespace Arena
{
    public class Dock : MonoBehaviour
    {
        [SerializeField] private bool GoalDock;
        [SerializeField] private bool StartDock;

        public bool IsGoalDock()
        {
            return GoalDock;
        }
        
        public bool IsStarDock()
        {
            return StartDock;
        }
    }
}