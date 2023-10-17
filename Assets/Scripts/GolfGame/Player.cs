using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Golf
{
    public class Player : MonoBehaviour
    {
        public Transform Stick;
        public Transform Helper;
        public float range = 30f;
        public float speed = 500f;
        public float power = 20f;
        private bool m_isDown = false;
        private Vector3 m_lastPosition;
        [SerializeField] private Animator anim;
        [SerializeField] private AudioSource m_audioSource;
        public void Update()
        {
            m_lastPosition = Helper.position;
            Quaternion rot = Stick.localRotation;
            Quaternion toRot = Quaternion.Euler(0f, 0f, m_isDown ? range :-range);

            rot = Quaternion.RotateTowards(rot, toRot, speed*Time.deltaTime);
            Stick.localRotation = rot;
        }
        private void OnEnable()
        {
            GameEvents.onCollisionStick += AudioPlay;
        }
        private void OnDisable()
        {
            GameEvents.onCollisionStick -= AudioPlay;
        }
        public void AudioPlay()
        {
            m_audioSource.Play();
        }

        public void SetDown(bool value)
        {
            m_isDown=value;

        }
        public void SetAnim()
        {
            anim.SetBool("isDown", m_isDown);
        }
        public void OnCollisionStick(Collider collider)
        {
            if (collider.TryGetComponent(out Rigidbody body))
            {
                //var dir = m_isDown ? Stick.right : -Stick.right;

                var dir =  (Helper.position - m_lastPosition).normalized;
                body.AddForce(dir*power, ForceMode.Impulse);
                if(collider.TryGetComponent(out Stone stone))
                {
                    stone.isAfect = true;
                    GameEvents.CollisionStick();
                }
            }
            Debug.Log("Попал");
        }
    }
}

