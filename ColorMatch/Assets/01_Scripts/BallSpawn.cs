using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawn : MonoBehaviour
{
    public float spawnDelay = 2f;

    public static BallSpawn instance;
    public GameObject[] balls;

    public int ballCount = 0;
    public int maxBallCount = 1;

    public Transform[] trans;

    public string[] tagName;
    public Color[] ballColor;

    private AudioSource audioSource;
    public AudioClip spawnClip;

    private AudioSource audios;
    public AudioClip jumpSound;

    public bool isCorrect = false;

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

        audioSource = GetComponent<AudioSource>();

        this.audios = this.gameObject.AddComponent<AudioSource>();
        this.audios.clip = this.jumpSound;
        this.audios.loop = false;
    }

    private void Start()
    {
        SpawnBall();   
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SpawnBall();
        }

    }

    public void SpawnBall()
    {
        isCorrect = false;
        if (ballCount < maxBallCount)
        {
            StartCoroutine(Spawn());
        }
        else
        {
            return;
        }
    }

    IEnumerator Spawn()
    {
        int r = Random.Range(0, balls.Length); // ���� ������
        int r1 = Random.Range(0, balls.Length); // ���� �±��� ������
 
        GameObject ball = balls[r]; // �� ���� ������Ʈ �� �߿� ����
        ball.tag = tagName[r1]; // ���� �±׸� �������� �޾ƿ�
        SpriteRenderer sp = ball.GetComponent<SpriteRenderer>();
        sp.color = ballColor[r1]; // ���� ���� �±׿� ���� ���������� ����
 
        audioSource.PlayOneShot(spawnClip);
        ballCount++;
        Instantiate(ball, trans[r].position, Quaternion.identity);
        yield return new WaitForSeconds(spawnDelay);
    }
}
