using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    Rigidbody2D _rb;
    [SerializeField]
    int _DirectinalSpeed;

    float _SpeedMagnification = 1;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _rb.velocity = new Vector2(_rb.velocity.x, _DirectinalSpeed * _SpeedMagnification);
    }
}
