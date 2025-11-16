using UnityEngine;
using System.Collections.Generic;

public class BoardController_Test : MonoBehaviour {
    public Transform boardRoot;
    public GameObject itemPrefab;

    public List<Item_Test> activeItems = new List<Item_Test>();

    public int rows = 4;
    public int cols = 5;

    public void InitBoard() {
        ClearBoard();
        activeItems.Clear();

        int totalCells = rows * cols;
        int typeCount = itemPrefab.GetComponent<Item_Test>().icons.Length;

        // Danh sách typeID đã chuẩn bị
        List<int> typeList = new List<int>();

        // tạo các nhóm 3
        while (typeList.Count + 3 <= totalCells) {
            int randomType = UnityEngine.Random.Range(0, typeCount);
            typeList.Add(randomType);
            typeList.Add(randomType);
            typeList.Add(randomType);
        }

        // nếu chưa đủ số lượng, bổ sung vào nhóm bất kỳ
        while (typeList.Count < totalCells) {
            int randomType = UnityEngine.Random.Range(0, typeCount);
            typeList.Add(randomType);
        }

        // random shuffle list
        for (int i = 0; i < typeList.Count; i++) {
            int rand = UnityEngine.Random.Range(i, typeList.Count);
            int tmp = typeList[i];
            typeList[i] = typeList[rand];
            typeList[rand] = tmp;
        }

        // spawn các item theo typeList
        int index = 0;

        for (int r = 0; r < rows; r++) {
            for (int c = 0; c < cols; c++) {
                GameObject obj = Instantiate(itemPrefab, boardRoot);
                Item_Test item = obj.GetComponent<Item_Test>();

                item.typeID = typeList[index];
                item.icon.sprite = item.icons[item.typeID];

                item.onClick = OnItemClicked;

                activeItems.Add(item);
                index++;
            }
        }
    }


    public void ClearBoard() {
        foreach (Transform child in boardRoot)
            Destroy(child.gameObject);
    }

    void OnItemClicked(Item_Test item) {
        if (GameManager_Test.Instance.State != GameState_Test.Playing &&
            GameManager_Test.Instance.State != GameState_Test.AutoPlayWin &&
            GameManager_Test.Instance.State != GameState_Test.AutoPlayLose)
            return;

        if (BottomCells_Test.Instance.IsFull()) {
            GameManager_Test.Instance.LoseGame();
            return;
        }

        BottomCells_Test.Instance.AddItem(item);

        activeItems.Remove(item);
        Destroy(item.gameObject);

        if (activeItems.Count == 0) {
            GameManager_Test.Instance.WinGame();
        }
    }
}
