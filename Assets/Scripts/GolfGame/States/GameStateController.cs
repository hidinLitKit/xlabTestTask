using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Golf
{
    public class GameStateController : MonoBehaviour
    {
        public MainMenuState mainMenuState;
        private void Start()
        {
            mainMenuState.gameObject.SetActive(true);
        }
    }
}

