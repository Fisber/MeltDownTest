using SO;
using Player;
using UnityEngine;

namespace Arena
{
    public class ArenaController : MonoBehaviour
    {
        [SerializeField] private Dock[] Docks;
        [SerializeField] private ArenaDocksHolder Holder;

        private void Start()
        {
            InitializeDocks();
        }

        private void InitializeDocks()
        {
            Holder.SetDocks(Docks);
        }
    }
}