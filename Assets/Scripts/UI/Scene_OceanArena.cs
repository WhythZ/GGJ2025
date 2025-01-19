using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_OceanArena : MonoBehaviour
{
    private bool showDeathUI = false;

    [Header("UI Menus")]
    [SerializeField] private GameObject inGameUI;
    [SerializeField] private GameObject deathUI;

    public void Update()
    {
        if (!CrabManager.instance.isAlive)
        {
            AudioManager.instance.StopAllBGM();
            AudioManager.instance.PlaySFX(11, this.transform);

            inGameUI.SetActive(false);
            deathUI.SetActive(true);
            Time.timeScale = 0;

            showDeathUI = true;
        }

        if (Input.GetKeyDown(KeyCode.Return) && showDeathUI)
            Restart();
    }

    public void Restart()
    {
        showDeathUI = false;

        //�ָ�ʱ��߶�
        Time.timeScale = 1;
        
        //��ȡ��ǰ����ĳ���
        Scene _scene = SceneManager.GetActiveScene();
        //���¼��ص�ǰ����
        SceneManager.LoadScene(_scene.name);

        //�������
        CrabManager.instance.Reborn();
    }
}
