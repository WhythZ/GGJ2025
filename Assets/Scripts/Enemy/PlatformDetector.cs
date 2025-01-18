using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDetector : MonoBehaviour
{
    public bool signal = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
            signal = true;
        else
            signal = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        signal = false;
    }
}
