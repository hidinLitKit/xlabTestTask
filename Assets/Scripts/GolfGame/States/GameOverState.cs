using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Golf
{
    public class GameOverState : GameState
    {
        public GameState mainMenuState;
        public LevelController levelController;
        protected override void OnEnable()
        {
            base.OnEnable();
            levelController.isGameOver = true;
        }
        public void Restart()
        {
            levelController.enabled = true;
            GameEvents.GameFinished();
            levelController.enabled = false;

            Exit();
            mainMenuState.Enter();
        }
        protected override void OnDisable()
        {
            base.OnDisable();
            levelController.isGameOver = false;
        }
    }
}