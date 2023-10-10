using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Golf
{
    public class GolfStickController : MonoBehaviour
    {
        public float forceAmmount;
        private bool isPosDefault = true;
        private Rigidbody rb;
        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("pressd");
                rb.AddTorque(-forceAmmount,0,0,ForceMode.Impulse);
                isPosDefault = false;
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                Debug.Log("pressd");
                rb.AddTorque(forceAmmount, 0, 0, ForceMode.Impulse);
                isPosDefault = false;
            }
            
        }
        private void FixedUpdate()
        {
            if (-179 < GetComponent<Transform>().rotation.x && GetComponent<Transform>().rotation.x < -181)
            {
                rb.AddTorque(-rb.velocity * rb.mass, ForceMode.Impulse);
            }

        }
    }

}
