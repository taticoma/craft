using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{


    public void OpenMenuScene()
    {
        SceneManager.LoadScene(0);
    }

    public void OpenSettingsScene()
    {
        SceneManager.LoadScene(1);
    }

    public void OpenLvL1Scene()
    {
        SceneManager.LoadScene(2);
    }

   

}
