using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PearlGenerator : MonoBehaviour
{
    private float genTimer = 0;
    [SerializeField] bool hasGenerated = false;
    [SerializeField] private GameObject pearlPrefab;
    [SerializeField] private float genInterval = 6f;

    public void Update()
    {
        genTimer -= Time.deltaTime;

        if (genTimer <= 0 && !hasGenerated)
        {
            genTimer = genInterval;
            hasGenerated = true;
            GeneratePearl();
        }
    }

    public void PickedSignal()
    {
        hasGenerated = false;
    }

    private void GeneratePearl()
    {
        GameObject _newPearl = Instantiate(pearlPrefab);
        _newPearl.GetComponent<Pearl>().gen = this;
        _newPearl.transform.parent = this.transform;
        _newPearl.transform.position = new Vector2(transform.position.x, transform.position.y);
    }
}
