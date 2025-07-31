using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawn : MonoBehaviour
{
    [SerializeField]
    List<EnemyAI> _spawnCharacter;

    [SerializeField]
    private Ranking _rankingSystem;

    void Start()
    {
        for(int CharacterSpawnNumber = 0; CharacterSpawnNumber < _spawnCharacter.Count; CharacterSpawnNumber++)
        {
             EnemyAI enemy = Instantiate(_spawnCharacter[CharacterSpawnNumber], new Vector3(CharacterSpawnNumber + 1, 0, 0), Quaternion.identity);
            _rankingSystem?.AddDriver(enemy);
        }
    }
}
