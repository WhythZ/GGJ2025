using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Manager<AudioManager>
{
    #region SFX
    //������Ч��sound effect�����б�
    [SerializeField] AudioSource[] sfx;
    //��Ч���ŵļ��뾶��̫Զ����Ч���貥��
    [SerializeField] float sfxMinPlayRadius;
    #endregion

    #region BGM
    //���汳�����ֵ��б�
    [SerializeField] AudioSource[] bgm;
    //�Ƿ�Ӧ������һ��ʱ����һֱ������ĳ��������
    public bool isPlayBGM;
    //���ŵ�bgm�ı��
    public int bgmIndex;
    #endregion

    private void Update()
    {
        //����bgm�Ĳ���
        if (!isPlayBGM)
            StopAllBGM();
        else
        {
            //��Ӧ�����ŵ�bgmû�в��ţ���ʼ���ţ�û�д�if�ᵼ��һֱ��ͷ��ʼ����Ŷ~��
            if (!bgm[bgmIndex].isPlaying)
                PlayBGM(bgmIndex);
        }
    }

    #region SFX
    public void PlaySFX(int _sfxIndex, Transform _sfxSource)
    //������Ч����Լ���Ч����Դλ�ã����ڶ�������null����������Ч���ŵ��������ϣ�����������Լ�����Ч
    {
        //����Ŵ������б��ڣ���Ŵ�0��ʼŶ��
        if (_sfxIndex < sfx.Length && sfx[_sfxIndex] != null)
        {
            //һ��Сtrick,���������Ŀ����Ч������
            //sfx[_sfxIndex].pitch = UnityEngine.Random.Range(0.85f, 1.1f);

            //������Ч
            sfx[_sfxIndex].Play();
        }
    }
    //ֹͣ��Ч
    public void StopSFX(int _sfxIndex) => sfx[_sfxIndex].Stop();
    #endregion

    #region BGM
    public void PlayBGM(int _index)
    //������Ч���
    {
        //����Ŵ������б��ڣ���Ŵ�0��ʼŶ��
        if (_index < bgm.Length)
        {
            //bgmIndex��������ȷ����ǰ����bgm�ı���
            bgmIndex = _index;
            //����ǰӦ����ֹͣ�����������б�������
            StopAllBGM();
            //���ű�������
            bgm[bgmIndex].Play();
        }
    }
    public void PlayRandomBGM()
    //�������bgm
    {
        bgmIndex = UnityEngine.Random.Range(0, bgm.Length);
        PlayBGM(bgmIndex);
    }
    //�ر����б�������
    public void StopAllBGM()
    {
        for (int i = 0; i < bgm.Length; i++)
        {
            bgm[i].Stop();
        }
    }
    #endregion
}
