using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace DC.Enemies
{
    public class PatrolPath : MonoBehaviour
    {
        [Range(1f, 10f)] public float screenSpaceSize = 5f;
        public Color color = Color.white;

        public List<PatrolPathNode> route { get; private set; }
        
        private void OnValidate()
        {
            foreach (Transform child in transform)
            {
                if (!child.GetComponent<PatrolPathNode>())
                {
                    child.gameObject.AddComponent<PatrolPathNode>().patrolPath = this;
                }
            }
        }

        public void OnDrawGizmosSelected()
        {
            for (int i = 0; i < transform.childCount - 1; i++)
            {
                Transform c1 = transform.GetChild(i);
                Transform c2 = transform.GetChild(i + 1);
                Handles.color = color;
                Handles.DrawDottedLine(c1.position, c2.position, screenSpaceSize);
            }
        }

        private void Awake()
        {
            route = new List<PatrolPathNode>();
            foreach (Transform child in transform)
            {
                PatrolPathNode node = child.GetComponent<PatrolPathNode>();
                if (!node)
                {
                    Debug.LogError("Missing PatrolPathNode");
                }
                else
                {
                    route.Add(node);
                }
            }
        }
    }
}
