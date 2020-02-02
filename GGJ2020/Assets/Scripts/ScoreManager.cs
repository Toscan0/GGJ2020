using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private static float totalLifes = 3;
    public static double score = 0;

    public Text scoreText;

    void Start()
    {
        totalLifes = 3;
        score = 0;
    }

    private void Update()
    {
        scoreText.text = "" + score;
    }

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
                    var a = t.Find("ScoreDisplay").GetComponent<Text>();
                    a.text = "" + score;
                    t.gameObject.SetActive(true);


                    //delete players
                    GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
                    for(int i = 0; i < players.Length; i++)
                    {
                        Destroy(players[i]);
                    }
                }
            }
        }
    }
}
