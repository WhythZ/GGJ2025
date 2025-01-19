using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pearl : MonoBehaviour
{
    public PearlGenerator gen;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Crab>() != null)
        {
            CrabManager.instance.score++;
            gen.PickedSignal();
            AudioManager.instance.PlaySFX(10,CrabManager.instance.crab.transform);
            Destroy(this.gameObject);
        }
    }
}
