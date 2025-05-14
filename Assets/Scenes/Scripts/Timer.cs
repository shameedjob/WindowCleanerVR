using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;

    void Update() {
        remainingTime -= Time.deltaTime;

        int minuets = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
    
        timerText.text = string.Format("{0:00}:{1:00}", minuets, seconds);
    }
}
