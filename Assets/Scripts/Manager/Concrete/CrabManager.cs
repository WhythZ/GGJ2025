using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabManager : Manager<CrabManager>
{
    [Header("Crab Settings")]
    //编辑器内赋值
    public Crab crab;
    [SerializeField] private Vector3 refreshPos;

    [Header("Health Status")]
    public bool isAlive = true;
    [SerializeField] private int maxHealth = 3;
    [SerializeField] private int curHealth;

    public void Start()
    {
        //crab = GameObject.Find("Crab").GetComponent<Crab>();
        
        curHealth = maxHealth;
    }

    public void Update()
    {
    }

    #region BeHit
    public void GetHitBy(int _damage)
    {
        //AudioManager.PlaySFX();

        ChangeHealthBy(-_damage);
        crab.stateMachine.ChangeState(crab.hitState);
    }
    #endregion

    #region HealthChange
    public void TouchDeadZone()
    {
        //减少生命值1
        GetHitBy(1);

        //回归原始位置
        crab.transform.position = refreshPos;
    }

    public void ChangeHealthBy(int _incre)
    {
        if (_incre == 0)
            return;
        if (_incre > 0)
            curHealth = curHealth + _incre >= maxHealth ? maxHealth : curHealth + _incre;
        else
        {
            int _decre = - _incre;
            if (curHealth - _decre <= 0)
            {
                curHealth = 0;
                Die();
            }
            else
                curHealth -= _decre;
        }
    }

    public void Die()
    {
        isAlive = false;
    }
    #endregion
}
