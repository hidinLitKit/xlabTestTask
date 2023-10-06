using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainController : MonoBehaviour
{
    public List<Transform> NPCs;
    public Transform cloud;
    [SerializeField] ParticlesController particles;
    public float moveSpeed = 6f;
    public int targetFramerate;
    
    
    [HideInInspector] public int npcNum = 0;
    private bool m_moved = false;
    private Vector3 targetPos;
    
    public void Awake()
    {
        targetPos = new Vector3(NPCs[0].position.x, cloud.transform.position.y, NPCs[0].position.z);
    }
    void Update()
    {
        Application.targetFrameRate = targetFramerate;

        if (!m_moved)
        {
            return;
        }
        Vector3 offset = (targetPos - cloud.position).normalized * moveSpeed * Time.deltaTime;

        if (Vector3.Distance(cloud.position, targetPos) < offset.magnitude)
        {
            cloud.position = targetPos;
            particles.ActivateParticle();
            m_moved = false;
        }
        else
        {
            cloud.Translate(offset);
        }
    }
    public void MoveCloud()
    {
        if(m_moved) return;
        targetPos = ChangeNpc();
        particles.DeactivateParticle();
        m_moved = true;
    }
    public Vector3 ChangeNpc()
    {
        npcNum++;
        npcNum = npcNum % NPCs.Count;
        Vector3 targetPos = new Vector3(NPCs[npcNum].position.x, cloud.position.y,  NPCs[npcNum].position.z);
        return targetPos;
        
    }

    
}
