using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{
    public class Stone : MonoBehaviour
    {
        public static System.Action onCollisionStone; //принадлежит самому классу, а не его экземпл€ру
        public bool isAfect = false;
        private void OnCollisionEnter(Collision collision)
        {
            if(collision.transform.TryGetComponent(out Stone other))
            {
                if (!other.isAfect) 
                {
                    onCollisionStone?.Invoke(); //?. этот объект не €вл€етс€ null, дл€ Unity не стоит делать
                    //if(onCollisionStone != null) onCollisionStone.Invoke(); //равносильно
                      

                }
            }
        }
    }

}

