using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Golf
{
    public class LevelController : MonoBehaviour
    {
        public Spawner spawner;
        public bool isGameOver = false; 

        public float delayMax = 2f;
        public float delayMin = 0.5f;
        public float delayStep = 0.1f;

        public float m_delay = 0.5f;
        void Start()
        {
            StartCoroutine(SpawnStoneProc());
            //Stone.onCollisionStone += GameOver; //подписка на метод
            //желательно это делать OnEnable, OnDisable, для контроля подписки,отписки
        }
        private void OnEnable()
        {
            Stone.onCollisionStone += GameOver;
        }
        private void OnDisable()
        {
            Stone.onCollisionStone -= GameOver;
        }
        private void GameOver()
        {
            Debug.Log("!Gameover");
            isGameOver = true;
        }
        private IEnumerator SpawnStoneProc() 
        {
            do
            {
                yield return new WaitForSeconds(m_delay);
                spawner.Spawn();
                RefreshDelay();
            }
            while (!isGameOver);
            
            yield return null;
        }

        public void RefreshDelay()
        {
            m_delay = UnityEngine.Random.Range(delayMin, delayMax);
            delayMax = Mathf.Max(delayMin, delayMax - delayStep);   
        }
    }

}
