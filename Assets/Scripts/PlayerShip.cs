using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class PlayerShip : MonoBehaviour
{
    [Header("Moving")]
    [SerializeField] public float maxSpeed = 100f;
    [SerializeField] float acceleration = 300f;

    [Header("Shooting")]
    [SerializeField] GameObject proyectilePrefab;
    [SerializeField] public int damage = 10;

    [Header("Controls")]
    [SerializeField] InputActionReference move;
    [SerializeField] InputActionReference shoot;
    [SerializeField] InputActionReference pause;

    [Header("Stats")]
    [SerializeField] Slider HealthBar;

    public int maxHealth;
    public int currHealth;
    AudioManager manager;



    public int paused = 0;
    Vector2 rawMove;

    private void Awake()
    {
        manager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        manager.gameStart();
    }

    void Start()
    {
        currHealth = maxHealth;
    }

    private void OnEnable()
    {
        move.action.Enable();
        shoot.action.Enable();
        pause.action.Enable();

        move.action.started += OnMove;
        move.action.performed += OnMove;
        move.action.canceled += OnMove;

        shoot.action.started += OnShoot;

        pause.action.started += OnPause;
        
    }

    

    Vector2 currentVelocity = Vector2.zero;
    const float rawMoveThresholdForBreaking = 0.1f;
    void Update()
    {
        if(rawMove.magnitude < rawMoveThresholdForBreaking)
        {
            currentVelocity *= 0.01f * Time.deltaTime;
        }
        currentVelocity += rawMove * acceleration * Time.deltaTime;

        float linearVelocity = currentVelocity.magnitude;
        linearVelocity = Mathf.Clamp(linearVelocity,0, maxSpeed);
        currentVelocity = currentVelocity.normalized * linearVelocity;
        transform.Translate(currentVelocity * Time.deltaTime);

        HealthBar.value = currHealth;
        HealthBar.maxValue = maxHealth;

    }

    private void OnMove(InputAction.CallbackContext obj)
    {
        rawMove = obj.ReadValue<Vector2>();
    }

    private void OnShoot(InputAction.CallbackContext obj)
    {
        manager.musicSFX(manager.shoot);
        GameObject shot = Instantiate(proyectilePrefab, transform.position, Quaternion.identity);
        shot.GetComponent<PlayerShot>().damage = damage;
    }

    private void OnPause(InputAction.CallbackContext context)
    {
        if (paused == 0)
        {
            PauseMenu.instance.Pause();
            paused = 1;
        }
        else
        {
            PauseMenu.instance.Resume();
            paused = 0;
        }
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyShot"))
        {
            currHealth--;
            Destroy(collision.gameObject);
        }
        if(currHealth <= 0)
        {
            GameOverMenu.instance.Lose();
        }

    }


    private void OnDisable()
    {
        move.action.Disable();
        shoot.action.Disable();

        move.action.performed -= OnMove;
        move.action.started -= OnMove;
        move.action.canceled -= OnMove;

        shoot.action.started -= OnShoot;
    }

}
