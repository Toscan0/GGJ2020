using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private static float totalLifes = 3;

    public static void LostLife()
    {
        GameObject lifeCanvas = GameObject.Find("Canvas/Life" + totalLifes);
        lifeCanvas.SetActive(false);
        totalLifes--;
        Debug.Log(totalLifes);
        if(totalLifes == 0)
        {
            /*
             *  Call Game Over
             */
        }
    }
}
