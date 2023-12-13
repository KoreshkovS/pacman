using UnityEngine;

public abstract class GhostBehavior : MonoBehaviour
{
    [SerializeField] private Ghost _ghost;
    [SerializeField] private float _duration;

    public Ghost Ghost => _ghost;
    public float Duration => _duration;

    private void Awake()
    {
        enabled = false;
    }

    public void Enable()
    {
        Enable(Duration);
    }

    public virtual void Enable(float duration)
    {
        enabled = true;

        CancelInvoke();
        Invoke(nameof(Disable), duration);
    }

    public virtual void Disable()
    {
        enabled = false;

        CancelInvoke();
    }
}
