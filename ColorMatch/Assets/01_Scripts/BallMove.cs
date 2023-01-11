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
    public ParticleSystem destroyEffect;

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
        if(GameManager.instance.score >= 1500)
        {
            min += 0.3f;
            max += 0.6f;
        }

        if(GameManager.instance.score >= 2300)
        {
            min += 0.5f;
            max += 0.8f;
        }

        if(GameManager.instance.score >= 3000)
        {
            min += 0.9f;
            max += 1.1f;
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
            StartCoroutine(DestroyBall());
            
            if (collision.gameObject.tag == tag)
            {
                BallSpawn.instance.isCorrect = true;
                Debug.Log("O");
                GameManager.instance.score += 100;

                audioSource.PlayOneShot(successAudio);
            }
            else
            {
                Debug.Log("X");
                GameManager.instance.heart[GameManager.instance.health--].SetTrigger("Remove");
                GameManager.instance.score -= 100;

                audioSource.PlayOneShot(failAudio);
            }
        }
    }

    IEnumerator DestroyBall()
    {
        speed = 0;
        destroyEffect.Play();
        sp.enabled = false;
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
        BallSpawn.instance.ballCount--;
        Debug.Log("-");
        BallSpawn.instance.SpawnBall();
    }
}
