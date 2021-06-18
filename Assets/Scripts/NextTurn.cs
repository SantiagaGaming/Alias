using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextTurn : MonoBehaviour

{
    [SerializeField] GameObject endGamePanel;
    [SerializeField] GameObject readyPanel;
    [SerializeField] GameObject gamePanel;
    [SerializeField] GameObject lastwordPanel;
    [SerializeField] Text winnerText;
    [SerializeField] Text timertext;
    [SerializeField] Text pointsText;
    [SerializeField] Text currentPlayerText;
    [SerializeField] GameObject[] players;
    [SerializeField] Text[] scoreAll;
    [SerializeField] GameObject[] playersPlay;
    [SerializeField] Text randomText;
    [SerializeField] GameObject panel;
    [SerializeField] SoundEffector soundEffector;
    [SerializeField] GameObject listOfWordsPanel;
    [SerializeField] Text listOfWordsText;
    [SerializeField] GameObject[] lastWordPlayers;
    [SerializeField] Text lastWordText;
    private float _timeStart = 60f;
    private bool isReady = false;
    private int activePlayers;
    private int currentPlayer = 0;
    List<string> wordsList;
    public static bool isLastWorded = false;
    int rnd;
    private void Awake()
    {
        activePlayers = PlayerPrefs.GetInt("Players");
        print(activePlayers);
        players[currentPlayer].SetActive(true);

        int rnd = Random.Range(0, Words.word.Length);
        randomText.text = Words.word[rnd].ToString();
        currentPlayerText.text = 1.ToString();
        wordsList = new List<string>(); 
    }

    void Update()
    {if (isLastWorded) {
            CloseLastWord();
        }
        if (isReady)
        {
            pointsText.text = players[currentPlayer].GetComponent<Player>().score.ToString();
            timertext.text = Mathf.Round(_timeStart).ToString();
            TimeUpdate();
        }
    }
    public void nextPlayerTurn()
    {
        Randomizer();
        panel.SetActive(true);
        listOfWordsPanel.SetActive(false);
        players[currentPlayer].SetActive(false);
        currentPlayer++;
        if (currentPlayer <= activePlayers)
        {
            
        }
        if (currentPlayer > activePlayers)
        {
            currentPlayer = 0;
        }
        players[currentPlayer].SetActive(true);
        isReady = false;
        ClearAllListOfWords(wordsList);
        _timeStart = 60f;
        pointsText.text = players[currentPlayer].GetComponent<Player>().score.ToString();
        print(currentPlayer);
        currentPlayerText.text = (currentPlayer + 1).ToString();
    }
    public void ListOfWordsPanel() {
        listOfWordsText.text = VievListOfWords(wordsList);
        listOfWordsPanel.SetActive(true);
    }
    private void LastWord() {
        isReady = false;
        lastwordPanel.SetActive(true);
        for (int x = 0; x <= activePlayers; x++) {
            lastWordPlayers[x].SetActive(true);
        }
        lastWordText.text = randomText.text;
    }
    public void NextPlayerReady() {
       
        panel.SetActive(false);
        readyPanel.SetActive(true);

    }
    public void Right()
    {
        if (isReady)
        {
            soundEffector.PlayRightAnswerSound();
            players[currentPlayer].GetComponent<Player>().score++;
            Randomizer();
            AddToListOfWordsRight(Words.word[rnd].ToString());
        }
    }
    public void Wrong()
    {
        if (isReady)
        {
            soundEffector.PlayWrondAnswerSound();
            players[currentPlayer].GetComponent<Player>().score--;
            Randomizer();
            AddToListOfWordsWrong(Words.word[rnd].ToString());
        }
    }
    public void Ready()
    {
        soundEffector.PlayNextLevelSound();
        isReady = true;
        readyPanel.SetActive(false);
        gamePanel.SetActive(true);


    }
    private void TimeUpdate()
    {
        if (_timeStart > 0)
        {
            _timeStart -= Time.deltaTime;
        }
        else if (_timeStart <= 0)
        {
            gamePanel.SetActive(false);
          
            LastWord();
            EndGame();

        }
    }
    private void PlayerScorePanel()
    {
        for (int x = 0; x <= activePlayers; x++)
        {
            playersPlay[x].SetActive(true);
        }
        for (int y = 0; y <= activePlayers; y++)
        {
            scoreAll[y].text = players[y].GetComponent<Player>().score.ToString();
        }
    }
    public void Exit()
    {
        SceneManager.LoadScene(0);
    }
    private void EndGame()
    {
        int EndInt = int.Parse(pointsText.text);
        if (EndInt >= 50) {
            winnerText.text = (currentPlayer+1).ToString();
            endGamePanel.SetActive(true);
            gamePanel.SetActive(false);
            panel.SetActive(false);
            listOfWordsPanel.SetActive(false);
            lastwordPanel.SetActive(false);
        }
    }
    public void Again() {
        SceneManager.LoadScene(1);
    }
    private void AddToListOfWordsRight(string name) {
        
        wordsList.Add(name + " дю");

    }
    private void AddToListOfWordsWrong(string name)
    {
       
        wordsList.Add(name + " мер");

    }
    private void ClearAllListOfWords(List<string> words) {
        words.Clear();
    }
    private string VievListOfWords(List<string> words) {
        string finalWord = "";
        for (int x = 0; x <= words.Count-1; x++) {
            finalWord += $"{words[x]} \n";
        }
        return finalWord;
    }
    public void CloseLastWord()
    {
        ListOfWordsPanel();
        PlayerScorePanel();
        lastwordPanel.SetActive(false);
        isLastWorded = false;


    }
    private void Randomizer() {
        rnd = Random.Range(0, Words.word.Length);
        randomText.text = Words.word[rnd].ToString();
    }

}
