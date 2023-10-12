using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{
    public class Stone : MonoBehaviour
    {
        public static System.Action onCollisionStone; //����������� ������ ������, � �� ��� ����������
        public static System.Action onCollisionStick;
        public bool isAfect = false;
        private void OnCollisionEnter(Collision collision)
        {
            if(collision.transform.TryGetComponent(out Stone other))
            {
                if (!other.isAfect) 
                {
                    onCollisionStone?.Invoke(); //?. ���� ������ �� �������� null, ��� Unity �� ����� ������
                    //if(onCollisionStone != null) onCollisionStone.Invoke(); //�����������
                }
                
            }
            if (collision.gameObject.tag == "Stick")
            {
                onCollisionStick?.Invoke();
            }
        }
    }

}

