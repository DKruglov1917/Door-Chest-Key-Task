using UnityEngine;
using System;

public class Timer : MonoBehaviour
{
    public delegate void TimerCount(bool record);
    public static event TimerCount OnWroteDown;

    public float bestTime;
    public float finalTime;
    public float currentTime;

    public float Count()
    {
        if (finalTime == 0)
        {
            currentTime += Time.deltaTime;
        }
        return currentTime;
    }

    public void WriteDownFinalTime()
    {
        finalTime = ((float)Math.Round(currentTime, 2));

        if (finalTime > bestTime)
        {
            OnWroteDown?.Invoke(false);
            return;
        }

        else if (finalTime < bestTime)
        {
            bestTime = finalTime;
            PlayerPrefs.SetFloat("BestTime", bestTime);
            OnWroteDown?.Invoke(true);
        }
    }

    private void Awake()
    {
        Interactable.OnDoorOpen += WriteDownFinalTime;
    }

    private void OnDestroy()
    {
        Interactable.OnDoorOpen -= WriteDownFinalTime;
    }

    private void Start()
    {
        bestTime = PlayerPrefs.GetFloat("BestTime");
    }
}
