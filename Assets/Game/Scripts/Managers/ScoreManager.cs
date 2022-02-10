using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public GameObject diamondEarnedText;
    public static int theDiamond;


    void Update()
    {
        diamondEarnedText.GetComponent<Text>().text = "Score" + theDiamond;
    }
}
