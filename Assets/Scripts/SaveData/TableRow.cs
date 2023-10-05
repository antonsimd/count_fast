using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableRow : MonoBehaviour
{
    int index;

    public void setIndex(int i) {
        index = i;
    }

    public void removeElement() {
        DataManager.removeAtIndex(index);
        LoadTable.instance.resetScoreboard();
    }
}
