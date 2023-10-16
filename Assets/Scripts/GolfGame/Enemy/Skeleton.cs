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
            }
            if(oth.tag=="NoPass")  GameEvents.EnemyPass();
        }
        public void SkeletonDies()
        {
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

    }
}

