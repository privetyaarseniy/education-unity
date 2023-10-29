using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UI
{
    private static int score = 0;
    private static int lives = 3;
    // Start is called before the first frame update

    public static void ScoreUp()
    {
        Debug.Log($"Your score: {++score}");
    }

    public static void LivesDown()
    {
        if(--lives <= 0)
        {
            Debug.Log("GAME OVER!");
            Application.Quit();
        }

        Debug.Log($"Your lives: {lives}");
    }
}
