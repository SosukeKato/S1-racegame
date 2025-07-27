using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    Rigidbody2D _rb;
    [SerializeField]
    int _directinalSpeed;

    float _speedMagnification = 1;
    bool _characterLeft;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //y軸の移動処理
        _rb.velocity = new Vector2(_rb.velocity.x, _directinalSpeed * _speedMagnification);

#region Raycastを使って条件の分岐を作る
        //Rayの発射場所
        Vector2 origin = transform.position;
        //右にRayを発射
        Vector2 direction = Vector2.right;
        //Rayの長さ
        float distance = 5f;
        //Rayがオブジェクトに衝突した場合の処理
        if (Physics2D.Raycast(origin, direction, distance).collider)
        {
            _speedMagnification = 0.5f;
        }
        //Rayをシーンビューに描画
        Debug.DrawRay(origin, direction * distance, Color.red);
#endregion
    }
}
