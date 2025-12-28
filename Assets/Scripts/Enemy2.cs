using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Enemy2 : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] int isRunning = 1;
    [SerializeField] int pointsDeath = 100;
    [SerializeField] int expDeath = 50;
    [SerializeField] int hp = 20;
    [SerializeField] int attackSpeed = 1;

    [Header("Shooting")]
    [SerializeField] GameObject proyectilePrefab;

    Vector3 linearVelocity = Vector3.left;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isRunning == 1)
        {
            StartCoroutine(Shot());
        }


        transform.Translate(speed * linearVelocity * Time.deltaTime);
        if(transform.position.y  < -2)
        {
            linearVelocity = Vector3.right;
        }
        if(transform.position.y > 2.5)
        {
            Destroy(gameObject);
        }
    }

    public IEnumerator Shot()
    {
        isRunning = 0;
        yield return new WaitForSeconds(attackSpeed);
        Instantiate(proyectilePrefab, transform.position, Quaternion.identity);
        isRunning = 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerShot shot = collision.GetComponent<PlayerShot>();
        if (collision.CompareTag("PlayerShot"))
        {
            Destroy(collision.gameObject);
            hp -= shot.damage;
            
        }
        if (hp <= 0)
        {
            AudioManager.instance.musicSFX(AudioManager.instance.death);
            Destroy(gameObject);
            ScoreManager.instance.AddScore(pointsDeath);
            EXPManager.instance.AddEXP(expDeath);
            
        }
    }


}
