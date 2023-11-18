using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Enemy/Enemy Data", order = 0)]
public class EnemyData : ScriptableObject
{
    public int hp;
    public int str;

}