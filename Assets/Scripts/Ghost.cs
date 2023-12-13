using UnityEngine;

public class Ghost : MonoBehaviour
{
    [SerializeField] private int _points = 200;
    [SerializeField] private Movement _movement;
    [SerializeField] private GhostHome _home;
    [SerializeField] private GhostScatter _scatter;
    [SerializeField] private GhostChase _chase;
    [SerializeField] private GhostFrightened _frightened;
    [SerializeField] private GhostBehavior _initualBehavior;
    [SerializeField] private Transform _target;

    public int Points => _points;

    public GhostFrightened Frightened => _frightened;
    public Movement Movement  => _movement;
    public GhostChase Chase => _chase;
    public GhostScatter Scatter => _scatter;
    public Transform Target => _target;
    public GhostHome Home => _home;

    private void Start()
    {
        ResetState();
    }

    public void ResetState()
    {
        gameObject.SetActive(true);
        Movement.ResetState();

        Chase.Disable();
        Scatter.Enable();
        _frightened.Disable();


        if (Home != _initualBehavior)
        {
            Home.Disable();
        }

        if (_initualBehavior != null)
        {
            _initualBehavior.Enable();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Pacman"))
        {
            if (_frightened.enabled)
            {
                FindObjectOfType<GameManager>().GhostEaten(this);
            }
            else
            {
                FindObjectOfType<GameManager>().PacmanEaten();
            }
        }
    }
}
