using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraMovement : MonoBehaviour {

    public Transform playerT;
    public Transform cameraT;

    public Text scoreText;
    public Text highScore;
    public float score;
    public int pontuacao;
  

	// Use this for initialization
	void Start () {

        highScore.text = PlayerPrefs.GetInt("Highscore", 0).ToString();
		
	}
	
	// Update is called once per frame
	void Update () {

      
        cameraT.position = new Vector3(0, playerT.position.y + 3.8f, -10);
        score = playerT.position.y;
        pontuacao = Mathf.RoundToInt(score);

        scoreText.text = pontuacao.ToString();

        

        if(score > PlayerPrefs.GetInt("Highscore", 0))
        {
            PlayerPrefs.SetInt("Highscore", pontuacao);
            highScore.text = pontuacao.ToString();
        }

    }

}
