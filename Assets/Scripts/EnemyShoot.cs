using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject bulletObj;
    public GameObject player;

    public float maxShotDelay;
    public float curShotDelay;

    void Update()
    {
        Fire();
        Reload();
    }

    void Fire()
    {
        if(curShotDelay < maxShotDelay)
        {
            return;
        }

        if(gameObject != null && player != null)
        {
            GameObject bullet = Instantiate(bulletObj, transform.position, transform.rotation); //적 위치에 총알 생성
            Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
            Vector2 dirVec = player.transform.position - transform.position; //플레이어 위치 - Enemy 위치를 빼면 목표물로의 방향 값이 나옴
            Vector2 ranVec = new Vector2(Random.Range(-0.5f, 0.5f), Random.Range(0f, 2f));  //랜덤위치 주기
            dirVec += ranVec; //랜덤위치를 플레이어 계산한 위치와 더해줘서 저장
            rigid.AddForce(dirVec.normalized * 4, ForceMode2D.Impulse); //단위벡터로 만들어줌(normalized : 벡터가 단위 값(1)로 변환된 변수)
                                                                        //플레이어가 있던 위치로 총알 발사
            
        }

        curShotDelay = 0; //총알은 쏜 다음에는 딜레이 변수 0으로 초기화
    }

    void Reload()
    {
        curShotDelay += Time.deltaTime;
    }
}
