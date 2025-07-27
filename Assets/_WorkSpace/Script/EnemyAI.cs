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
        //y���̈ړ�����
        _rb.velocity = new Vector2(_rb.velocity.x, _directinalSpeed * _speedMagnification);

#region Raycast���g���ď����̕�������
        //Ray�̔��ˏꏊ
        Vector2 origin = transform.position;
        //�E��Ray�𔭎�
        Vector2 direction = Vector2.right;
        //Ray�̒���
        float distance = 5f;
        //Ray���I�u�W�F�N�g�ɏՓ˂����ꍇ�̏���
        if (Physics2D.Raycast(origin, direction, distance).collider)
        {
            _speedMagnification = 0.5f;
        }
        //Ray���V�[���r���[�ɕ`��
        Debug.DrawRay(origin, direction * distance, Color.red);
#endregion
    }
}
