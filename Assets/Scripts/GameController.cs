using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public float value;
    float speedLerp = 0.2f;
    public float fillNumber;
    public int score = 0;
    

    private void Awake()
    {
        instance = this;    
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        //for(int i = 0; i < fillNumber; i++)
        //{
        //    if(fillNumber < 0.2f)
        //    {
        //        Debug.Log("1");
        //        speedLerp = 0.2f;
        //    }
        //    if(fillNumber >= 0.2f && fillNumber <= 0.8f)
        //    {
        //        Debug.Log("2");
        //        speedLerp = 0.2f;
        //    }
        //    if(fillNumber > 0.8f)
        //    {
        //        Debug.Log("3");
        //        speedLerp = 0.2f;
        //    }
        //}
        //value += Time.deltaTime ;
        //Debug.Log("speed Lerp: " + speedLerp);
        //fillNumber = Mathf.Lerp(0, 1, value);
    }

    public void NewGame()
    {
        SceneManager.LoadScene("SampleScene");

    }
}
