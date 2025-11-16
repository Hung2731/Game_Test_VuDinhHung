using UnityEngine;
using System.Collections.Generic;

public class BottomCells_Test : MonoBehaviour {
    public static BottomCells_Test Instance;

    public Transform[] cells;
    public GameObject itemPrefab;

    private List<int> bottomTypes = new List<int>();

    void Awake() {
        Instance = this;
    }

    public void ClearAll() {
        bottomTypes.Clear();
        foreach (Transform t in cells)
            foreach (Transform c in t)
                Destroy(c.gameObject);
    }

    public bool IsFull() => bottomTypes.Count >= 5;

    public void AddItem(Item_Test item) {
        int type = item.typeID;

        int index = bottomTypes.Count;
        bottomTypes.Add(type);

        var obj = Instantiate(itemPrefab, cells[index]);
        var itemTest = obj.GetComponent<Item_Test>();
        itemTest.typeID = type;
        itemTest.icon.sprite = item.icons[type];

        TryClearTriple();
    }

    void TryClearTriple() {
        Dictionary<int, int> count = new Dictionary<int, int>();
        foreach (var t in bottomTypes) {
            if (!count.ContainsKey(t)) count[t] = 0;
            count[t]++;
        }

        foreach (var kv in count) {
            if (kv.Value == 3) {
                RemoveTriple(kv.Key);
                return;
            }
        }
    }

    void RemoveTriple(int type) {
        // 1. Xóa đúng 3 item có type đó trong danh sách
        int removed = 0;
        List<int> newList = new List<int>();

        foreach (var t in bottomTypes) {
            if (t == type && removed < 3) {
                removed++;
                continue; // không add item này vào danh sách mới
            }
            newList.Add(t);
        }

        bottomTypes = newList;

        // 2. Clear UI từng slot, KHÔNG xóa slot
        for (int i = 0; i < cells.Length; i++) {
            // chỉ xóa con trong slot
            if (cells[i].childCount > 0)
                Destroy(cells[i].GetChild(0).gameObject);
        }

        // 3. Spawn lại các item còn lại theo thứ tự trái -> phải
        for (int i = 0; i < bottomTypes.Count; i++) {
            int t = bottomTypes[i];

            GameObject obj = Instantiate(itemPrefab, cells[i]);
            Item_Test item = obj.GetComponent<Item_Test>();

            item.typeID = t;
            item.icon.sprite = item.icons[t];
        }
    }

}
