using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuna : Enemy
{
    public Vector3 destination;
    private Vector3 aimVecNorm;

    public override void Start()
    {
        base.Start();

        aimVecNorm = (destination - transform.position).normalized;
        //由于素材图朝向为左侧，故transform.right应当朝向方向向量的反方向，即添加负号
        this.transform.right = -aimVecNorm;
    }

    public override void Update()
    {
        base.Update();

        //朝目的地游去
        SetVelocity(aimVecNorm.x * moveSpeed, aimVecNorm.y * moveSpeed);

        if (AlmostArrive())
            Die();
    }

    public virtual void SetDestination(Vector3 _dst)
    {
        destination = _dst;
    }

    public virtual bool AlmostArrive()
    {
        float _roundingDistance = 0.05f;

        if (Vector2.Distance(this.transform.position, destination) <= _roundingDistance)
            return true;
        return false;
    }
}
