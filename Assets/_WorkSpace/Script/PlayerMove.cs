using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    Rigidbody2D _rb;
    [SerializeField]
    int _DirectinalSpeed;
    [SerializeField]
    int _PlayerSpeed;
    [SerializeField]
    float x;

    float _SpeedMagnification = 1;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //x²‚ÌˆÚ“®ˆ—
        x = Input.GetAxisRaw("Horizontal");
        Vector2 velocity = new Vector2(x, _DirectinalSpeed).normalized;
        _rb.velocity = velocity * _PlayerSpeed;
        //y²‚ÌˆÚ“®ˆ—
        _rb.velocity = new Vector2(_rb.velocity.x, _DirectinalSpeed * _SpeedMagnification);
        //Œ¸‘¬‚Ìˆ—
        if (Input.GetKeyDown(KeyCode.S))
        {
            _SpeedMagnification = 0.5f;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            _SpeedMagnification = 1;
        }
    }
}
