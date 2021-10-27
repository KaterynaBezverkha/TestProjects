using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    public Text levelText;

    public GameObject menuPanel;
    public GameObject startButton;
    public GameObject continueButton;
    public GameObject pauseButton;

    public Text menuText;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Time.timeScale = 0;
        pauseButton.SetActive(false);
        levelText.enabled = false;
        menuPanel.SetActive(true);
        startButton.SetActive(true);
        continueButton.SetActive(false);
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        menuPanel.SetActive(false);
        levelText.enabled = true;
        pauseButton.SetActive(true);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        menuPanel.SetActive(true);
        menuText.text = "Pause";
        startButton.SetActive(false);
        continueButton.SetActive(true);

    }

    public void ContinueGame()
    {
        Time.timeScale = 1;
        menuPanel.SetActive(false);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }
}
