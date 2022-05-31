using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGameScene : MonoBehaviour
{
    public static EndGameScene instance;
    public float waitForAnyKey = 2f;
    public GameObject anyKeyText;
    public Text ping;
    public string loadScene;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        ping.text = ping.text;
    }

    // Update is called once per frame
    void Update()
    {
        if (waitForAnyKey > 0)
        {
            waitForAnyKey -= Time.deltaTime;
            if (waitForAnyKey <= 0)
            {
                anyKeyText.SetActive(true);
            }
        }
        else
        {
            if (Input.anyKeyDown)
            {
                SceneManager.LoadScene(loadScene);
            }
        }
    }
}
