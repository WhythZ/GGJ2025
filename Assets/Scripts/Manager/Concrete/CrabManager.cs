using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabManager : Manager<CrabManager>
{
    [Header("Crab Settings")]
    //�༭���ڸ�ֵ
    public Crab crab;
    [SerializeField] private Vector3 refreshPos;

    [Header("Health Status")]
    public bool isAlive = true;
    [SerializeField] private int maxHealth = 3;
    [SerializeField] private int curHealth;

    [Header("Pearl Score")]
    public int score = 0;

    public void Start()
    {
        //crab = GameObject.Find("Crab").GetComponent<Crab>();
        
        curHealth = maxHealth;
    }

    public void Update()
    {
    }

    #region Accessibility
    public int GetCurrentHealth()
    {
        return curHealth;
    }
    #endregion

    #region HealthChange
    public IEnumerator TouchDeadZone()
    {
        //��������ֵ1
        GetHitBy(1);

        yield return new WaitForSeconds(0.8f);

        //�ع�ԭʼλ��
        crab.transform.position = refreshPos;
    }

    public void GetHitBy(int _damage)
    {
        AudioManager.instance.PlaySFX(5, CrabManager.instance.crab.transform);

        ChangeHealthBy(-_damage);
        crab.stateMachine.ChangeState(crab.hitState);
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

    #region Reborn
    public void Reborn()
    {
        isAlive = true;
        curHealth = maxHealth;
    }
    #endregion
}
