using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Golf
{
    public class GolfStickController : MonoBehaviour
    {
        //Use to switch between Force Modes
        enum ModeSwitching { Start, HitAccelerate, ReturnPosition, End };
        ModeSwitching m_ModeSwitching;

        Vector3 m_StartPos, m_StartForce;
        Vector3 m_NewForce;
        public Quaternion m_StartRot;
        Rigidbody m_Rigidbody;

        public Quaternion EndPoint;
        public float acsForce = 0.0f;

        string m_ForceXString = string.Empty;
        string m_ForceYString = string.Empty;

        float m_ForceX, m_ForceY;
        float m_Result;


        void Start()
        {
            m_Rigidbody = GetComponent<Rigidbody>();
            m_ModeSwitching = ModeSwitching.Start;
            m_NewForce = new Vector3(-5.0f, 0.0f, 0.0f);

            m_ForceX = 0;
            m_ForceY = 0;

            m_ForceXString = "0";
            m_ForceYString = "0";

            m_StartPos = transform.position;
            m_StartForce = m_Rigidbody.transform.position;
            //m_StartRot = m_Rigidbody.transform.rotation;
        }
        private void Update()
        {
            if(Input.GetKey(KeyCode.E))
            {
                m_ModeSwitching = ModeSwitching.HitAccelerate;
            }
            if(Input.GetKeyUp(KeyCode.E))
            {
                m_ModeSwitching = ModeSwitching.ReturnPosition;
            }
        }

        void FixedUpdate()
        {
             
            //If the current mode is not the starting mode (or the GameObject is not reset), the force can change
            if (m_ModeSwitching != ModeSwitching.Start)
            {
                //The force changes depending what you input into the text fields
                m_NewForce = new Vector3(m_ForceX, m_ForceY, 0);
            }

            //Here, switching modes depend on button presses in the Game mode
            switch (m_ModeSwitching)
            {
                //This is the starting mode which resets the GameObject
                case ModeSwitching.Start:
                    //This resets the GameObject and Rigidbody to their starting positions
                   // transform.position = m_StartPos;
                    
                    //m_Rigidbody.transform.position = m_StartForce;
                    //m_Rigidbody.transform.rotation = m_StartRot;
                    m_Rigidbody.angularVelocity = new Vector3(0f, 0f, 0f);
                    break;

                //These are the modes ForceMode can force on a Rigidbody
                //This is Acceleration mode
                case ModeSwitching.HitAccelerate:
                    //MakeCustomForce();
                    //m_Rigidbody.AddForce(m_NewForce, ForceMode.Acceleration);
                    m_Rigidbody.AddTorque(-acsForce, 0, 0, ForceMode.Acceleration);
                    if (isEndReached()) m_ModeSwitching = ModeSwitching.End;
                        break;
                case ModeSwitching.ReturnPosition:
                    m_Rigidbody.AddTorque(acsForce,0,0,ForceMode.Acceleration);
                    if (isStartReached()) m_ModeSwitching = ModeSwitching.Start;
                    break;
                case ModeSwitching.End:
                    m_Rigidbody.angularVelocity = new Vector3(0f, 0f, 0f);
                    break;
            }
        }

        bool isEndReached()
        {
            return m_Rigidbody.rotation.x > EndPoint.x ;

        }
        bool isStartReached()
        {
            return m_Rigidbody.rotation.x > m_StartPos.x;
        }

        //Changing strings to floats for the forces
        float ConvertToFloat(string Name)
        {
            float.TryParse(Name, out m_Result);
            return m_Result;
        }

        //Set the converted float from the text fields as the forces to apply to the Rigidbody
        void MakeCustomForce()
        {
            //This converts the strings to floats
            m_ForceX = ConvertToFloat(m_ForceXString);
            m_ForceY = ConvertToFloat(m_ForceYString);
        }
    }

}
