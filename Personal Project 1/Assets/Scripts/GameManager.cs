using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject gameOverText;
    [SerializeField] TextMeshProUGUI catchValueText;
    [SerializeField] GameObject explosionParticle;
    public AudioClip[] SFX;
    AudioSource audioSource;
    [HideInInspector] public int catchValue;
    [HideInInspector] public int fishValue = 2, treasureValue = 3, garbageValue = -4;
    [HideInInspector] public bool gameIsActive = true;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
        GameObject player = GameObject.Find("Player");
        Instantiate(explosionParticle, player.transform.position, explosionParticle.transform.rotation);
        Destroy(player);
        gameIsActive = false;
        gameOverText.SetActive(true);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void PlaySound(int audioIndex) 
    {
        audioSource.PlayOneShot(SFX[audioIndex]);
    }
}
