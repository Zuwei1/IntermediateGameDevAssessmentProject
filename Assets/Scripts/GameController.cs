using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text healthText;
    public Text exittoMenu;
    public Text restartText;
    public Text gameOverText;
    private bool gameOver;
    private bool restart;
    public Text scoreText;
    public int score;
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    private GameObject player;
    public int nextWavescore =80;
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
   
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        exittoMenu.text = "";
        healthText.text = "";
        score = 0;
        UpdateScore();
        UpdateHealth();
        StartCoroutine(SpawnWaves());
    }
    void Update()
     {
        if(restart) 
        {
            if(Input.GetKeyDown(KeyCode.R)) 
            {
                 UnityEngine.SceneManagement.SceneManager.LoadScene(1);
            }
            if(Input.GetKeyDown(KeyCode.Q))
             {
                 UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            }
      
                    
        }
        // every 100 points, increase difficulty
            if(score>= nextWavescore) 
            {
                hazardCount+=1;
				waveWait -= 0.2f;
				startWait -= 0.2f;
				spawnWait -= 0.05f;
                nextWavescore += 90;
            }     
        if( player.GetComponent<PlayerController>().health <= 0) {
                 player.GetComponent<PlayerController>().health = 0;
                GameOver();
        }
            UpdateHealth();



        
    }
    IEnumerator SpawnWaves() {
        yield return new WaitForSeconds(startWait);
        while(true) {
        for(int i = 0; i < hazardCount; i++) {
        GameObject hazard = hazards[Random.Range(0,hazards.Length)];
        Vector3 spawnPosition = new Vector3 (Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
        Quaternion spawnRotation = Quaternion.identity;
        Instantiate (hazard, spawnPosition, spawnRotation); 
        yield return new WaitForSeconds(spawnWait);
            }
        yield return new WaitForSeconds(waveWait);
        if(gameOver) {
            restartText.text = "Press 'R' to restart,";
            exittoMenu.text = "Or press Q to go back to menu.";
            restart = true;
            break;
        }
        }
    }

    public void AddScore(int newScoreValue) {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore() {
        scoreText.text = "Score: " + score;
    }

    public void GameOver() {
        gameOverText.text = "Game Over!";
        gameOver = true;
    }

    void UpdateHealth() {
        healthText.text = "Health: " +  player.GetComponent<PlayerController>().health;
    }
    
    
}
