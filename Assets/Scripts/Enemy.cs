using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static float HP;
    public static float speed;
    public static float AD;
    Rigidbody2D rigid;
   
    void Start()
    {

        HP = 100;
        rigid = GetComponent<Rigidbody2D>();
        AD = 10.0f;
    }
}
