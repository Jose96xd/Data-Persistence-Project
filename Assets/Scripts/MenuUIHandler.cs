using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIHandler : MonoBehaviour
{

    void Start()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void getNameInput(string input)
    {
        GameData.Instance.currentPlayerName = input;
        Debug.Log(GameData.Instance.currentPlayerName);
    }

}
