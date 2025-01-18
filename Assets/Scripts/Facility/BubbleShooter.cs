using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleShooter : MonoBehaviour
{
    private float shootTimer;
    [SerializeField] private GameObject bubblePrefab;
    [SerializeField] private float genInterval = 4f;
    [SerializeField] private float xMaxOffset = 0.5f;
    [SerializeField] private float yMaxOffset = 0.5f;


    public void Update()
    {
        shootTimer -= Time.deltaTime;

        if (shootTimer <= 0)
        {
            shootTimer = genInterval;
            //实例化泡泡及其位置
            GameObject _newBubble = Instantiate(bubblePrefab);
            _newBubble.transform.parent = this.transform;
            float _xOffset = UnityEngine.Random.Range(-xMaxOffset, xMaxOffset);
            float _yOffset = UnityEngine.Random.Range(-yMaxOffset, yMaxOffset);
            _newBubble.transform.position = new Vector2(transform.position.x + _xOffset, transform.position.y + 0.5f + _yOffset);
        }
    }
}
