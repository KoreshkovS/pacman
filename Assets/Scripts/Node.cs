using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    [SerializeField] private List<Vector2> _avalableDirections = new List<Vector2>();
    [SerializeField] private LayerMask _obstacleLayer;

    public List<Vector2> AvalableDirections => _avalableDirections; 

    private void Start()
    {
        CheckAvailableDirection(Vector2.up);
        CheckAvailableDirection(Vector2.down);
        CheckAvailableDirection(Vector2.left);
        CheckAvailableDirection(Vector2.right);
    }

    private void CheckAvailableDirection(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.BoxCast(transform.position, Vector2.one * 0.5f, 0.0f, direction, 1.0f, _obstacleLayer);

        if (hit.collider == null)
        {
            AvalableDirections.Add(direction);
        }
    }

}
