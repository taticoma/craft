using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SpawnObj : MonoBehaviour
{
    public List<GameObject> itemPref;
    public List<GameObject> newItemPref;
    public GameObject spawnPos;
    public Button playBtn;
    public Button stopBtn;
    public TMPro.TextMeshProUGUI timeTextMesh;
    public TMPro.TextMeshProUGUI gameTimeTextMesh;
    public float startSpawnPlayTimer;  
    public float gamePlayTimer;
    public bool clickPlay = false;
    public bool clickOff = false;
    public bool instTriggered = false;
    public int spawnTime;
    private GameObject spawnItem = null;
    public SliderBar sliderBar;

    public void Start()
    {
        spawnPos = GameObject.Find("SpawnPos");
        itemPref = new List<GameObject>(Resources.LoadAll<GameObject>("ItemPref"));

        stopBtn.onClick.AddListener(StopOnClick);
        playBtn.onClick.AddListener(TaskOnClick);

        sliderBar.SetMaxValue(startSpawnPlayTimer);
    }

    private void Update()
    {
        var spawnTrigger = ((int)(startSpawnPlayTimer * 5)) % spawnTime;

        if (spawnTrigger == 0) instTriggered = false;

        if (clickPlay == true)
        {
            int randPref = UnityEngine.Random.Range(0, itemPref.Count);
            if (spawnTrigger == 1 && instTriggered == false)
            {
                instTriggered = true;
                spawnItem = Instantiate(itemPref[randPref], spawnPos.transform.position, Quaternion.identity);
                newItemPref.Add(spawnItem);
            }
        }

        //TimerButton
        if (clickPlay == true)
        {
            startSpawnPlayTimer -= Time.deltaTime;
        }
 
        if (startSpawnPlayTimer <= 0)
        {
            startSpawnPlayTimer = 0;
        }

        sliderBar.slider.value = startSpawnPlayTimer;

        //TimerGame
        gameTimeTextMesh.text = TimeSpan.FromSeconds(gamePlayTimer).ToString(@"mm\:ss");
        gamePlayTimer -= Time.deltaTime;

        DestroyItems();
    }

    public void StopOnClick()
    {
       clickOff = true;
       clickPlay = false;
       startSpawnPlayTimer = 0f;
      
    }

    public void TaskOnClick()
    {
        clickPlay = true;
        clickOff = false;
        startSpawnPlayTimer = 30;
    }

    public void DestroyItems()
    {
        if (spawnItem != null && clickOff == true)
        {
            foreach (var spawnItem in newItemPref)
            {
                Destroy(spawnItem);
                newItemPref.Remove(spawnItem);
                break;
            }
        }
    }
}
