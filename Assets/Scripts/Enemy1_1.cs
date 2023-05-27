using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy1_1 : MonoBehaviour
{
    //목적지
    public Transform target;
    //요원
    NavMeshAgent agent;

    public Animator anim;

    //열거형으로 정해진 상태값을 사용
    enum State
    {
        Idle,
        Run
    }
    //상태 처리
    State state;

    // public float speed;

    // private Rigidbody2D EnemyRb;
    private Animator EnemyAnim;

    // //열거형으로 정해진 상태값을 사용
    // public enum CurrentState {Idle, Trace};
    // public CurrentState curState = CurrentState.Idle;
    
    // private Transform enemyTransform;
    // private Transform playerTransform;
    // private NavMeshAgent agent;

    // public float traceDist = 15.0f;
    // // public float attackDist = 3.2f;

    // private bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        //생성시 상태를 Idle로 한다.
        state = State.Idle;

        //요원을 정의해줘서
        agent = GetComponent<NavMeshAgent>();

        // playerTransform = GameObject.Find("Player").transform;
        // agent = this.gameObject.GetComponent<NavMeshAgent>();
        EnemyAnim = this.gameObject.GetComponent<Animator>();

        // StartCoroutine(this.CheckState());
        // StartCoroutine(this.CheckStateForAction());
    }

    // IEnumerator CheckState()
    // {
    //     while(!isDead)
    //     {
    //         yield return new WaitForSeconds(0.2f);

    //         float dist = Vector3.Distance(playerTransform.position, enemyTransform.position);

    //         // if(dist <= attackDist)
    //         // {
    //         //     curState = CurrentState
    //         // }
    //         if(dist <= traceDist)
    //         {
    //             curState = CurrentState.Trace;
    //         }else
    //         {
    //             curState = CurrentState.Idle;
    //         }
    //     }
    // }

    // IEnumerator CheckStateForAction()
    // {
    //     while(!isDead)
    //     {
    //         switch(curState)
    //         {
    //             case CurrentState.Idle:
    //                 agent.Stop();
    //                 EnemyAnim.SetBool("isTrace",false);
    //                 break;
    //             case CurrentState.Trace:
    //                 agent.destination = playerTransform.position;
    //                 agent.Resume();
    //                 EnemyAnim.SetBool("isTrace",true);
    //                 break;
    //         }

    //         yield return null;
    //     }
    // }

    // private void Awake()
    // {
    //     EnemyRb = GetComponent<Rigidbody2D>();
    //     EnemyAnim = GetComponent<Animator>();
    // }

    // Update is called once per frame
    void Update()
    {
        //만약 state가 idle이라면
        if (state == State.Idle)
        {
            UpdateIdle();
        }else if (state == State.Run)
        {
            UpdateRun();
        }
    }

    private void UpdateRun()
    {
        //타겟 방향으로 이동하다가
        agent.speed = 3.5f;
        //요원에게 목적지를 알려준다.
        agent.destination = target.transform.position;
    }

    private void UpdateIdle()
    {
        agent.speed = 0;
        //생성될때 목적지(Player)를 찿는다.
        target = GameObject.Find("Player").transform;
        //target을 찾으면 Run상태로 전이하고 싶다.
        if (target != null)
        {
            state = State.Run;
            //이렇게 state값을 바꿨다고 animation까지 바뀔까? no! 동기화를 해줘야한다.
            EnemyAnim.SetTrigger("Run");
        }
    }

}
