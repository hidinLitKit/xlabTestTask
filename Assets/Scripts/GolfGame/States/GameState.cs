using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
namespace Golf
{
    public abstract class GameState : MonoBehaviour
    {
        public List<GameObject> views;
        public void Enter()
        {
            gameObject.SetActive(true);
        }
        public void Exit()
        {
            gameObject.SetActive(false);
        }

        protected virtual void OnEnable()
        {
            foreach (var view in views) { view.SetActive(true); }

        }
        protected virtual void OnDisable()
        {
            foreach (var view in views) {if (view!=null) view.SetActive(false); }

        }
    }
}


