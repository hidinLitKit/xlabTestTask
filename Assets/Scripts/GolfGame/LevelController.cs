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

        private List<GameObject> m_stones = new List<GameObject>();
        //ну короче в апдейте добавляем камушки а потом очищаем весь лист 
        private void Awake()
        {
            score = 0;
            maxScore = 0;
        }
        void Start()
        {
            //Stone.onCollisionStone += GameOver; //подписка на метод
            //желательно это делать OnEnable, OnDisable, для контроля подписки,отписки
        }
        private void OnEnable()
        {
            GameEvents.onCollisionStone += GameOver;
            GameEvents.onCollisionStone += UIcon.manageGameOverMenu;
            GameEvents.onCollisionStick += UpdateScore;
            
            if(PlayerPrefs.HasKey("HighScore"))
            {
                maxScore = PlayerPrefs.GetInt("HighScore");
            }
        }
        private void OnDisable()
        {
            GameEvents.onCollisionStone -= GameOver;
            GameEvents.onCollisionStone -= UIcon.manageGameOverMenu;
            GameEvents.onCollisionStick -= UpdateScore;

            PlayerPrefs.SetInt("HighScore", maxScore);

        }
        
        private IEnumerator SpawnStoneProc() 
        {
            do
            {
                
                yield return new WaitForSeconds(m_delay);
                if (isGameOver) break;
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
        public void StartGame()
        {
            isGameOver = false;
            score = 0;
            UIcon.manageMainMenu();
            StartCoroutine(SpawnStoneProc());
        }
        public void ReturnToMain()
        {

            UIcon.manageGameOverMenu();
            UIcon.manageMainMenu();
            ClearStone();
        }
        private void ClearStone()
        {
            GameObject[] stones;
            stones = GameObject.FindGameObjectsWithTag("Stone");

            foreach (GameObject stn in stones)
            {
                Destroy(stn);
            }
        }
    }

}

