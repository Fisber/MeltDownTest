using System;
using SO;
using UnityEngine;
using UnityEngine.Events;

namespace DefaultNamespace
{
    public class MoveController : MonoBehaviour
    {
        [SerializeField] private MoveEventHolder MoveEventHolder;

        private bool IsCrunched;
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                MoveEventHolder.OnJumpNext?.Invoke();
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                MoveEventHolder.OnJumpPrevious?.Invoke();
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                IsCrunched = true;
                MoveEventHolder.OnCrunch?.Invoke();
            }
            
            if (Input.GetKeyUp(KeyCode.DownArrow) && IsCrunched)
            {
                IsCrunched = false;
                MoveEventHolder.UnOnCrunch?.Invoke();
            }
            
        }
    }
}