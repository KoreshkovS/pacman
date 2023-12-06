using UnityEngine;

public class Passage : MonoBehaviour
{
    [SerializeField] private Transform _connection;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Vector3 position = collision.transform.position;

        position.x = _connection.position.x;
        position.y = _connection.position.y;

        collision.transform.position = position;
    }
}
