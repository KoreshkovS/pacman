using UnityEngine;

public class PowerPellet : Pellet
{
    [SerializeField] private float _duration = 8f;

    public float Duration => _duration;

    protected override void Eat()
    {
        FindObjectOfType<GameManager>().PowerPelletEaten(this);
    }
}
