using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoPlayer_Test : MonoBehaviour {
    public static AutoPlayer_Test Instance;

    public float delay = 0.5f;

    void Awake() => Instance = this;

    public void StartAutoWin() {
        StartCoroutine(AutoWinRoutine());
    }

    public void StartAutoLose() {
        StartCoroutine(AutoLoseRoutine());
    }

    IEnumerator AutoWinRoutine() {
        var board = GameManager_Test.Instance.board;

        // chạy cho đến khi hết item
        while (board.activeItems.Count > 0) {
            yield return new WaitForSeconds(delay);

            if (board.activeItems.Count == 0)
                break;

            // Chọn phần tử ở đầu list 
            Item_Test first = board.activeItems[0];
            int targetType = first.typeID;

            // Click item đầu tiên
            first.onClick(first);
            yield return new WaitForSeconds(delay);

            // Tìm 2 item còn lại trùng loại
            List<Item_Test> sameType = new List<Item_Test>();

            foreach (Item_Test item in board.activeItems) {
                if (item.typeID == targetType)
                    sameType.Add(item);
            }

            // Nếu tìm đủ 2 item, click nốt để tạo bộ 3
            if (sameType.Count >= 2) {
                sameType[0].onClick(sameType[0]);
                yield return new WaitForSeconds(delay);

                sameType[1].onClick(sameType[1]);
                yield return new WaitForSeconds(delay);
            }
            else {
                // Nếu không tìm đủ bộ 3 → bỏ qua loại này
                // Không click thêm
            }
        }
    }

    IEnumerator AutoLoseRoutine() {
        var board = GameManager_Test.Instance.board;

        while (board.activeItems.Count > 0) {
            yield return new WaitForSeconds(delay);
            var next = board.activeItems[0];
            next.onClick(next);
            if (GameManager_Test.Instance.State == GameState_Test.Lose)
                break;
        }
    }

}
