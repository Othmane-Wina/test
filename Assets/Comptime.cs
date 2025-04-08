using UnityEngine;
using UnityEngine.UI;
public class Comptime : MonoBehaviour
{
    public Text timerText;
    private float startTime;
    private bool isRunning;
    void Start()
    {
        startTime = Time.time;
        isRunning = true;
    }
    void Update()
    {
        if (isRunning)
        {
            float currentTime = Time.time - startTime;
            DisplayTime(currentTime);
        }
    }
    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}