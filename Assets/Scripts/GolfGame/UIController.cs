using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
namespace Golf
{
    public  class UIController : MonoBehaviour
    {
        public TextMeshProUGUI scoreField;
        public TextMeshProUGUI maxScoreFiel;
        public void setScore(int scr)
        {
            scoreField.text = "Score: " + scr;
        }
        public void setHighScore(int scr)
        {
            maxScoreFiel.text = "High Score: " + scr;
        }

    }
}

