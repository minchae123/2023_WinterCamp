using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private UIManager uIManager;

    public int score;
    
    public int bestScore = 0;
    private string keyName = "BestScore";

    public int health = 2;
    public Animator[] heart;

    public AudioManager audioManager;
    // public AudioClip GameOverAudio;
    // AudioSource audioSource;

    public GameObject[] tiles;
    public int level = 0;


    public TextMeshProUGUI upgradeTxt;
    public TextMeshProUGUI countTxt;

    public GameObject[] spanwer;

    bool is1 = false;
    bool is2 = false;
    bool is3 = false;
    bool is4 = false;
    bool is5 = false;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

        audioManager = FindObjectOfType<AudioManager>();
        uIManager = FindObjectOfType<UIManager>();
        bestScore = PlayerPrefs.GetInt(keyName, 0);

        Instantiate(spanwer[0], transform.position, Quaternion.identity);
    }

    private void Update()
    {
        if(score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetInt(keyName, score);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Reset");
            PlayerPrefs.DeleteAll();
        }

        if(health < 0)
        {
            BallMove b = FindObjectOfType<BallMove>();
            if(b != null)
            {
                Destroy(b.gameObject);
                BallSpawn.instance.StopAllCoroutines();
            }
            uIManager.UpSlide();
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            score += 100;
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            if(health < 2)
            {
                Heal();
            }
        }

        if(score == 500 && is1 == false)
        {
            is1 = true;
            level = 1;
            StartCoroutine(LevelSetting(level));
        }
        if(score == 1000 && is2 == false)
        {
            is2 = true;
            level = 2;
            StartCoroutine(LevelSetting(level));
        }
        if(score == 1800 && is3 == false)
        {
            is3 = true;
            level = 3;
            StartCoroutine(LevelSetting(level));
        }
        if(score == 2500 && is4 == false)
        {
            is4 = true;
            level = 4;
            StartCoroutine(LevelSetting(level));
        }
        if(score == 3000 && is5 == false)
        {
            is5 = true;
            level = 5;
            StartCoroutine(LevelSetting(level));
        }
    }

    public IEnumerator LevelSetting(int level)
    {
        tiles[level-1].SetActive(false);
        GameObject d = FindObjectOfType<BallSpawn>().gameObject;
        if (d != null)
        {
            Destroy(d);
        }

        for(int i = 0; i < 2; i++)
        {
            upgradeTxt.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.3f);
            upgradeTxt.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.3f);
        }

        tiles[level].SetActive(true);
        Instantiate(spanwer[level], transform.position, Quaternion.identity);
    }

    public void Heal()
    {
        health++;
        int heal = GameManager.instance.health;
        heart[heal].SetTrigger("Recover");
    }
}
