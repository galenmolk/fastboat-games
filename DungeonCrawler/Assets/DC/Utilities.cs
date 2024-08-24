using UnityEngine;

namespace DC
{
    public static class Utilities
    {
        public static bool IsPlayer(this Collider2D collider2D)
        {
            return collider2D.gameObject.CompareTag("Player");
        }
    }
}
