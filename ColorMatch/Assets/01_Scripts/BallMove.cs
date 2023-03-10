using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    public Vector3 moveDir;

    public float speed;
    public float Speed { get => speed; set => speed = value; }

    public float max;
    public float min;

    public float delay;

    public bool isCheck = false;
    public GameObject edge;
    public ParticleSystem coEffect;
    public ParticleSystem wrEffect;

    public AudioClip successAudio;
    public AudioClip failAudio;

    SpriteRenderer sp;
    AudioSource audioSource;
    CircleCollider2D circleCollider;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        sp = GetComponent<SpriteRenderer>();
        circleCollider = GetComponent<CircleCollider2D>();
    }

    private void Start()
    {
        if(GameManager.instance.level == 0)
        {
        }
        if(GameManager.instance.level == 1)
        {
            min += 0.3f;
            max += 0.6f;
        }

        if (GameManager.instance.level == 2)
        {
            min += 0.4f;
            max += 0.8f;
        }

        if(GameManager.instance.level == 3)
        {
            min += 0.6f;
            max += 1.0f;
        }

        if (GameManager.instance.level == 4)
        {
            min += 0.6f;
            max += 1.0f;
        }

        if (GameManager.instance.level == 5)
        {
            min += 0.6f;
            max += 1.0f;
        }
        speed = Random.Range(min, max);
    }

    private void Update()
    {
        transform.position += moveDir * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(isCheck == false)
        {
            isCheck = true;
            circleCollider.enabled = false;
            Destroy(edge);
            StartCoroutine(DestroyBall());
            
            if (collision.gameObject.tag == tag)
            {
                coEffect.Play();
                BallSpawn.instance.isCorrect = true; 
                GameManager.instance.score += 100;
                audioSource.PlayOneShot(successAudio);
            }
            else
            {
                wrEffect.Play();
                GameManager.instance.heart[GameManager.instance.health--].SetTrigger("Remove");
                audioSource.PlayOneShot(failAudio);
            }
        }
    }

    IEnumerator DestroyBall()
    {
        speed = 0;
        sp.enabled = false;
        yield return new WaitForSeconds(delay);

        BallSpawn g = FindObjectOfType<BallSpawn>();
        if (g != null)
        {
            BallSpawn.instance.ballCount--;
            BallSpawn.instance.SpawnBall();
        }
        Destroy(gameObject);
    }
}
