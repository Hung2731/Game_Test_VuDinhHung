using UnityEngine;

public class LevelCondition_Test : MonoBehaviour {
    public bool CheckWin() {
        return GameManager_Test.Instance.board.activeItems.Count == 0;
    }

    public bool CheckLose() {
        return BottomCells_Test.Instance.IsFull();
    }
}
