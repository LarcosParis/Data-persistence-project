using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUiHandler : MonoBehaviour
{
    [SerializeField] private TMP_InputField NameInput;
    public Text bestScoreText;

    // Start is called before the first frame update
    void Start()
    {
        bestScoreText.text = "Best Score : " + NameManager.Instance.championName + " : " + NameManager.Instance.highestScore;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartNew()
    {
        NameManager.Instance.userName = NameInput.text;
        SceneManager.LoadScene(1);
        Debug.Log(NameInput.text);
    }

    public void Exit()
    {
        NameManager.Instance.SaveInfo();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}