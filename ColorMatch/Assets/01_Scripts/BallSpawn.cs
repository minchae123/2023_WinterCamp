using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawn : MonoBehaviour
{
    public static BallSpawn instance;
    public GameObject[] balls;

    public Transform[] trans;

    public string[] tagName;
    public Color[] ballColor;

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
        int r =  Random.Range(0, balls.Length); // ���� ������
        int r1 =  Random.Range(0, balls.Length); // ���� �±��� ������

        GameObject ball = balls[r]; // �� ���� ������Ʈ �� �߿� ����
        ball.tag = tagName[r1]; // ���� �±׸� �������� �޾ƿ�
        SpriteRenderer sp = ball.GetComponent<SpriteRenderer>();
        sp.color = ballColor[r1]; // ���� ���� �±׿� ���� ���������� ����

        Instantiate(ball, trans[r].position , Quaternion.identity); 
    }
}
