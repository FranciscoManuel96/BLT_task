using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Timer : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI timeText;
    [SerializeField] private DataManager dataManager;

    public float timer;

    void Start()
    {
        //Reset at start to make sure it's 00:00
        ResetTimer();
    }

    void Update()
    {
        //Allows time to be updated through time
        timer += Time.deltaTime;
        float minutes = Mathf.FloorToInt(timer / 60);
        float seconds = Mathf.FloorToInt(timer % 60);
        string currentTime = string.Format("{00:00}:{1:00}", minutes, seconds);

        timeText.text = currentTime.ToString();
    }

    //Resets the timer
    void ResetTimer()
    {
        timer = 0f;
    }
}
