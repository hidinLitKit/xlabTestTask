using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Golf
{
    public class MainMenuState : GameState
    {
        public LevelController levelController;
        public TMP_Text highScore;
        public GameState gameplayState;
        public void PlayGame()
        {
            Exit();
            gameplayState.Enter();
        }
        protected override void OnEnable()
        {
            base.OnEnable();

            if(PlayerPrefs.HasKey("HighScore")) highScore.text = $" Ћучший счЄт : {PlayerPrefs.GetInt("HighScore")}";
        }
    }
}

