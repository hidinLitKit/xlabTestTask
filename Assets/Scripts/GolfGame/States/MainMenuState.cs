using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YG;
namespace Golf
{
    public class MainMenuState : GameState
    {
        public LevelController levelController;
        public TMP_Text highScore;
        public GameObject HighScoreBeaten;
        public GameState gameplayState;
        public void PlayGame()
        {
            Exit();
            gameplayState.Enter();
        }
        protected override void OnEnable()
        {
            base.OnEnable();
            YGAdsProvider.TryFullScreenAdWithChance(51);
            //if(PlayerPrefs.HasKey("HighScore")) highScore.text = $"{PlayerPrefs.GetInt("HighScore")}";
            highScore.text = $"{YandexGame.savesData.HighScore}";
            if (PlayerPrefs.HasKey("HighScoreBeaten") && PlayerPrefs.GetInt("HighScoreBeaten") == 1)
            {
                HighScoreBeaten.SetActive(true);
                PlayerPrefs.SetInt("HighScoreBeaten", 0);
            }
        }
    }
}

