using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PearlGenerator : MonoBehaviour
{
    private float genTimer = 0;
    [SerializeField] bool hasGenerated = false;
    [SerializeField] private GameObject pearlPrefab;
    [SerializeField] private float genInterval = 6f;
    [SerializeField] private GameObject[] genPoints;

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
        _newPearl.transform.parent = this.transform;
        _newPearl.GetComponent<Pearl>().gen = this;

        int _ptIdx = UnityEngine.Random.Range(0, genPoints.Length - 1);
        _newPearl.transform.position = new Vector2(genPoints[_ptIdx].transform.position.x, genPoints[_ptIdx].transform.position.y);
    }
}
