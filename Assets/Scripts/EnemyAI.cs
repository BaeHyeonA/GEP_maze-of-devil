using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform target;
   
    public float speed;
    public float limitDis;

    private Animator anim;

    private Enemy enemyScript;
    private Player playerScript;
    private GameManager gameManager;

    void Start()
    {
        anim = this.gameObject.GetComponent<Animator>();
        enemyScript = this.gameObject.GetComponent<Enemy>();

        GameObject playerObject = GameObject.FindWithTag("Player");
        playerScript = playerObject.GetComponent<Player>();

        GameObject gameManagerObject = GameObject.FindWithTag("GameManager");
        gameManager = gameManagerObject.GetComponent<GameManager>();
    }

    void Update()
    {
        float dis = Vector3.Distance(transform.position, target.position);
        if (dis <= limitDis)
        {
            Move();
        }
        else
        {
            anim.SetBool("isTraceLeft",false);
            anim.SetBool("isTraceRight",false);
            return;
        }
    }

    void Move()
    {
        float dirX = target.position.x - transform.position.x;
        float dirY = target.position.y - transform.position.y;
        if(dirX <= 0)
        {
            anim.SetBool("isTraceRight",false);
            anim.SetBool("isTraceLeft",true);
        }else if(dirX > 0)
        {
            anim.SetBool("isTraceLeft",false);
            anim.SetBool("isTraceRight",true);
        }

        // dirX = (dirX < 0) ? -1 : 1;
        // dirY = (dirY < 0) ? -1 : 1;

        transform.Translate(new Vector2(dirX, dirY) * speed * Time.deltaTime);
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log(playerScript.HP);
            playerScript.HP -= 1;
            if(playerScript.HP <= 0) {
                gameManager.GameOver(); //플레이어 라이프가 0이 되었을 때 게임오버 만들어줌
            }
        }
    }
}