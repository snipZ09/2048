using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public static UIController instance;
    public Text scoreValueText;

    private void Update()
    {
        scoreValueText.text = GameController.instance.score.ToString();
    }
 
}
