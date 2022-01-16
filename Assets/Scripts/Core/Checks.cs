using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class Checks
    {
        private PlayerController _playerController;
        
        private int Facing => (int)_playerController.transform.localScale.x;
        
        #region Ground Check
        private Vector2 _groundCheck => _playerController.groundCheck.position;
        private LayerMask _groundCheckLayer => _playerController.playerData.groundCheckLayer;
        private float _groundCheckRadius => _playerController.playerData.groundCheckRadius; 
        #endregion
        
        #region Wall Check
		private Vector2 _wallCheck => _playerController.wallCheck.position;
        private LayerMask _wallCheckLayer => _playerController.playerData.wallCheckLayer;
        private float _wallCheckDistance => _playerController.playerData.wallCheckRadius;
        #endregion

        #region Ledge Check
        private Vector2 _ledgeCheck => _playerController.ledgeCheck.position;
        private LayerMask _ledgeCheckLayer => _playerController.playerData.ledgeCheckLayer;
        private float _ledgeCheckDistance => _playerController.playerData.ledgeCheckDistance;
        #endregion

        public Checks(PlayerController playerController) => _playerController = playerController;


        public bool IsGrounded => Physics2D.OverlapCircle(_groundCheck, _groundCheckRadius, _groundCheckLayer);
        public bool WallContact => Physics2D.Raycast(_wallCheck, Vector2.right * _playerController.Transform.localScale.x, _wallCheckDistance, _wallCheckLayer);
        public bool LedgeContact => Physics2D.Raycast(_ledgeCheck, Vector2.right*_playerController.Transform.localScale.x,_ledgeCheckDistance, _ledgeCheckLayer);

        public Vector2 GetCornerPos()
        {
            Vector2 retval=new Vector2();
            RaycastHit2D xhit = Physics2D.Raycast(_wallCheck, Vector2.right * Facing, _ledgeCheckDistance, _ledgeCheckLayer);
            retval.Set(xhit.distance * Facing, 0f);
            RaycastHit2D yHit= Physics2D.Raycast((Vector3)(_ledgeCheck + retval), Vector2.down, _ledgeCheck.y-_wallCheck.y, _ledgeCheckLayer);
            retval.Set(_wallCheck.x + (xhit.distance * Facing),_ledgeCheck.y-yHit.distance);
            return retval;
        }

    }
}