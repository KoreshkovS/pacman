using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _speed = 8f;
    [SerializeField] private float _speedMultipier = 1f;
    [SerializeField] private Vector2 _initialDirection;
    [SerializeField] private LayerMask _obstacleLayer;

    public Vector2 direction { get; private set; }
    public Vector2 nextDirection { get; private set; }
    public Vector3 startingPosition { get; private set; }
    public Rigidbody2D Rigidbody => _rigidbody;
    public float SpeedMultipier { get => _speedMultipier; set => _speedMultipier = value; }

    private void Awake()
    {
        startingPosition = transform.position;
    }

    private void Start()
    {
        ResetState();
    }

    private void Update()
    {
        if (nextDirection != Vector2.zero)
        {
            SetDirection(nextDirection);
        }
    }

    private void FixedUpdate()
    {
        Vector2 position = _rigidbody.position;
        Vector2 translation = direction * _speed * _speedMultipier * Time.fixedDeltaTime;
        _rigidbody.MovePosition(position + translation);
    }

    public void ResetState()
    {
        _speedMultipier = 1f;
        direction = _initialDirection;
        nextDirection = Vector2.zero;
        transform.position = startingPosition;
        _rigidbody.isKinematic = false;
        enabled = true;
    }

    public void SetDirection(Vector2 direction, bool forced = false)
    {
        if (forced || !Occupied(direction))
        {
            this.direction = direction;
            nextDirection = Vector2.zero;
        }
        else
        {
            nextDirection = direction;
        }
    }

    public bool Occupied(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.BoxCast(transform.position, Vector2.one * 0.75f, 0.0f, direction, 1.5f, _obstacleLayer);
        return hit.collider != null;
    }
}
