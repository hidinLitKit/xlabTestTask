using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Golf
{
    public class LevelController : MonoBehaviour
    {
        private enum GameDifficulty
        {
            Easy, Normal, Hard
        }
        public Spawner spawner;
        public UIController UIcon;
        public bool isGameOver = false;
        private int score;
        private int maxScore;
        
        public float delayMax = 2f;
        public float delayMin = 0.5f;
        public float delayStep = 0.1f;

        public float m_delay = 0.5f;
        private void Awake()
        {
            score = 0;
            maxScore = 0;
        }
        void Start()
        {
            
            StartCoroutine(SpawnStoneProc());

            //Stone.onCollisionStone += GameOver; //подписка на метод
            //желательно это делать OnEnable, OnDisable, для контроля подписки,отписки
        }
        private void OnEnable()
        {
            Stone.onCollisionStone += GameOver;
            Stone.onCollisionStick += UpdateScore;
            if(PlayerPrefs.HasKey("HighScore"))
            {
                maxScore = PlayerPrefs.GetInt("HighScore");
            }
        }
        private void OnDisable()
        {
            Stone.onCollisionStone -= GameOver;
            Stone.onCollisionStick -= UpdateScore;

            PlayerPrefs.SetInt("HighScore", maxScore);

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

        private void GameOver()
        {
            Debug.Log("!Gameover");
            isGameOver = true;
        }
        private void UpdateScore()
        {
            score++;
            if(score>maxScore) maxScore = score;
            UIcon.setScore(score);
            UIcon.setHighScore(maxScore);
        }
        public void  NewGame()
        {
            score = 0;
        }
    }

}
