using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{
    public class Bomb : Stone
    {
        public GameObject sys;
        public GameObject explRadius;
        [SerializeField] private float m_delay = 2f;
        private MeshRenderer bombMesh;
        private SphereCollider sphereCollider;
        private bool isExploded = false;
        private void Awake()
        {
            bombMesh = gameObject.GetComponent<MeshRenderer>();
            sphereCollider = gameObject.GetComponent<SphereCollider>();
        }
        private void Start()
        {   
            StartCoroutine(CoolDown());
        }
        private void OnEnable()
        {
            GameEvents.onCollisionStone += Explosion;
        }
        private void OnDisable()
        {
            GameEvents.onCollisionStone -= Explosion;
        }
        IEnumerator CoolDown()
        {
            yield return new WaitForSeconds(m_delay);
            Explosion();
        }
        private void HasExploded()
        {
            isExploded = true;
        }
        public void Explosion()
        {
            if (isExploded) return;
            HasExploded();
            bombMesh.enabled = false;
            Instantiate(sys, this.transform.position, this.transform.rotation);
            Instantiate(explRadius, this.transform.position, this.transform.rotation);
            sphereCollider.enabled = false;

        }


    }

}
