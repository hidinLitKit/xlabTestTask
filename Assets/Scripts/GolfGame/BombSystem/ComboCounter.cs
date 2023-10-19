using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CartoonFX;
namespace Golf
{
    public class ComboCounter : MonoBehaviour
    {
        private int collCount = 0;
        public GameObject particle;
        private void Start()
        {
            StartCoroutine(WaitForCombo());
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Enemy") collCount++;
        }
        IEnumerator WaitForCombo()
        {
            yield return new WaitForSeconds(0.15f);
            GameEvents.Combo(collCount);
            AnimateCombo();
        }
        private void AnimateCombo()
        {
            if(collCount >=3)
            {
                string newStr = $"COMBO! +{collCount}";
                Debug.Log(newStr);

                GameObject particleInst = Instantiate(particle, this.transform.position, this.transform.rotation);
                 particleInst.GetComponent<CFXR_ParticleText>().UpdateText(newStr);
                Debug.Log(collCount);
            }
        }
    }

}
