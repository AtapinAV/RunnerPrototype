using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BasePlayerController : MonoBehaviour
{
    private bool _canJump = true;
    protected Rigidbody _body;

    [SerializeField, Tooltip("скорость движения")] private float _speed;
    [SerializeField, Tooltip("сила прыжка")] private float _jumpForce;
    [SerializeField, Tooltip("скорость движения в бок")] protected float _speedSide;
    private void Start()
    {
        _body = GetComponent<Rigidbody>();
        StartCoroutine(MoveForward());
    }

    protected void Jump()
    {
        if (!_canJump) return;
        _canJump = false;
        _body.AddForce(transform.up * _jumpForce);
    }

    private IEnumerator MoveForward()
    {
        while (true)
        {
            _body.velocity += transform.forward * _speed * Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        _canJump = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        _canJump = false;
    }
}
