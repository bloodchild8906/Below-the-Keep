using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class Checks
    {
        private PlayerController _playerController;
        
        #region Ground Check
        private Vector2 _groundCheck => _playerController.groundCheck.position;
        private LayerMask _groundCheckLayer => _playerController.playerData.groundCheckLayer;
        private float _groundCheckRadius => _playerController.playerData.groundCheckRadius; 
        #endregion
        
        #region Wall Check
		private Vector2 _wallCheck => _playerController.wallCheck.position;
        private LayerMask _wallCheckLayer => _playerController.playerData.wallCheckLayer;
        private float _wallCheckRadius => _playerController.playerData.groundCheckLayer;
        #endregion
        
        public Checks(PlayerController playerController) => _playerController = playerController;


        public bool IsGrounded => Physics2D.OverlapCircle(_groundCheck, _groundCheckRadius, _groundCheckLayer);
        public bool WallContact => Physics2D.OverlapCircle(_wallCheck, _wallCheckRadius, _wallCheckLayer);

    }
}