using JetBrains.Annotations;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject minus;
    public GameObject plusTwo;

    [Header("Intel")]
    public int maxLives = 100;
    public static int currentLives;
    public static int currentLivesByMistake;
    public int lostLivesBetweenPopup = 5;
    int livesUntilNextPopup;
    int lastNewsIndex = -1;

    //public AudioSource audioSource;
    //public AudioClip loseLifeAudio;
    //public AudioClip gainLifeAudio;

    [Header("UI")]
    public TMP_Text livesText;
    public GameObject consequencePanel;
    public TMP_Text consequenceText;

    public void Awake()
    {
        Instance = this;
        consequencePanel.SetActive(false);
        currentLives = maxLives;
        UpdateUI();
        livesUntilNextPopup = lostLivesBetweenPopup;
        minus.SetActive(false);
        plusTwo.SetActive(false);

    }

    public void LoseLife()
    {
        plusTwo.SetActive(false);
        minus.SetActive(true);
        currentLives--;
        livesUntilNextPopup--;
        UpdateUI();
        //audioSource.PlayOneShot(loseLifeAudio);
        if (livesUntilNextPopup <= 0)
        {
            ShowConsequencesUI();
        }
        if (currentLives <= 0)
        {
            Debug.Log("Game Over!");
            SceneManager.LoadScene(3);
        }
        Invoke("DisableMinus", 0.5f);
    }

    public void LoseLifeMistake()
    {
        plusTwo.SetActive(false);
        minus.SetActive(true);
        currentLivesByMistake++;
        currentLives--;
        livesUntilNextPopup--;
        UpdateUI();
        //audioSource.PlayOneShot(loseLifeAudio);
        if (livesUntilNextPopup <= 0)
        {
            ShowConsequencesUI();
        }

        if (currentLives <= 0)
        {
            Debug.Log("Game Over!");
        }
        Invoke("DisableMinus", 0.5f);
    }
    void DisableMinus()
    {
        minus.SetActive(false);
    }

    public void GainLife()
    {
        minus.SetActive(false);
        plusTwo.SetActive(true);
        //audioSource.PlayOneShot(gainLifeAudio);
        UpdateUI();
        GameManager.currentLives++;
        Invoke("DisablePlus", 0.5f);
    }
    void DisablePlus()
    {
        plusTwo.SetActive(false);
    }

    void UpdateUI()
    {
        if (livesText != null)
            livesText.text = "Intel: " + currentLives;
    }
    void ShowConsequencesUI()
    {
        livesUntilNextPopup = lostLivesBetweenPopup;
        List<string> newsReport = new List<string>
        {
            "The chef wasn't informed of an allergy, seven dead.",
            "The bad intel led a groups of soldiers into an ambush.",
            "Error404 intel not found.",
            "Intelligence of an attack never made it to base."
        };
        int randomIndex;
        do
        {
            randomIndex = Random.Range(0, newsReport.Count);
        }
        while (randomIndex == lastNewsIndex && newsReport.Count > 1);
        {

        }
        lastNewsIndex = randomIndex;
        string randomNewsReport = newsReport[randomIndex];
        consequenceText.text = randomNewsReport;
        Invoke("DisableText", 5f);
    }
    void DisableText()
        //Made by Johan
    {
        consequencePanel.SetActive(false);
    }
}