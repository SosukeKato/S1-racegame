using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    Rigidbody2D _rb;
    [SerializeField]
    int _directinalSpeed;
    [SerializeField]
    int _playerSpeed;
    [SerializeField]
    float x;

    float _speedUpCoolTime = 0;
    float _speedMagnification = 1;
    bool _characterBack;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //x���̈ړ�����
        x = Input.GetAxisRaw("Horizontal");
        Vector2 velocity = new Vector2(x, _directinalSpeed).normalized;
        _rb.velocity = velocity * _playerSpeed;
        //y���̈ړ�����
        _rb.velocity = new Vector2(_rb.velocity.x, _directinalSpeed * _speedMagnification);
        //�����̏���
        if (Input.GetKeyDown(KeyCode.S))
        {
            _speedMagnification = 0.5f;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            _speedMagnification = 1;
        }
        //�����̏���
        if (Input.GetKeyDown(KeyCode.Space) && _speedUpCoolTime == 5)
        {
            _speedMagnification = 2;
            _speedUpCoolTime = 0;
        }
        #region Raycast��Player�̑O����NPC�����邩�ǂ������ׂ鏈��
        //Ray�̔��ˏꏊ
        Vector2 _origin = transform.position;
        //Ray�̔��˕���
        Vector2 _front = Vector2.up;
        //Ray�̒���
        float _frontDistance = 5f;
        //(Player��NPC�̔w��ɂ��鎞)Ray���I�u�W�F�N�g�ɏՓ˂����ꍇ�̏���
        if (Physics2D.Raycast(_origin, _front, _frontDistance).collider)
        {
            _speedUpCoolTime += Time.deltaTime;
            if (_speedUpCoolTime >= 5)
            {
                _speedUpCoolTime = 5;
            }
        }
        //Ray���V�[���r���[�ɕ`��
        Debug.DrawRay(_origin, _front * _frontDistance, Color.red);
        #endregion
    }
}
