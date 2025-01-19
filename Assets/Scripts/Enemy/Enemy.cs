using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region Components
    public Animator anim;
    public Rigidbody2D rb;
    #endregion

    #region Movement
    [Header("Movement")]
    public float moveSpeed = 1f;
    #endregion

    #region Collision
    [Header("Collision")]
    [SerializeField] protected GameObject checkRegion;
    #endregion

    public virtual void Awake()
    {
        #region Components
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        #endregion
    }

    public virtual void Start()
    {
    }

    public virtual void Update()
    {   
    }

    #region Velocity
    public virtual void SetVelocity(float _xVelocity, float _yVelocity)
    {
        rb.velocity = new Vector2(_xVelocity, _yVelocity);
    }
    #endregion

    #region Die
    public virtual void Die()
    {
        Destroy(this.gameObject);
    }
    #endregion

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Crab>() != null)
            CrabManager.instance.GetHitBy(1);

        if (collision.GetComponent<Bubble>() != null)
            collision.GetComponent<Bubble>().Explode();
    }
}
