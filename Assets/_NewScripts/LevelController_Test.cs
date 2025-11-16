using UnityEngine;

public class LevelController_Test : MonoBehaviour {
    public static LevelController_Test Instance;

    void Awake() => Instance = this;

    public void SetupLevel(BoardController_Test board) {
        // Example: ensure divisible by 3
    }
}
