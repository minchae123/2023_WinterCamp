using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.Events;
using DG.Tweening;


public class BtnManager : MonoBehaviour
{
    // �г�
    public GameObject RectPanel;
    public GameObject HexPanel;
    public GameObject tutPanel;

    // ��ư
    public GameObject StartBtn;
    public GameObject tutorialBtn;
    public GameObject tutOutBtn;
    public GameObject SoundOnBtn;
    public GameObject SoundOffBtn;
    public GameObject ExitBtn;
    public GameObject GobackBtn;


    private void Awake()
    {
        if(tutPanel!=null)
        {
            tutPanel.SetActive(false);
        }
        if(tutOutBtn!=null)
        {
            tutOutBtn.SetActive(false);
        }
        if (SoundOffBtn != null)
        {
            SoundOffBtn.SetActive(false);
        }
    }

    public void OnClickStart() // ��ŸƮ Ŭ����
    {
        // �簢�� ����
        RectPanel.transform.DOLocalMove(new Vector3(-250, 0, 0), 0.8f);
        RectPanel.SetActive(true);

        // ������ ����
        HexPanel.SetActive(true);
        HexPanel.transform.DOLocalMove(new Vector3(250, 0, 0), 0.8f);

        // ���ư��� ��ư
        GobackBtn.transform.DOLocalMove(new Vector3(0, -450, 0), 0.8f);

        // ��ư ��Ȱ��ȭ
        StartBtn.SetActive(false);
        tutorialBtn.SetActive(false);
        ExitBtn.SetActive(false);
    }

    public void OnClickGoBack() // ���ư��� ��ư Ŭ����
    {
        RectPanel.transform.DOLocalMove(new Vector3(-250, 3000, 0), 0.8f);
        HexPanel.transform.DOLocalMove(new Vector3(250, 3000, 0), 0.8f);
        GobackBtn.transform.DOLocalMove(new Vector3(0, 2500, 0), 0.8f);

        StartBtn.SetActive(true);
        tutorialBtn.SetActive(true);
        ExitBtn.SetActive(true);
    }

    public void OnClickTut() // Ʃ�丮�� ��ư Ŭ����
    {
        tutOutBtn.SetActive(true);
        tutPanel.SetActive(true);
    }

    public void OnClickTutOut() // Ʃ�丮�� X ��ư Ŭ����
    {
        tutOutBtn.SetActive(false);
        tutPanel.SetActive(false);
    }

    public void OnClick_RectStart() // �簢�� ���ý�
    {
        SceneManager.LoadScene("PlaySquare");
    }

    public void OnClick_Hexagon() // ������ ���ý�
    {
        SceneManager.LoadScene("PlayHexagon");
    }

    public void OnCliick_SoundOff() // ���� ���� �ϱ� (���� ON �̹��� Ŭ��)
    {
        AudioListener.volume = 0; // ���� ��� ���߱�

        SoundOnBtn.SetActive(false);
        SoundOffBtn.SetActive(true);
    }

    public void OnCliick_SoundON() // ���� �ְ� �ϱ� (���� OFF �̹��� Ŭ��)
    {
        AudioListener.volume = 1; // ���� �ٽ� ���

        SoundOnBtn.SetActive(true);
        SoundOffBtn.SetActive(false);
        
    }
}
