using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    public static NPCManager instance;
    public ScriptableNPCS[] scriptableNPC;
    [SerializeField] private Transform npcSpawnPosition;
    private void Awake()
    {
        instance = this;
    }
    
    public void BuyNPC(int id)
    {
        Instantiate(scriptableNPC[id].npcPrefab, npcSpawnPosition.position, Quaternion.identity);
    }
}
