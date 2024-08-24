using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DC
{
    public class CoinSpawner : MonoBehaviour
    {
        public float size = 100f;

        public int count = 50;
        public GameObject coinPrefab;

        private readonly List<GameObject> coins = new();
    
        private void Start()
        {
            Spawn();
        }

        [ContextMenu("Spawn")]
        public void Spawn()
        {
            coins.Clear();
            for (int i = 0; i < count; i++)
            {
                var x = Random.Range(-size, size);
                var y = Random.Range(-size, size);
                var newCoin = Instantiate(coinPrefab, new Vector2(x, y), Quaternion.identity, transform);
                coins.Add(newCoin);
            }
        }

        [ContextMenu("Clear")]
        public void Clear()
        {
            foreach (var coin in coins)
            {
                Destroy(coin);
            }
            coins.Clear();
        }
    }
}
