using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TestXlab
{
    //namespace нужен чтобы Unity отличал скрипты с одинаковыми именами
    public class PlayerActController : MonoBehaviour
    {
        public Spawner spawner;
        public RainController rainController;
        public ToolChange toolChange;
        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.X))
            {
                spawner.Spawn();
            }
            if (Input.GetKeyDown(KeyCode.Z))
            {
                rainController.MoveCloud();
            }
            if(Input.GetKeyDown(KeyCode.Space)) 
            {
                toolChange.MakeChange();
            }
        }
    }
}


