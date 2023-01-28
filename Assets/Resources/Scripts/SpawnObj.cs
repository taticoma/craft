using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnObj : MonoBehaviour
{  
    public List<GameObject> itemPref;
    public GameObject spawnBtn;

    public void Start()
    {
        spawnBtn = GameObject.Find("SpanPos");
        itemPref = new List<GameObject>(Resources.LoadAll<GameObject>("ItemPref"));    
    }

    public void SpawnItem()
    {
        int randPref = Random.Range(0, itemPref.Count);
        Instantiate(itemPref[randPref], spawnBtn.transform.position, Quaternion.identity);
    }
}
