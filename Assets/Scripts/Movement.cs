using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _speed = 8f;
    [SerializeField] private float _speedMultipier = 1f;
    [SerializeField] private Vector2 _initialDirection;
    [SerializeField] private LayerMask _obstacleLayer;
}
