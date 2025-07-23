using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public TMP_Text currentScoreText;
    public TMP_Text highScoreText;

    int currentScoreValue = 0;

    void Start()
    {
        currentScoreText.text = currentScoreValue.ToString();
        UpdateHighScore();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetHighScore();
            UpdateHighScore();
        }
    }

    public int GetHighScore()
    {
        return PlayerPrefs.GetInt("Highscore", 0);
    }

    public void SaveHighScore()
    {
        if (currentScoreValue > GetHighScore())
        {
            PlayerPrefs.SetInt("Highscore", currentScoreValue);
            UpdateHighScore();
        }
    }

    public void UpdateHighScore()
    {
        highScoreText.text = "Highscore: " + GetHighScore().ToString();
    }

    public void ResetHighScore()
    {
        PlayerPrefs.SetInt("Highscore", 0);
        UpdateHighScore();
    }

    public void UpdateCurrentScore()
    {
        currentScoreValue++;
        currentScoreText.text = currentScoreValue.ToString();
    }

    public void ResetCurrentScore()
    {
        currentScoreValue = 0;
        currentScoreText.text = currentScoreValue.ToString();
    }

}
