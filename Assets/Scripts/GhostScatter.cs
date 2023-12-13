using UnityEngine;

public class GhostScatter : GhostBehavior
{

    private void OnDisable()
    {
        Ghost.Chase.Enable();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Node node = collision.GetComponent<Node>();

        if (node != null && enabled && !Ghost.Frightened.enabled)
        {
            int index = Random.Range(0, node.AvalableDirections.Count);

            if (node.AvalableDirections.Count > 1 && node.AvalableDirections[index] == -Ghost.Movement.direction)
            {
                index++;

                if (index >= node.AvalableDirections.Count)
                {
                    index = 0;
                }
            }

            Ghost.Movement.SetDirection(node.AvalableDirections[index]);
        }
    }
}
