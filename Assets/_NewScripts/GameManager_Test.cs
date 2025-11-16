using UnityEngine;

public enum GameState_Test {
    Home, Playing, Win, Lose, AutoPlayWin, AutoPlayLose
}

public class GameManager_Test : MonoBehaviour {
    public static GameManager_Test Instance;
    public GameState_Test State { get; private set; }

    public BoardController_Test board;
    public BottomCells_Test bottomCells;

    void Awake() {
        Instance = this;
        State = GameState_Test.Home;
    }

    public void StartGame() {
        State = GameState_Test.Playing;
        board.InitBoard();
        bottomCells.ClearAll();
    }

    public void WinGame() {
        State = GameState_Test.Win;
        UIManager_Test.Instance.ShowWin();
    }

    public void LoseGame() {
        State = GameState_Test.Lose;
        UIManager_Test.Instance.ShowLose();
    }

    public void SetAutoPlayWin() {
        State = GameState_Test.AutoPlayWin;
        AutoPlayer_Test.Instance.StartAutoWin();
    }

    public void SetAutoPlayLose() {
        State = GameState_Test.AutoPlayLose;
        AutoPlayer_Test.Instance.StartAutoLose();
    }
}
