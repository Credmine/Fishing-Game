using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject gameOverText;
    [SerializeField] TextMeshProUGUI catchValueText;
    [HideInInspector] public int catchValue;
    [HideInInspector] public int fishValue = 2, treasureValue = 3, garbageValue = -4;
    [HideInInspector] public bool gameIsActive = true;

    private void Start()
    {
        catchValue = 0;
    }
    private void Update()
    {
        if (catchValue < 0)
        {
            catchValue = 0;
        }
        catchValueText.text = $"Catch Value: ${catchValue}";
    }
    public void EndGame()
    {
        gameOverText.SetActive(true);
        gameIsActive = false;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
