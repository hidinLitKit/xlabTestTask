using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Golf
{
    public static class GameEvents //������ ������ ������� ��������� 
    {
        public static event System.Action onCollisionStone;
        public static event System.Action onCollisionStick;
        public static event System.Action onGameStarted;
        public static event System.Action onDown;
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
    }
    

}
