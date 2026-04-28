using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FailState : MonoBehaviour
{
    private int friendliesKilled;
    private int wavesDone;
    public TextMeshProUGUI kills;
    public TextMeshProUGUI waves;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        friendliesKilled = GameManager.currentLivesByMistake;
        wavesDone = WaveController.currentWave--; 
        
        kills.text = friendliesKilled.ToString();
        waves.text = wavesDone.ToString();
    }
    public void retry()
    {
        SceneManager.LoadScene(1);
        GameManager.currentLivesByMistake = 0;
        WaveController.currentWave = 1;
        GameManager.currentLives = 10;
        WaveController.endNumber = 0;
    }
}
