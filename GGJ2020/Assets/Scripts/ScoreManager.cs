using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private static float totalLifes = 3;

    public static void LostLife()
    {
        GameObject lifeCanvas = GameObject.Find("Canvas/Life" + totalLifes);
        if(lifeCanvas != null)
        {
            lifeCanvas.SetActive(false);
        }

        totalLifes--;

        if (totalLifes == 0)
        {
            Transform[] trans = GameObject.Find("UI").GetComponentsInChildren<Transform>(true);
            foreach (Transform t in trans)
            {
                if (t.gameObject.name == "GameOver")
                {
                    t.gameObject.SetActive(true);
                }
            }
        }
    }
}
