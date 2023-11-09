using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Golf
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Player player;
        private bool isDown = false;
        private void Start()
        {
            if(player == null) { Debug.Log("player==null"); }
            OnUp();
        }
        private void Update()
        {
            //player.SetDown(Input.GetMouseButton(0));
        }
        public void OnDown()
        {
            player.SetDown(true);
            player.SetAnim();
        }
        public void OnUp()
        {
            player.SetDown(false);
            player.SetAnim();

        }
        public void onClick()
        {
            isDown = !isDown;
            player.SetDown(isDown);
            player.SetAnim();
        }

    }

}
