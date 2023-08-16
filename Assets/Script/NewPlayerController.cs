using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerController : BasePlayerController
{
    private RunnerControls _control;

    private void Awake()
    {
        _control = new RunnerControls();
        _control.Player.Jump.performed += _ => Jump();
    }

    private void FixedUpdate()
    {
        var direction = _control.Player.SideMove.ReadValue<float>();
        if (direction == 0f) return;

        _body.velocity += direction * _speedSide * transform.right * Time.fixedDeltaTime;
    }

    private void OnEnable()
    {
        _control.Player.Enable();
    }

    private void OnDisable()
    {
        _control.Player.Disable();
    }

    private void OnDestroy()
    {
        _control.Dispose();
    }
}

