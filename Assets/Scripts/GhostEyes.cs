using UnityEngine;

public class GhostEyes : MonoBehaviour
{
    [SerializeField] private Sprite _up;
    [SerializeField] private Sprite _down;
    [SerializeField] private Sprite _left;
    [SerializeField] private Sprite _right;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Movement _movement;

    private void Update()
    {
        if (_movement.direction == Vector2.up)
        {
            _spriteRenderer.sprite = _up;
        }
        else if (_movement.direction == Vector2.down)
        {
            _spriteRenderer.sprite = _down;
        }
        else if (_movement.direction == Vector2.left)
        {
            _spriteRenderer.sprite = _left;
        }
        else if (_movement.direction == Vector2.right)
        {
            _spriteRenderer.sprite = _right;
        }
    }
}
