using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawn : MonoBehaviour
{
    [SerializeField]
    List<GameObject> _SpawnCharacter;

    // Start is called before the first frame update
    void Start()
    {
        for(int CharacterSpawnNumber = 0; CharacterSpawnNumber < _SpawnCharacter.Count; CharacterSpawnNumber++)
        {
            Instantiate(_SpawnCharacter[CharacterSpawnNumber], new Vector3(CharacterSpawnNumber + 1, 0, 0), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
