using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Golf
{
    public class MainMenuState : GameState
    {

        public GameState gameplayState;
        public void PlayGame()
        {
            Exit();
            gameplayState.Enter();
        }
    }
}

