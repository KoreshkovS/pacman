using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class AnimetedSprite : MonoBehaviour
{
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private float _animTime = 0.25f;
    [SerializeField] private bool _loop = true;

    public int AnimationFrame { get; private set; }

    private void Start()
    {
        InvokeRepeating(nameof(Advance), _animTime, _animTime);
    }

    private void Advance()
    {
        if (!_spriteRenderer.enabled)
        {
            return;
        }

        AnimationFrame++;
        if (AnimationFrame >= _sprites.Length && _loop)
        {
            AnimationFrame = 0;
        }

        if (AnimationFrame >= 0 && AnimationFrame < _sprites.Length)
        {
            _spriteRenderer.sprite = _sprites[AnimationFrame];
        }
    }

    public void Restart()
    {
        AnimationFrame = -1;

        Advance();
    }
}
