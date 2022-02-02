using System;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UserInterface : MonoBehaviour
{
    public TMP_Text currentTimeText, finalScreenText;
    public Image finalScreenImage;
    public Timer timer;
    public PauseManager pauseManager;
    public GameObject FinalScreen;
    public Color normalColor, recordColor;

    public void RestartButton()
    {
        SceneManager.LoadScene("Main");
    }
    public void ExitButton()
    {
        SceneManager.LoadScene("Menu");
    }

    private void ShowFinalScreen(bool record)
    {
        FinalScreen.SetActive(true);
        pauseManager.ManagePause();

        if (!record)
        {
            finalScreenText.text = "Record is: " + timer.bestTime + "\nYour time is: " + timer.finalTime.ToString();
        }
        else
        {
            finalScreenText.text = "Congrats, you beat the record! New record is: " + timer.bestTime;
            finalScreenImage.color = recordColor;
        }
    }

    private void Awake()
    {
        Timer.OnWroteDown += ShowFinalScreen;
    }

    private void OnDestroy()
    {
        Timer.OnWroteDown -= ShowFinalScreen;
    }

    private void Start()
    {
        finalScreenImage.color = normalColor;
    }

    private void Update()
    {
        currentTimeText.text = "Time: " + Math.Round(timer.Count(), 1).ToString();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitButton();
        }
    }
}
