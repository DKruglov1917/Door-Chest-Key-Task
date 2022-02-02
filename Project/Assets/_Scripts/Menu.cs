using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class Menu : MonoBehaviour
{
    public TMP_Text scoreText;

    public void StartButton()
    {
        SceneManager.LoadScene("Main");
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void ClearButton()
    {
        PlayerPrefs.SetFloat("BestTime", 101);
    }

    private void Update()
    {
        if (PlayerPrefs.GetFloat("BestTime") < 100)
            scoreText.text = "Your best time is: " + Math.Round(PlayerPrefs.GetFloat("BestTime"), 2).ToString();
        else
            scoreText.text = null;
    }
}
