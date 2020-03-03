using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMove : MonoBehaviour
{
    [SerializeField] private Transform _movePoint;
    [SerializeField] private float _moveSpeed;

    private Vector3 _previousPosition;
    private Vector3 _moveTarget;
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _moveTarget = _movePoint.position;
        _previousPosition = transform.position;
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _moveTarget, _moveSpeed * Time.deltaTime);

        if (transform.position == _moveTarget)
        {
            ChangeDirection();
        }
    }

    private void ChangeDirection()
    {
        _moveTarget = _previousPosition;
        _previousPosition = transform.position;
        _spriteRenderer.flipX = !_spriteRenderer.flipX;
    }
}
