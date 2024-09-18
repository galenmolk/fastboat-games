using System;
using UnityEngine;

namespace DC.FSM
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class UnitStateMachine : FiniteStateMachine
    {
        public float slowingDistance = 0.5f;
        public float acceleration = 15;
        public float deceleration = 5;
        public float speed = 2.5f;
        public float stoppingSpeedThreshold = 0.1f;
        
        private Rigidbody2D rigidbody2D;
        
        protected Transform cachedTransform
        {
            get
            {
                transformInternal ??= transform;
                return transformInternal;
            }
        }
        private Transform transformInternal;

        private void Awake()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public void SetPosition(Vector2 position)
        {
            cachedTransform.position = position;
        }

        public void SetVelocity(Vector2 velocity)
        {
            rigidbody2D.velocity = velocity;
        }

        public Vector2 position => cachedTransform.position;
    }
}
