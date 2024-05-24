using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{

    public int MaxItemCapacity;
    public int SpawnTimer;

    [SerializeField] private GameObject G_ItemPrefab;

    [SerializeField] private Transform[] TA_ItemSpawnPoints;

    private int I_ItemCount;

    [HideInInspector] public bool B_IsReady;



    void Start()
    {
        I_ItemCount = 0;
        B_IsReady = true;
        CoroutineManager.Instance.StartManagedCoroutine(IENUM_Spawn());
    }


    public IEnumerator IENUM_Spawn()
    {
        yield return new WaitForSeconds(SpawnTimer);

        if (B_IsReady)
        {
            GameObject obj = Instantiate(G_ItemPrefab, TA_ItemSpawnPoints[0]);
            obj.name = G_ItemPrefab.name;
            B_IsReady = false;
        }
    }


}
