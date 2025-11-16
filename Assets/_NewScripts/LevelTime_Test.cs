using UnityEngine;
using UnityEngine.UI;

public class LevelTime_Test : MonoBehaviour {
    public float timeLimit = 60;
    public Text timeText;

    void Update() {
        if (GameManager_Test.Instance.State != GameState_Test.Playing)
            return;

        timeLimit -= Time.deltaTime;
        timeText.text = Mathf.Ceil(timeLimit).ToString();

        if (timeLimit <= 0)
            GameManager_Test.Instance.LoseGame();
    }
}
