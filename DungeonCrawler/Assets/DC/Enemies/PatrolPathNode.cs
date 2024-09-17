using System;
using UnityEngine;

namespace DC.Enemies
{
     public class PatrolPathNode : MonoBehaviour
     {
          public Vector2 position => transform.position;
          public PatrolPath patrolPath;
          public float pauseDuration = 1f;
          
          private void Awake()
          {
               gameObject.SetActive(false);
          }

          private void OnDrawGizmosSelected()
          {
               if (patrolPath)
               {
                    patrolPath.OnDrawGizmosSelected();
               }
          }
     }
}
