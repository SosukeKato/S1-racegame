using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    Rigidbody2D _rb;
    [SerializeField]
    int _directinalSpeed;

    float _speedMagnification = 1;
    float _speedUpCoolTime;
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
        Vector2 _origin = transform.position;
        //右にRayを発射
        Vector2 _right = Vector2.right;
        //Rayの長さ
        float _rightDistance = 5f;
        //右に出ているRayがオブジェクトに衝突した場合の処理
        if (Physics2D.Raycast(_origin, _right, _rightDistance).collider)
        {
            _speedMagnification = 0.5f;
        }
        else
        {
            _speedMagnification = 1;
        }
        //前にRayを発射
        Vector2 _front = Vector2.up;
        //Rayの長さ
        float _frontDistance = 5f;
        //前に出ているRayがオブジェクトに衝突した場合の処理
        if (Physics2D.Raycast(_origin, _front, _frontDistance).collider)
        {
            _speedUpCoolTime += Time.deltaTime;
            if (_speedUpCoolTime >= 5)
            {
                _speedUpCoolTime = 5;
            }
        }

        //Rayをシーンビューに描画
        Debug.DrawRay(_origin, _right * _rightDistance, Color.red);
#endregion
    }
}
