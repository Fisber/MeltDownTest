using System;
using Arena;
using SO;
using Unity.VisualScripting;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Animator Animator;
        [SerializeField] private MoveEventHolder MoveEventHolder;
        [SerializeField] private AnimationLocker AnimationLocker;
        [SerializeField] private ArenaDocksHolder Docks;
        
        [SerializeField] private float Speed = 1f;

        private Dock CurrentDock;
        private  int Crunch = Animator.StringToHash("Crunch");
        private  int UnCrunch = Animator.StringToHash("UnCrunch");
        private  int Jump = Animator.StringToHash("Jump");

        private void Start()
        {
            Subscribe();
            SetUpPlayerInitialPosition();
        }

        private void OnDestroy()
        {
            UnSubscribe();
        }

        private void Subscribe()
        {
            MoveEventHolder.OnCrunch += CrunchPlayer;
            MoveEventHolder.UnOnCrunch += UnCrunchPlayer;
            MoveEventHolder.OnJumpNext += JumpToTheNextDock;
            MoveEventHolder.OnJumpPrevious += JumpToThePreviousDock;
        }

        private void UnSubscribe()
        {
            MoveEventHolder.OnCrunch -= CrunchPlayer;
            MoveEventHolder.UnOnCrunch -= UnCrunchPlayer;
            MoveEventHolder.OnJumpNext -= JumpToTheNextDock;
            MoveEventHolder.OnJumpPrevious -= JumpToThePreviousDock;
        }

        private void Update()
        {
            if (AnimationLocker.IsCrunch)
            {
                return;
            }
            
            transform.position =
                Vector3.MoveTowards(transform.position, CurrentDock.transform.position, Time.deltaTime * Speed);
        }

        private void SetUpPlayerInitialPosition()
        {
            CurrentDock = Docks.GetStartDock();
            transform.position = CurrentDock.transform.position;
        }

        public void JumpToTheNextDock()
        {
            if (AnimationLocker.IsJumping )
            {
                return;
            }
            
            if (AnimationLocker.IsCrunch)
            {
                return;
            }
            
            CurrentDock = Docks.GetNextPlayerDock();
            transform.LookAt(CurrentDock.transform);
            Animator.SetTrigger(Jump);
        }

        public void JumpToThePreviousDock()
        {
            if (AnimationLocker.IsJumping)
            {
                return;
            }
            
            if (AnimationLocker.IsCrunch)
            {
                return;
            }
            
            CurrentDock = Docks.GetPreviousPlayerDock();
            transform.LookAt(CurrentDock.transform);
            Animator.SetTrigger(Jump);
        }

        public void CrunchPlayer()
        {
            if (AnimationLocker.IsJumping)
            {
                return;
            }
            
            if (AnimationLocker.IsCrunch)
            {
                return;
            }
            
            Animator.SetTrigger(Crunch);
        }

        public void UnCrunchPlayer()
        {
            Animator.SetTrigger(UnCrunch);
        }
    }
}