using UnityEngine;

public class PlayerMover 
{
    private Transform _transform;
    private float _speed;
    private float _input;

    public PlayerMover(Transform transform, float speed)
    {
        _speed = speed;
        _transform = transform;
    }
    public void CustomUpdate(float delta, float input)
    {
        _input = input;

        if (input == 0)
        {
            return;
        }

        var direction = new Vector2(input, 0);
        _transform.localScale = new Vector3(direction.x, _transform.localScale.y, _transform.localScale.z);

        Move(direction, delta);
    }
    public bool CheckMove()
    {
        if (_input == 0)
            return false;
        else
            return true;
    }
    private void Move(Vector2 direction, float delta)
    {
        _transform.position += (Vector3)direction * delta * _speed;
    }

}
