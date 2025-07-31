using UnityEngine;

public class CharacterClamp : MonoBehaviour
{
    [SerializeField]
    float _minX = 0f;
    [SerializeField]
    float _maxX = 11f;
    void Update()
    {
        Vector2 pos = transform.position;

        pos.x = Mathf.Clamp(pos.x, _minX, _maxX);

        transform.position = pos;
    }
}
