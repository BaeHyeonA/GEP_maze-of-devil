using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text isGameOverText;

    void Start()
    {
        isGameOverText.text = "";
    }

    //게임 오버시 실행할 함수
    public void GameOver() {
        isGameOverText.text = "Game Over";
        Time.timeScale = 0;
    }
}
