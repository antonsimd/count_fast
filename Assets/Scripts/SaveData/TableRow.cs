using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableRow : MonoBehaviour
{
    const string REMOVE_ELEMENT_TEXT = "remove saved game";

    [SerializeField] GameObject confirmPopupPrefab;

    int index;

    public void setIndex(int i) {
        index = i;
    }

    public void removeElement() {
        DataManager.removeAtIndex(index);
        LoadTable.instance.resetScoreboard();
    }

    public void confirmRemoveElement() {
        ConfirmPopup.createPopup(confirmPopupPrefab, REMOVE_ELEMENT_TEXT, removeElement);
    }
}
