using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    [SerializeField] bool isForPlayer = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Crab>() != null && isForPlayer)
            StartCoroutine(CrabManager.instance.TouchDeadZone());

        if (collision.GetComponent<Bubble>() != null)
            collision.GetComponent<Bubble>().Explode();

        if (collision.GetComponent<Enemy>() != null)
            Destroy(collision.GetComponent<Enemy>().gameObject);
    }
}