using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class Movement
    {
        public Vector2 CurrentVelocity { get; set; }
        private Rigidbody2D _rigidbody2D => _playerController.Rigidbody;
        private Transform _transform => _playerController.Transform;
        private Vector2 _workspace;

        private readonly PlayerController _playerController;

        public Movement(PlayerController playerController)
        {
            _playerController = playerController;
        }

        public void SetVelocity_X(float x)
        {
            _workspace.Set(x, CurrentVelocity.y);
            _rigidbody2D.velocity = _workspace;
            CurrentVelocity = _workspace;
        }
        public void SetVelocity_Y(float y)
        {
            _workspace.Set(CurrentVelocity.x, y);
            _rigidbody2D.velocity = _workspace;
            CurrentVelocity = _workspace;
        }
        public void SetVelocity(float velocity, Vector2 angle, int direction)
        {
            angle.Normalize();
            _workspace.Set(angle.x * velocity * direction, angle.y * velocity);
            _rigidbody2D.velocity = _workspace;
            CurrentVelocity = _workspace;
        }
        public void SetVelocity(float velocity, Vector2 direction)
        {
            _workspace = direction * velocity;
            _rigidbody2D.velocity = _workspace;
            CurrentVelocity = _workspace;
        }
        public void SetVelocityZero()
        {
            _rigidbody2D.velocity = Vector2.zero;
            CurrentVelocity = Vector2.zero;
        }

        public void Flip(int inputX)
        {
            if (inputX == 0) return;
            var scale = _transform.localScale;
            scale.x = inputX;
            _transform.localScale = scale;
        }
    }
}