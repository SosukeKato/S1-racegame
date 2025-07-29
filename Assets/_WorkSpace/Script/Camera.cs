using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    PlayerMove _FindPlayer;
    // Start is called before the first frame update
    void Start()
    {
        _FindPlayer = FindAnyObjectByType<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = _FindPlayer.transform.position.x;
        float y = _FindPlayer.transform.position.y;
        transform.position = new Vector3(x, y, transform.position.z);
    }
}
