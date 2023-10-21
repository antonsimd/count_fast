using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataVariables
{
    public const string sortTypeKey = "sortType";

    public enum SortTypes {
        ScoreUp,
        ScoreDown,
        DateUp,
        DateDown,
        TimeUp,
        TimeDown,
        NameUp,
        NameDown
    };
}
