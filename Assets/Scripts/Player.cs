using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int Health;
    public int MoneysCount;
    public HealthPointsRenderer HealthPointsRenderer;
    public MoneyRenderer MoneyRenderer;

    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private bool _canMoving;

    [SerializeField] private float _jumpForce;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Transform _isGround;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _canMoving = true;
        Health = 3;
        for (int i = 0; i < Health; i++)
        {
            HealthPointsRenderer.AddHealth();
        }
    }


    private void Update()
    {
        PlayerMoving(KeyCode.A, _moveSpeed, true, Vector3.left);
        PlayerMoving(KeyCode.D, _moveSpeed, false, Vector3.right);
        PlayerJump(KeyCode.W, _jumpForce);
    }

    private void PlayerMoving(KeyCode key, float moveSpeed, bool flip, Vector3 direction)
    {
        if (Input.GetKey(key) && _canMoving)
        {
            transform.position += direction * moveSpeed * Time.deltaTime;
            _spriteRenderer.flipX = flip;
            _animator.Play("run");
        }
    }

    private void PlayerJump(KeyCode key, float jumpForce)
    {
        
        if (Input.GetKeyDown(key) && IsGround(_isGround) && _canMoving)
        {
            _rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            _animator.Play("jump");
        }
    }

    private bool IsGround(Transform origin)
    {
        if (Physics2D.Raycast(origin.position, Vector2.down, 0.1f))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void TakeDamage()
    {
        _animator.Play("hurt");
        Invoke("AllowMoving", 0.5f);
        _canMoving = false;
        HealthPointsRenderer.RemoveHealth();
        Health--;
        if(Health <= 0)
        {
            SceneManager.LoadScene(2);
        }
    }

    public void GetMoney()
    {
        MoneysCount++;
        MoneyRenderer.WriteMoney(MoneysCount);
    }

    private void AllowMoving()
    {
        _canMoving = true;
    }
}
