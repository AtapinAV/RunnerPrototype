using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldPlayerController : BasePlayerController
{
    
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space)) Jump();
        var direction = Input.GetAxis("Horizontal");
        if (direction == 0f) return;

        _body.velocity += direction * _speedSide * transform.right * Time.fixedDeltaTime;
    }
}
