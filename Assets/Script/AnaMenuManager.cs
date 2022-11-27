using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Device;
using UnityEngine.SceneManagement;

public class AnaMenuManager : MonoBehaviour
{
    void Start()
    {
        if (PlayerPrefs.HasKey("Level"))
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("Level"));
        }
        else
        {
            PlayerPrefs.SetInt("Yildiz", 0);
            PlayerPrefs.SetInt("Level", 1);
            SceneManager.LoadScene(PlayerPrefs.GetInt("Level"));
        }
    }
}
