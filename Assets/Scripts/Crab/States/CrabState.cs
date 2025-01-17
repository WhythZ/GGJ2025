using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabState : BaseState
{
    protected Crab player;

    public CrabState(Animator _anim, string _animBoolName) : base(_anim, _animBoolName)
    {
    }

    //ˮƽ����ֱ�ٶ���������
    public float xInput { get; private set; }
    public float yInput { get; private set; }
}
