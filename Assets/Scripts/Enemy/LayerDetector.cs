using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerDetector : MonoBehaviour
{
    [SerializeField] private int layerNumber;
    public bool signal = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == layerNumber)
            signal = true;
        else
            signal = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        signal = false;
    }
}
