using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine<S> where S : BaseState
{
    public S currentState { get; private set; }

    public S formerState { get; private set; }

    public void Initialize(S _startState)
    {
        //�趨���״̬���ĳ�ʼ״̬���������״̬
        this.currentState = _startState;
        currentState.OnEnter();
    }

    public void ChangeState(S _newState)
    {
        //�˳���һ��״̬������������Ĳ�������Ϊfalse��
        currentState.OnExit();
        //��ת��״̬֮ǰ����¼���Ǵ�ʲô״̬ת��������һ��״̬
        formerState = currentState;
        //���õ�ǰ״̬Ϊ�����״̬��Ȼ������״̬������������Ĳ�������Ϊtrue��
        currentState = _newState;
        currentState.OnEnter();
    }
}
