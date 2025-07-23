using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool isGameOver = false;

    public void EndGame()
    {
        isGameOver = true;
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }

    public void RestartGame()
    {
        isGameOver = false;
    }
}
