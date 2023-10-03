using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour
{
    public List<GameObject> NPC;
    public GameObject rainDrops;
    public int npcNum = 0;
    private bool isRaining;
    private Vector3 targetPos;
    public float fogs;
    public void Awake()
    {
        fogs = RenderSettings.fogEndDistance;
        rainDrops.GetComponent<ParticleSystem>().Stop();
        isRaining = false;
        targetPos = new Vector3(NPC[0].transform.position.x, NPC[0].transform.position.y +12f,  NPC[0].transform.position.z);
    }
    void Update()
    {
        if(transform.localPosition!=targetPos)
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPos, 0.1f);
        if(Input.GetKeyDown(KeyCode.Z)) 
        {
            targetPos = ChangeNpc();
            rainDrops.GetComponent<ParticleSystem>().Stop();
            isRaining = false;
        }
        if(isRaining==false && transform.localPosition==targetPos)
        {
            isRaining = true;
            rainDrops.GetComponent<ParticleSystem>().Play();
        }

        
    }
    public Vector3 ChangeNpc()
    {
        npcNum++;
        npcNum = npcNum% 6;
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
