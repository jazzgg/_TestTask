using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover 
{
    private SpriteRenderer _spriteRenderer;
    private Transform _transform;
    private float _speed;

    public PlayerMover(Transform transform, SpriteRenderer spriteRenderer)
    {
        _speed = 10;
        _transform = transform;
        _spriteRenderer = spriteRenderer;
    }
    public void CustomUpdate(float delta, float input)
    {
        if (input == 0)
            return;
        var direction = new Vector2(input, 0);
        _transform.localScale = new Vector3(direction.x, _transform.localScale.y, _transform.localScale.z);
        Move(direction, delta);
    }
    private void Move(Vector2 direction, float delta)
    {
        _transform.position += (Vector3)direction * delta * _speed;
    }

}
