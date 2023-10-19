using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Golf
{
    public static class GameEvents //нельз€ теперь создать экземпл€р 
    {
        public static event System.Action onCollisionStone;
        public static event System.Action onCollisionStick;
        public static event System.Action onGameStarted;
        public static event System.Action onGameFinished;
        public static event System.Action onEnemyCollision;
        public static event System.Action onEnemyPass;
        public static event System.Action<int> onComboHit;
        public static void CollisionStones(Collision collision)
        {
            onCollisionStone?.Invoke();
        }
        public static void CollisionStick()
        {
            onCollisionStick?.Invoke();
        }
        public static void GameStarted()
        {
            onGameStarted?.Invoke();
        }
        public static void EnemyCollision()
        {
            onEnemyCollision?.Invoke();
        }
        public static void GameFinished()
        {
            onGameFinished?.Invoke();
        }
        public static void EnemyPass()
        {
            onEnemyPass?.Invoke();
        }
        public static void Combo(int i)
        {
            onComboHit?.Invoke(i);
        }
    }
    

}
