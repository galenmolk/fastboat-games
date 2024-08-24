using UnityEngine;
using UnityEngine.Serialization;

namespace DC
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "DC/Weapon")]
    public class Weapon : ScriptableObject
    {
        [Min(1)] public int damage = 1;
        [Min(0.01f)] public float attackDuration = 0.1f;
        [Min(0.01f)] public float attackDelay = 2f;
    }
}
