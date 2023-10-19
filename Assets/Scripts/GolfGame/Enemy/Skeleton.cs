using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Golf
{
    public class Skeleton : MonoBehaviour
    {
        private Animator animator;
        private Spawner spwn;
        public float speed = 2f;
        private bool isStopped = false;
        public GameObject dir;
        public AudioSource deathSound;
        public GameObject freezeFx;
        public GameObject IceCube;
        private void Awake()
        {
            animator = GetComponent<Animator>();
            spwn = GetComponent<Spawner>();
        }
        private void Update()
        {
            if (isStopped) return;
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        public void OnTriggerEnter(Collider oth)
        {
            if(oth.transform.TryGetComponent(out BombExplosion other))
            {
                GameEvents.EnemyCollision();
                Debug.Log("Взрыв");
                if (other.Type == BombExplosion.BombType.NORMAL)
                    SkeletonDies();
                if (other.Type == BombExplosion.BombType.FREEZE)
                    StartCoroutine(SkeletonFrozen());
            }
            if(oth.tag=="NoPass")  GameEvents.EnemyPass();
        }
        public void SkeletonDies()
        {
            GetComponent<Collider>().enabled = false;
            animator.SetBool("IsDead", true);
            spwn.Spawn();
            isStopped = true;
            deathSound.Play();
            StartCoroutine(Dissapear());
        }
        private IEnumerator Dissapear()
        {
            yield return new WaitForSeconds(1f);
            Destroy(this.gameObject);
        }
        private IEnumerator SkeletonFrozen()
        {
            GameObject inst = Instantiate(IceCube, this.transform.position, this.transform.rotation);
            Instantiate(freezeFx, this.transform.position, this.transform.rotation);
            isStopped = true;
            yield return new WaitForSeconds(1.25f);
            isStopped = false;
            Destroy(inst);
        }
    }
}

