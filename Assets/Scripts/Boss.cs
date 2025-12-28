using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Boss : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] int isRunning = 1;
    [SerializeField] int pointsDeath = 100;
    [SerializeField] int expDeath = 50;
    [SerializeField] int hp = 20;
    [SerializeField] int attackSpeed = 1;
    [SerializeField] Transform leftShoot;
    [SerializeField] Transform rightShoot;

    [Header("Shooting")]
    [SerializeField] GameObject proyectilePrefab;

    Vector3 linearVelocity = Vector3.up;
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
        if(transform.position.x  < 1.25)
        {
            linearVelocity = Vector3.zero;
        }
        
    }

    public IEnumerator Shot()
    {
        isRunning = 0;
        yield return new WaitForSeconds(attackSpeed);
        float t = Random.Range(0f, 1f);
        Vector3 spawnPos = Vector3.Lerp(leftShoot.position, rightShoot.position,t);
        Instantiate(proyectilePrefab, spawnPos, Quaternion.identity);
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
            AudioManager.instance.musicSFX(AudioManager.instance.bossDeath);
            Destroy(gameObject);
            ScoreManager.instance.AddScore(pointsDeath);
            EXPManager.instance.AddEXP(expDeath);
            
        }
    }


}
