using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawn : MonoBehaviour
{
    public float spawnDelay = 0.5f;

    public static BallSpawn instance;
    public GameObject[] balls;

    public Transform[] trans;

    public string[] tagName;
    public Color[] ballColor;

    private AudioSource audioSource;
    public AudioClip spawnClip;

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
        StartCoroutine(Spawn());
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
        Instantiate(ball, trans[r].position, Quaternion.identity);

        yield return new WaitForSeconds(spawnDelay);
    }
}
