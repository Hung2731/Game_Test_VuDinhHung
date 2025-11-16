using UnityEngine;

public class UIManager_Test : MonoBehaviour {
    public static UIManager_Test Instance;

    [Header("Main UI Panels")]
    public GameObject panelHome;
    public GameObject panelGame;
    public GameObject panelPause;
    public GameObject panelGameOver;
    public GameObject panelWin;
    public GameObject boardLayer;
    public GameObject bottomLayer;

    void Awake() => Instance = this;

    void Start() {
        ShowHome();
    }

    public void ShowHome() {
        panelHome.SetActive(true);
        panelGame.SetActive(false);
        panelPause.SetActive(false);
        panelGameOver.SetActive(false);
        panelWin.SetActive(false);
        boardLayer.SetActive(false);
        bottomLayer.SetActive(false);
    }

    public void ShowGame() {
        panelHome.SetActive(false);
        panelGame.SetActive(true);
        panelPause.SetActive(false);
        panelGameOver.SetActive(false);
        panelWin.SetActive(false);
        boardLayer.SetActive(true);
        bottomLayer.SetActive(true);
    }

    public void ShowPause() {
        panelPause.SetActive(true);
        boardLayer.SetActive(false);
        bottomLayer.SetActive(false);
    }

    public void HidePause() {
        panelPause.SetActive(false);
        boardLayer.SetActive(true);
        bottomLayer.SetActive(true);
    }

    public void ShowWin() {
        panelGame.SetActive(false);
        panelWin.SetActive(true);
        boardLayer.SetActive(false);
        bottomLayer.SetActive(false);
    }

    public void ShowLose() {
        panelGame.SetActive(false);
        panelGameOver.SetActive(true);
        boardLayer.SetActive(false);
        bottomLayer.SetActive(false);
    }

    // Buttons
    public void OnPlayButton() {
        ShowGame();
        GameManager_Test.Instance.StartGame();
    }

    public void OnPauseButton() {
        ShowPause();
        Time.timeScale = 0;
        
    }

    public void OnResumeButton() {
        HidePause();
        Time.timeScale = 1;
    }

    public void OnRestartButton() {
        Time.timeScale = 1;
        ShowGame();
        GameManager_Test.Instance.StartGame();
    }

    public void OnAutoPlayWinButton() {
        ShowGame();
        GameManager_Test.Instance.SetAutoPlayWin();
    }

    public void OnAutoPlayLoseButton() {
        ShowGame();
        GameManager_Test.Instance.SetAutoPlayLose();
    }

}
