
using System.Linq;
using Arena;
using UnityEngine;

namespace SO
{
    [CreateAssetMenu(menuName = "SO/ArenaDocks", fileName = "SODocksHolder")]
    public class ArenaDocksHolder : ScriptableObject
    {
        [SerializeField]private Dock[] Docks;

        private int CurrentDock;

        public void SetDocks(Dock[] docks)
        {
            Docks = docks;
        }

        public Dock GetCurrentPlayerDock()
        {
            return Docks[CurrentDock];
        }

        public Dock GetNextPlayerDock()
        {
            CurrentDock = (CurrentDock + 1) % Docks.Length;
            return Docks[CurrentDock];
        }

        public Dock GetPreviousPlayerDock()
        {
            if (--CurrentDock < 0)
            {
                CurrentDock = Docks.Length - 1;
            }

            return Docks[CurrentDock];

        }

        public Dock GetStartDock()
        {
            Dock dock = Docks.FirstOrDefault(s => s.IsStarDock());
            return dock;
        }

        public Dock GetTargetDock()
        {
            Dock dock = Docks.FirstOrDefault(s => s.IsGoalDock());
            return dock;
        }
    }
}