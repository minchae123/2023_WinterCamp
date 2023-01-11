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
    // 패널
    public GameObject RectPanel;
    public GameObject HexPanel;
    public GameObject tutPanel;
    public GameObject TitlePanel;

    // 버튼
    public GameObject StartBtn;
    public GameObject tutorialBtn;
    public GameObject tutOutBtn;
    public GameObject SoundOnBtn;
    public GameObject SoundOffBtn;
    public GameObject ExitBtn;
    public GameObject GobackBtn;
    public Toggle muteBtn;

    private Button ExitBtn_B;
    private Button tutBtn_B;

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
/*
        if(tutPanel!=null)
        {
            tutPanel.SetActive(false);
        }
        if(tutOutBtn!=null)
        {
            tutOutBtn.SetActive(false);
        }*/
        if (SoundOffBtn != null)
        {
            SoundOffBtn.SetActive(false);
        }

        this.audios = this.gameObject.AddComponent<AudioSource>();
        this.audios.clip = this.ClickSound;
        this.audios.loop = false;
    }

    public void MuteUI(bool isMute)
    {
        audioManager.Mute(isMute);
    }

    public void OnClickStart() // 스타트 클릭시
    {
        this.audios.Play();

        // 사각형 선택
        RectPanel.transform.DOLocalMove(new Vector3(-250, 0, 0), 0.8f);
        RectPanel.SetActive(true);

        // 육각형 선택
        HexPanel.SetActive(true);
        HexPanel.transform.DOLocalMove(new Vector3(250, 0, 0), 0.8f);

        // 돌아가기 버튼
        GobackBtn.transform.DOLocalMove(new Vector3(0, -450, 0), 0.8f);

        // 버튼 비활성화
        StartBtn.SetActive(false);
        tutorialBtn.SetActive(false);
        ExitBtn.SetActive(false);
        TitlePanel.SetActive(false);
    }

    public void OnClickGoBack() // 돌아가기 버튼 클릭시
    {
        this.audios.Play();

        RectPanel.transform.DOLocalMove(new Vector3(-250, 3000, 0), 0.8f);
        HexPanel.transform.DOLocalMove(new Vector3(250, 3000, 0), 0.8f);
        GobackBtn.transform.DOLocalMove(new Vector3(0, 2500, 0), 0.8f);

        StartBtn.SetActive(true);
        tutorialBtn.SetActive(true);
        ExitBtn.SetActive(true);
        TitlePanel.SetActive(true);
    }

    public void OnClickTut() // 튜토리얼 버튼 클릭시
    {
        this.audios.Play();

        tutPanel.transform.DOLocalMove(new Vector3(0, 0, 0), 0.8f);

        ExitBtn_B.interactable = false;
        tutBtn_B.interactable = false;
    }

    public void OnClickTutOut() // 튜토리얼 X 버튼 클릭시
    {
        this.audios.Play();
        
        tutPanel.transform.DOLocalMove(new Vector3(-250, 3000, 0), 0.8f);

        ExitBtn_B.interactable = true;
        tutBtn_B.interactable = true;
    }

    public void OnClick_RectStart() // 사각형 선택시
    {
        this.audios.Play();

        SceneManager.LoadScene("PlaySquare");
    }

    public void OnClick_Hexagon() // 육각형 선택시
    {
        this.audios.Play();

        SceneManager.LoadScene("PlayHexagon");
    }

    public void OnClickExit()
    {
        Debug.Log("나가기");
    }

    /*
    public void OnCliick_SoundOff() // 사운드 없게 하기 (사운드 ON 이미지 클릭)
    {
        this.audios.Play();

        AudioListener.volume = 0; // 음악 재생 멈추기

        SoundOnBtn.SetActive(false);
        SoundOffBtn.SetActive(true);
    }

    public void OnCliick_SoundON() // 사운드 있게 하기 (사운드 OFF 이미지 클릭)
    {
        AudioListener.volume = 1; // 음악 다시 재생

        SoundOnBtn.SetActive(true);
        SoundOffBtn.SetActive(false);
        
    }
    */

    public void OnclickOnOff() // 볼륨 조절
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
