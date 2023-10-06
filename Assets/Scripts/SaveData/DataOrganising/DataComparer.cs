using System.Collections;
using System;

public class SortScoreAscending : IComparer
{
    int IComparer.Compare(object a, object b) {
        SaveGameInstance s1 = (SaveGameInstance)a;
        SaveGameInstance s2 = (SaveGameInstance)b;
        
        if (s1.score < s2.score) {
            return 1;
        } else if (s1.score > s2.score) {
            return -1;
        } else {
            return 0;
        }
    }
}

public class SortScoreDescending : IComparer
{
    int IComparer.Compare(object a, object b) {
        SaveGameInstance s1 = (SaveGameInstance)a;
        SaveGameInstance s2 = (SaveGameInstance)b;
        
        if (s1.score > s2.score) {
            return 1;
        } else if (s1.score < s2.score) {
            return -1;
        } else {
            return 0;
        }
    }
}
