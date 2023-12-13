using UnityEngine;

public class GhostFrightened : GhostBehavior
{
    [SerializeField] private SpriteRenderer _body;
    [SerializeField] private SpriteRenderer _eyes;
    [SerializeField] private SpriteRenderer _blue;
    [SerializeField] private SpriteRenderer _white;
    [SerializeField] private bool _eaten;

    public override void Enable(float duration)
    {
        base.Enable(duration);

        _body.enabled = false;
        _eyes.enabled = false;
        _blue.enabled = true;
        _white.enabled = false;

        Invoke(nameof(Flash), duration / 2.0f);
    }

    public override void Disable()
    {
        base.Disable();

        _body.enabled = true;
        _eyes.enabled = true;
        _blue.enabled = false;
        _white.enabled = false;
    }

    private void Flash()
    {
        if (_eaten)
        {
            _blue.enabled = false;
            _white.enabled = true;
            _white.GetComponent<AnimetedSprite>().Restart();
        }
    }

    private void Eaten()
    {
        _eaten = true;

        Vector3 position = Ghost.Home.Inside.position;
        position.z = Ghost.transform.position.z;
        Ghost.transform.position = position;

        Ghost.Home.Enable(Duration);

        _body.enabled = false;
        _eyes.enabled = true;
        _blue.enabled = false;
        _white.enabled = false;
    }

    private void OnEnable()
    {
        Ghost.Movement.SpeedMultipier = 0.5f;
        _eaten = false;
    }

    private void OnDisable()
    {
        Ghost.Movement.SpeedMultipier = 1.0f;
        _eaten = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Pacman"))
        {
            if (enabled)
            {
                Eaten();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Node node = collision.GetComponent<Node>();

        if (node != null && enabled)
        {
            Vector2 direction = Vector2.zero;
            float maxDistance = float.MinValue;

            foreach (Vector2 avalableDirection in node.AvalableDirections)
            {
                Vector3 newPosition = transform.position + new Vector3(avalableDirection.x, avalableDirection.y);
                float distance = (Ghost.Target.position - newPosition).sqrMagnitude;

                if (distance > maxDistance)
                {
                    direction = avalableDirection;
                    maxDistance = distance;
                }
            }
            Ghost.Movement.SetDirection(direction);
        }
    }
}
