using UnityEngine;

public class GhostChase : GhostBehavior
{
    private void OnDisable()
    {
        Ghost.Scatter.Enable();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Node node = collision.GetComponent<Node>();

        if (node != null && enabled && !Ghost.Frightened.enabled)
        {
            Vector2 direction = Vector2.zero;
            float minDistance = float.MaxValue;

            foreach (Vector2 avalableDirection in node.AvalableDirections)
            {
                Vector3 newPosition = transform.position + new Vector3(avalableDirection.x, avalableDirection.y);
                float distance = (Ghost.Target.position - newPosition).sqrMagnitude;

                if (distance < minDistance)
                {
                    direction = avalableDirection;
                    minDistance = distance;
                }
            }
            Ghost.Movement.SetDirection(direction);
        }
    }
}
