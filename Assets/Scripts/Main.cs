using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    [SerializeField] GameObject gamePanel;
    [SerializeField] GameObject loadingPanel;
    [SerializeField] GameObject gameButton;
    [SerializeField] GameObject[] players;
    [SerializeField] SoundEffector soundEffector;
    private int currentPlayers = -1;
    void Start()
    {
       
    }
    public void VisiblePanel() {
        soundEffector.PlayStartSound();
        gamePanel.SetActive(true);
        gameButton.SetActive(false);
        
    }
    public void Back()
    {
        gamePanel.SetActive(false);
        gameButton.SetActive(true);
    }
    public void AddPlayer() {
        soundEffector.PlayNextLevelSound();
        currentPlayers++;
        if (currentPlayers >= players.Length - 1)
        {
            currentPlayers = players.Length - 1;
        }
        
        players[currentPlayers].SetActive(true);
        
    
      

        print(currentPlayers);
       
    }
    public void DelPlayer()
    {
        soundEffector.PlayNextLevelSound();
        if (currentPlayers < 0)
        {
            currentPlayers = 0;
        }
        players[currentPlayers].SetActive(false);
        currentPlayers--;
 

      
  

        print(currentPlayers);

    }
    public void StartGame() {
        soundEffector.PlayStartSound();
        PlayerPrefs.SetInt("Players", 2 + currentPlayers);
        StartCoroutine(Starter());
  
    }
    IEnumerator Starter() {
        gamePanel.SetActive(false);
        loadingPanel.SetActive(true);
        yield return new WaitForSeconds(2f);
        loadingPanel.SetActive(false);
        SceneManager.LoadScene(1);
    }
}
