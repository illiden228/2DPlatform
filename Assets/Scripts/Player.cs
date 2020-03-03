using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public event UnityAction<int> TakeMoney; 

    [SerializeField] private int _health;
    [SerializeField] private int _moneysCount;
    [SerializeField] private HealthPointsRenderer _healthPointsRenderer;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Transform _isGround;

    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private bool _canMoving;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _canMoving = true;
        _health = 3;
        for (int i = 0; i < _health; i++)
        {
            _healthPointsRenderer.AddHealth();
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
        _healthPointsRenderer.RemoveHealth();
        _health--;
        if(_health <= 0)
        {
            SceneManager.LoadScene(2);
        }
    }

    public void GetMoney()
    {
        _moneysCount++;
        TakeMoney?.Invoke(_moneysCount);
    }

    private void AllowMoving()
    {
        _canMoving = true;
    }
}
