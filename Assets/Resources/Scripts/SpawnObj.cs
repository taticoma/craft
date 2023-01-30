using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SpawnObj : MonoBehaviour
{
    public List<GameObject> itemPref;
    public GameObject spawnPos;
    public Button playBtn;
    public Button stopBtn;
    public TMPro.TextMeshProUGUI TimeTextMesh;
    public float playTime;
    public bool clickPlay = false;
    public bool clickOff = false;
    public bool instTriggered = false;
    public int spawnTime;

    public void Start()
    {
        spawnPos = GameObject.Find("SpawnPos");
        itemPref = new List<GameObject>(Resources.LoadAll<GameObject>("ItemPref"));

        stopBtn.onClick.AddListener(StopOnClick);
        playBtn.onClick.AddListener(TaskOnClick);
    }

    private void Update()
    {
        var spawnTrigger = ((int)(playTime * 5)) % spawnTime;

        if (spawnTrigger == 0) instTriggered = false;

        if (clickPlay == true)
        {
            int randPref = UnityEngine.Random.Range(0, itemPref.Count);
            if (spawnTrigger == 1 && instTriggered == false)
            {
                instTriggered = true;
                Instantiate(itemPref[randPref], spawnPos.transform.position, Quaternion.identity);
            }
        }

        //Timer
        TimeTextMesh.text = TimeSpan.FromSeconds(playTime).ToString(@"mm\:ss");

        if (clickPlay == true)
        {
            playTime -= Time.deltaTime;
        }

    }

    public void StopOnClick()
    {
        clickOff = true;  
    }

    public void TaskOnClick()
    {
        clickPlay = true;
    }
}
