using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static float speed;
    public static float AD;
    public float HP;

    Rigidbody2D rigid;
   
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        AD = 10.0f;
    }
}
