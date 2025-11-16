using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Item_Test : MonoBehaviour, IPointerClickHandler {
    public int typeID;
    public Action<Item_Test> onClick;

    public Image icon;
    public Sprite[] icons;

    public void SetRandomType() {
        typeID = UnityEngine.Random.Range(0, icons.Length);
        icon.sprite = icons[typeID];
    }

    public void OnPointerClick(PointerEventData eventData) {
        onClick?.Invoke(this);
    }
}
