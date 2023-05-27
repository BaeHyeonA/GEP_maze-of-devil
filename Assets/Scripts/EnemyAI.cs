using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform target;
   
    public float HP;
    public float speed;
    public float limitDis;

    public Animator anim;

    void Start()
    {
        anim = this.gameObject.GetComponent<Animator>();
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
}