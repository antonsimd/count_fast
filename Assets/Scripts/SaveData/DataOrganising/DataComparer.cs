using System.Collections;
using System;

// Sorting by score
#region 
public class SortScoreDescending : IComparer
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

public class SortScoreAscending : IComparer
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
#endregion 

// Sorting by Time
#region 
public class SortTimeDescending : IComparer
{
    int IComparer.Compare(object a, object b) {
        SaveGameInstance s1 = (SaveGameInstance)a;
        SaveGameInstance s2 = (SaveGameInstance)b;
        
        if (s1.timePerQuestion < s2.timePerQuestion) {
            return 1;
        } else if (s1.timePerQuestion > s2.timePerQuestion) {
            return -1;
        } else {
            return 0;
        }
    }
}

public class SortTimeAscending : IComparer
{
    int IComparer.Compare(object a, object b) {
        SaveGameInstance s1 = (SaveGameInstance)a;
        SaveGameInstance s2 = (SaveGameInstance)b;
        
        if (s1.timePerQuestion > s2.timePerQuestion) {
            return 1;
        } else if (s1.timePerQuestion < s2.timePerQuestion) {
            return -1;
        } else {
            return 0;
        }
    }
}
#endregion

// Sorting by Date
#region 
public class SortDateDescending : IComparer
{
    int IComparer.Compare(object a, object b) {
        SaveGameInstance s1 = (SaveGameInstance)a;
        SaveGameInstance s2 = (SaveGameInstance)b;
        
        var d1 = DateTime.ParseExact(s1.date, "dd/MM\nyyyy", null);
        var d2 = DateTime.ParseExact(s2.date, "dd/MM\nyyyy", null);

        return DateTime.Compare(d2, d1);
    }
}

public class SortDateAscending : IComparer
{
    int IComparer.Compare(object a, object b) {
        SaveGameInstance s1 = (SaveGameInstance)a;
        SaveGameInstance s2 = (SaveGameInstance)b;
        
        var d1 = DateTime.ParseExact(s1.date, "dd/MM\nyyyy", null);
        var d2 = DateTime.ParseExact(s2.date, "dd/MM\nyyyy", null);

        return DateTime.Compare(d1, d2);
    }
}
#endregion

// Sorting by gameMode
#region 
public class SortNameDescending : IComparer
{
    enum GameTypes {
        Addition,
        Subtraction,
        Multiplication,
        Division,
        Mixed
    };

    int IComparer.Compare(object a, object b) {
        SaveGameInstance s1 = (SaveGameInstance)a;
        SaveGameInstance s2 = (SaveGameInstance)b;
        
        var g1 = Enum.Parse<GameTypes>(s1.gameMode);
        var g2 = Enum.Parse<GameTypes>(s2.gameMode);

        if (g1 < g2) {
            return 1;
        } else if (g1 > g2) {
            return -1;
        } else {
            return 0;
        }
    }
}

public class SortNameAscending : IComparer
{
    enum GameTypes {
        Addition,
        Subtraction,
        Multiplication,
        Division,
        Mixed
    };

    int IComparer.Compare(object a, object b) {
        SaveGameInstance s1 = (SaveGameInstance)a;
        SaveGameInstance s2 = (SaveGameInstance)b;
        
        var g1 = Enum.Parse<GameTypes>(s1.gameMode);
        var g2 = Enum.Parse<GameTypes>(s2.gameMode);

        if (g1 > g2) {
            return 1;
        } else if (g1 < g2) {
            return -1;
        } else {
            return 0;
        }
    }
}

#endregion
