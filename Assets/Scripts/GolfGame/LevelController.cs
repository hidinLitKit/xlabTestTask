using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
namespace Golf
{
    public class LevelController : MonoBehaviour
    {
        private enum GameDifficulty
        {
            Easy, Normal, Hard
        }
        public Spawner spawner;
        public Spawner enemySpawn1;
        public Spawner enemySpawn2;
        public TMP_Text scoreText;
        private int score;
        private int maxScore;
        private int isMxScoreBeaten = 0;
        public bool isGameOver = false;

        public float delayMax = 2f;
        public float delayMin = 0.5f;
        public float delayStep = 0.1f;

        public float m_delay = 0.5f;

        private List<GameObject> m_stones = new List<GameObject>();
        //ну короче в апдейте добавляем камушки а потом очищаем весь лист 
        private void Awake()
        {
            score = 0;
            maxScore = 0;
            isMxScoreBeaten = 0;
        }
        void Start()
        {
            //Stone.onCollisionStone += GameOver; //подписка на метод
            //желательно это делать OnEnable, OnDisable, для контроля подписки,отписки
        }
        public void StartGame()
        {
            StartCoroutine(SpawnStone());
        }
        public void EndGame()
        {
            ClearWithTag("Stone");
            ClearWithTag("Enemy");
        }
        private void OnEnable()
        {
            GameEvents.onEnemyCollision += EnemyScore;
            GameEvents.onComboHit += BonusScore;
            GameEvents.onGameStarted += StartGame;
            GameEvents.onGameFinished += EndGame;
            isGameOver = false;
            
            if(PlayerPrefs.HasKey("HighScore"))
            {
                maxScore = PlayerPrefs.GetInt("HighScore");
            }
            score = 0;
            PlayerPrefs.SetInt("HighScoreBeaten", isMxScoreBeaten);

        }
        private void OnDisable()
        {
            GameEvents.onEnemyCollision -= EnemyScore;
            GameEvents.onComboHit -= BonusScore;
            GameEvents.onGameStarted -= StartGame;
            GameEvents.onGameFinished -= EndGame;

            PlayerPrefs.SetInt("HighScore", maxScore);
            PlayerPrefs.SetInt("HighScoreBeaten", isMxScoreBeaten);

        }
        
        private IEnumerator SpawnStone() 
        {
            do
            {
                yield return new WaitForSeconds(m_delay);
                if (isGameOver) break;
                spawner.Spawn();
                enemySpawn1.Spawn();
                enemySpawn2.Spawn();
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

        public void EnemyScore()
        {
            score++;
            UpdateScore();
        }
        public void BonusScore(int x)
        {
            score += x;
            UpdateScore();
        }
        public void UpdateScore()
        {
            if (score > maxScore)
            {
                maxScore = score;
                isMxScoreBeaten = 1;
            }
            scoreText.text = $": {score}";

        }
        public void ClearWithTag(string tag)
        {
            GameObject[] mass;
            mass = GameObject.FindGameObjectsWithTag(tag);

            foreach (GameObject obj in mass)
            {
                Destroy(obj);
            }
        }
    }

}

