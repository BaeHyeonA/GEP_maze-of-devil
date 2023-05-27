//using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatwithNPC : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Villager"))
        {
            Transform collTf = collision.gameObject.transform;
            if (collTf.childCount > 0)
            {
                collTf.GetChild(0).gameObject.SetActive(true);
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Villager"))
        {
            Transform collTf = collision.gameObject.transform;
            if (collTf.childCount > 0)
            {
                if (collTf.GetChild(0).gameObject.activeSelf) collTf.GetChild(0).gameObject.SetActive(false);
            }
        }
    }
}
