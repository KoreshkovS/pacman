using UnityEngine;

public class Ghost : MonoBehaviour
{
    [SerializeField] private int _points = 200;

    public int Points => _points;
}
