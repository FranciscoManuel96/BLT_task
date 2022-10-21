using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI winText;
    [SerializeField] private ObjCollieded objCollieded;
    [SerializeField] private RandomObjSpawner randomObjSpawner;
    [SerializeField] private Timer timer;
    [SerializeField] private DataManager dataManager;

    private int score;
    bool isCurrentlyColliding, gameIsDone = false;
    string objColl;
    int sphereValue = 1, capsuleValue = 2, switcher = 1, level = 1;

    void Start()
    {
        //Reset score and level
        ResetScore();
        level = 1;
        winText.enabled = false;
    }

    void Update()
    {
        if (score >= 400)
        {
            YouWin();
        }
        else if (score >= 100 && level != 3)
        {
            level += 1;
            ResetScore();
        }

        if (level == 1)
        {
            sphereValue = 1;
            capsuleValue = 2;
        }
        else if (level == 2)
        {
            sphereValue = 10;
            capsuleValue = 12;
        }
        else if (level == 3)
        {
            sphereValue = 20;
            capsuleValue = 22;
        }

        if (isCurrentlyColliding)
        {
            switch (objColl)
            {
                case "Sphere(Clone)":
                    score += (switcher * sphereValue);
                    break;
                case "Capsule(Clone)":
                    score += (switcher * capsuleValue);
                    break;
                case "Cube(Clone)":
                    GameOver();
                    break;
                default:
                    break;
            }
            isCurrentlyColliding = false;
            objCollieded.IncreaseObjColl();
        }
        scoreText.text = score.ToString();
        levelText.text = level.ToString();

        if (gameIsDone)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Time.timeScale = 1;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                objCollieded.ResetNmbObj();
                gameIsDone = false;
                winText.enabled = false;
            }
        }
    }

    //Collisions
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy" && collision.gameObject.name != objColl)
        {
            objColl = collision.gameObject.name;
            isCurrentlyColliding = true;
            randomObjSpawner.DecreaseObjCounter();
            Destroy(collision.gameObject);
            switcher = 1;
        }
        else if (collision.gameObject.tag == "Enemy" && collision.gameObject.name == objColl)
        {
            objColl = collision.gameObject.name;
            isCurrentlyColliding = true;
            randomObjSpawner.DecreaseObjCounter();
            Destroy(collision.gameObject);
            switcher = -1;
        }
    }

    //resets score
    void ResetScore()
    {
        score = 0;
    }

    //Restart the game
    void GameOver()
    {
        Time.timeScale = 0;

        SaveFile();
        gameIsDone = true;
    }

    //Win game
    void YouWin()
    {
        Time.timeScale = 0;
        winText.enabled = true;
        SaveFile();
        gameIsDone = true;
    }

    void SaveFile()
    {
        dataManager.data.yourscore = score;
        dataManager.data.yourNumberOfObjectsCollided = objCollieded.numberObjColl;
        dataManager.data.yourtime = timer.timeText.text;
        dataManager.Save();
    }
}
