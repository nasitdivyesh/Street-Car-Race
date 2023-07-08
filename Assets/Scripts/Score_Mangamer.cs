using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score_Mangamer : MonoBehaviour
{
    public int score = 0;
    public int highScore;
    public static int lastScore = 0;
    public  Text scoreText;
    public  Text highScoreText;
    public  Text lastScoreText;
     
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Score());
        StartCoroutine(Reload());

        highScore = PlayerPrefs.GetInt("high_score") ;
        
        highScoreText.text = "HighScore: " + highScore.ToString();
        lastScoreText.text = "LastScore: " + lastScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
       scoreText.text = score.ToString();

       if(score>highScore)
       {
            highScore = score;
            PlayerPrefs.SetInt("high_score", highScore);
            Debug.Log("High Score: "+ highScore);
            Debug.Log("last Score: "+ lastScore);
       }

       if (Input.GetMouseButton(0))
       {
          Vector2 newPos =    Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            transform.position = newPos;
       }
    }
    IEnumerator Score()
    {
        while(true)
        {
             yield return new  WaitForSeconds(0.8f);
             score = score + 1;
             lastScore = score;
        }
    }
     IEnumerator Reload()
    {
        yield return new WaitForSeconds(Random.Range(5,10));
        SceneManager.LoadScene("Game");
    }
}
