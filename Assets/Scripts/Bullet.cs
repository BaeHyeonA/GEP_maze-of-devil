using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //총알 이름을 관리하기 위한 변수
    public string BulletName;

    private Player playerScript;

    private GameManager gameManager;

    void Start()
    {
        GameObject playerObject = GameObject.FindWithTag("Player");
        playerScript = playerObject.GetComponent<Player>();

        GameObject gameManagerObject = GameObject.FindWithTag("GameManager");
        gameManager = gameManagerObject.GetComponent<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //플레이어가 쏘는 총알일 경우 실행
        if(BulletName == "P")
        {
            //아직 코드를 짜지 못함
        }else if(BulletName == "E") //적이 쏘는 총알일 경우 실행
        {
            //Tag가 player일 때 실행
            if(collision.CompareTag("Player")) {

                playerScript.HP -= 10; //플레이어 체력 감소
                if(playerScript.HP <= 0) {
                    gameManager.GameOver(); //플레이어 라이프가 0이 되었을 때 게임오버 만들어줌
                }
                Destroy(gameObject);
            }
        }
    }
}
