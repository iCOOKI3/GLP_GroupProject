using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public static GameManager Instance;

    [Header("Game variables")]
    [Tooltip("Time in seconds")]
    public float RoundTime;

    [Header("Game audioClips")]
    public AudioClip BackgroundMusic;
    public AudioClip GameWinSound;
    public AudioClip GameLoseSound;

    [Header("Text boxes references")]
    public Text ScoreTextbox;
    public string ScoreTextPrefix;

    public Text AmmoTextbox;
    public string AmmoTextPrefix;

    public Text HealthTextbox;
    public string HealthTextPrefix;

    public Text TimeLeftTextbox;
    public string TimeLeftTextPrefix;

    public Text KeysCollectedTextbox;
    public string KeysCollectedTextPrefix;

    public GameObject GameOverUI;

    public GameObject GameWinUI;


    public string SceneName;
    [HideInInspector]
    public bool isGameOver;
    
    private int score;
    private int KeysCollected;
    private AudioSource audioSource;

    // Use this for initialization
    void Awake ()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        audioSource = GetComponent<AudioSource>();
        audioSource.clip = BackgroundMusic;
        audioSource.Play();

        GameOverUI.SetActive(false);
        GameWinUI.SetActive(false);
    }

    // Update is called once per frame
    void Update ()
    {
        KeysCollectedTextbox.GetComponent<Text>().text = "Keys Collected:" + PlayerScript.KeyCount + "/2";

        if (isGameOver)
            return;

        UpdateTimeLeft();

        if (Input.GetKeyDown(KeyCode.F1)) {
            SetGameOver(true);
        }
    }

    public void UpdateScore(int _score, AudioClip audioClip) {
        score += _score;
        ScoreTextbox.text = ScoreTextPrefix + score;

        audioSource.PlayOneShot(audioClip);
    }

    public void UpdateAmmo(int ammo)
    {
        AmmoTextbox.text = AmmoTextPrefix + ammo;
    }

    public void UpdateHealth(int health)
    {
        if (health <= 0 && !isGameOver)
        {
            health = 0;
            SetGameOver(false);
        }

        HealthTextbox.text = HealthTextPrefix + health;
    }

    public void UpdateKeysCollect(int _KeysCollected)
    {
        KeysCollected += _KeysCollected;
        KeysCollectedTextbox.text = KeysCollectedTextPrefix + KeysCollected;
    }

    public void UpdateTimeLeft()
    {
        if (RoundTime <= 0)
        {
            RoundTime = 0;
            TimeLeftTextbox.text = TimeLeftTextPrefix + "\n00:00:00";

            SetGameOver(false);

            return;
        }

        RoundTime -= Time.deltaTime;

        int minutes = (int)RoundTime / 60;
        int seconds = (int)RoundTime - 60 * minutes;
        int milliseconds = (int)(100 * (RoundTime - minutes * 60 - seconds));
        
        TimeLeftTextbox.text = TimeLeftTextPrefix + '\n' + string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
    }

    public void SetGameOver(bool isWin) {

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        GameObject.Find("FPSPlayer").GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = false;
        isGameOver = true;
        //GameOverUI.SetActive(true);
        
        if (isWin)
        {
            GameWinUI.SetActive(true);
            GameOverUI.SetActive(false);
            audioSource.PlayOneShot(GameWinSound);
        }
        else
        {
            GameOverUI.SetActive(true);
            GameWinUI.SetActive(false);
            audioSource.PlayOneShot(GameLoseSound);
        }
    }

    public void ResetGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public int GetScore()
    {
        return score;
    }

    public int GetKeys()
    {
        return KeysCollected;
    }


    public void Quit()
    {
        Application.Quit();
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene("L2");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("L1");
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene("L2");
    }
}
