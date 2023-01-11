using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using UnityEngine.Events;
using DG.Tweening;


public class BtnManager : MonoBehaviour
{
    // �г�
    public GameObject tutPanel;
    public GameObject TitlePanel;
    public GameObject ChoosePanel;

    // ��ư
    public GameObject StartBtn;
    public GameObject tutorialBtn;
    public GameObject tutOutBtn;
    public GameObject SoundOnBtn;
    public GameObject SoundOffBtn;
    public GameObject ExitBtn;
    public Toggle muteBtn;

    private Button ExitBtn_B;
    private Button tutBtn_B;
    private Button StartBtn_B;

    private AudioSource audios;
    public AudioClip ClickSound;
    private AudioManager audioManager;

    bool OnOff = true;


    private void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
        audioManager.CheckMute(muteBtn);

        ExitBtn_B = GameObject.Find("ExitBtn").GetComponent<Button>();
        tutBtn_B = GameObject.Find("TutorialBtn").GetComponent<Button>();
        StartBtn_B = GameObject.Find("StartBtn").GetComponent<Button>();

        if (SoundOffBtn != null)
        {
            SoundOffBtn.SetActive(false);
        }

        audios = gameObject.AddComponent<AudioSource>();
        audios.clip = ClickSound;
        audios.loop = false;
    }

    public void MuteUI(bool isMute)
    {
        audioManager.Mute(isMute);
    }

    public void OnClickStart() // ��ŸƮ Ŭ����
    {
        audios.Play();

        ChoosePanel.transform.DOLocalMove(new Vector3(0, -1400, 0), 0.8f);
        
        /*// �簢�� ����
        RectPanel.transform.DOLocalMove(new Vector3(-250, 0, 0), 0.8f);
        RectPanel.SetActive(true);

        // ������ ����
        HexPanel.SetActive(true);
        HexPanel.transform.DOLocalMove(new Vector3(250, 0, 0), 0.8f);

        // ���ư��� ��ư
        GobackBtn.transform.DOLocalMove(new Vector3(0, -450, 0), 0.8f);*/

        // ��ư ��Ȱ��ȭ
        StartBtn.SetActive(false);
        tutorialBtn.SetActive(false);
        ExitBtn.SetActive(false);
        TitlePanel.SetActive(false);
    }

    public void OnClickGoBack() // ���ư��� ��ư Ŭ����
    {
        audios.Play();
/*
        RectPanel.transform.DOLocalMove(new Vector3(-250, 2000, 0), 0.8f);
        HexPanel.transform.DOLocalMove(new Vector3(250, 2000, 0), 0.8f);
        GobackBtn.transform.DOLocalMove(new Vector3(0, 1600, 0), 0.8f);
*/
        ChoosePanel.transform.DOLocalMove(new Vector3(0, 1000, 0), 0.8f);

        StartBtn.SetActive(true);
        tutorialBtn.SetActive(true);
        ExitBtn.SetActive(true);
        TitlePanel.SetActive(true);
    }

    public void OnClickTut() // Ʃ�丮�� ��ư Ŭ����
    {
        audios.Play();

        tutPanel.transform.DOLocalMove(new Vector3(0, 0, 0), 0.8f);

        StartBtn_B.interactable = false;
        ExitBtn_B.interactable = false;
        tutBtn_B.interactable = false;
    }

    public void OnClickTutOut() // Ʃ�丮�� X ��ư Ŭ����
    {
        audios.Play();
        
        tutPanel.transform.DOLocalMove(new Vector3(0, -2000, 0), 0.8f);

        StartBtn_B.interactable = true;
        ExitBtn_B.interactable = true;
        tutBtn_B.interactable = true;
    }

    public void OnClick_RectStart() // �簢�� ���ý�
    {
        SceneManager.LoadScene("PlaySquare");
    }

    public void OnClick_Hexagon() // ������ ���ý�
    {
        SceneManager.LoadScene("PlayHexagon");
    }

    public void OnClickExit()
    {
        Debug.Log("������");
        Application.Quit();
    }

    /*
    public void OnCliick_SoundOff() // ���� ���� �ϱ� (���� ON �̹��� Ŭ��)
    {
        this.audios.Play();

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
    */

    public void OnclickOnOff() // ���� ����
    {
        if(OnOff)
        {
            AudioListener.volume = 0;
            OnOff = false;
        }
        else
        {
            AudioListener.volume = 1;
            OnOff = true;
        }
    }
}
