using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{
    public class BombExplosion : MonoBehaviour
    {
        public enum BombType
        {
            NORMAL, FREEZE
        }
        [SerializeField] public BombType Type
        {
            set { this.m_Type = Type; }
            get { return m_Type; }
        }
        private BombType m_Type;
        private void Awake()
        {
                
        }

        private void Start()
        {
            StartCoroutine(StopExplosion());
        }

        IEnumerator StopExplosion()
        {
            yield return new WaitForSeconds(0.3f);
            Destroy(this.gameObject);
        }
    }
}

