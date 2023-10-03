using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainController : MonoBehaviour
{
    public List<GameObject> NPC;
    public GameObject rainDrops;
    public int npcNum = 0;
    public float moveSpeed = 6f;
    public float fogs;

    private bool isRaining;
    private bool m_moved = false;
    private Vector3 targetPos;
    
    public void Awake()
    {
        fogs = RenderSettings.fogEndDistance;
        rainDrops.GetComponent<ParticleSystem>().Stop();
        isRaining = false;
        targetPos = new Vector3(NPC[0].transform.position.x, NPC[0].transform.position.y +12f,  NPC[0].transform.position.z);
    }
    void Update()
    {
        //2 способ
        //if (!m_moved) return;
        if (transform.localPosition != targetPos)
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPos, 0.1f);
        //transform.localPosition = Vector3.Lerp(transform.localPosition, targetPos, moveSpeed*Time.deltaTime);
        //if (Vector3.Distance(transform.position, targetPos) < 0.1f)
        //{
        //    m_moved = false;
        //}
        if(isRaining==false && transform.localPosition==targetPos)
        {
            isRaining = true;
            rainDrops.GetComponent<ParticleSystem>().Play();
        }   
    }
    public void MoveCloud()
    {
        targetPos = ChangeNpc();
        rainDrops.GetComponent<ParticleSystem>().Stop();
        isRaining = false;
    }
    public Vector3 ChangeNpc()
    {
        npcNum++;
        npcNum = npcNum % NPC.Count;
        Vector3 targetPos = new Vector3(NPC[npcNum].transform.position.x, NPC[npcNum].transform.position.y +12f,  NPC[npcNum].transform.position.z);
        return targetPos;
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
            RenderSettings.fogEndDistance = 19f;
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
            RenderSettings.fogEndDistance = fogs;
    }
    
}
