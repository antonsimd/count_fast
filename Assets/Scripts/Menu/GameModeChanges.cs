using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModeChanges : MonoBehaviour
{
    public static void practiceMode() {
        MainGame.changeGameMode(MainGame.GameModes.PRACTICE);
    }

    public static void gameMode() {
        MainGame.changeGameMode(MainGame.GameModes.GAME);
    }
}
