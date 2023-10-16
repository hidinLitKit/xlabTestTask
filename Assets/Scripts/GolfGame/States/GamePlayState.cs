using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Golf
{
    public class GamePlayState : GameState
    {
        public LevelController levelController;
        public PlayerController playerController;
        public GameState gameOverState;
        protected override void OnEnable()
        {
            base.OnEnable();
            levelController.enabled = true;
            playerController.enabled = true;
            GameEvents.GameStarted();
            GameEvents.onCollisionStone += OnGameOver;
            GameEvents.onEnemyPass += OnGameOver;
        }
        private void OnGameOver()
        {
            base.Exit();
            gameOverState.Enter();
        }
        protected override void OnDisable()
        {
            base.OnDisable();
            levelController.enabled = false;
            playerController.enabled = false;
            GameEvents.onCollisionStone -= OnGameOver;
            GameEvents.onEnemyPass -= OnGameOver;
        }
    }
}
