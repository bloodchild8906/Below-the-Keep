using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Config
{
	[CreateAssetMenu(fileName = "PlayerData", menuName = "Data/Player/PlayerData"),InlineEditor(Expanded = false)]
	public class PlayerData : ScriptableObject
	{
		[TabGroup("Movement")]
		public float moveSpeed;


		[TabGroup("Jumping")]
		public float jumpStrength;
		[TabGroup("Jumping")]
		public int maxJumps=2;
		[TabGroup("Jumping")]
		public float variableJumpModifier = 0.5f;
		[TabGroup("Jumping")]
        public float coyoteTime = 0.2f;

		[TabGroup("Wall Jump")]
		public float walljumpStrength=20;
		[TabGroup("Wall Jump")]
		public float WallJumpTime = 0.4f;
		[TabGroup("Wall Jump")]
		public Vector2 wallJumpAngle = new Vector2(1,2);


		[TabGroup("Checks")]
		public float groundCheckRadius;
		[TabGroup("Checks")]
		public LayerMask groundCheckLayer;
		[TabGroup("Checks")]
		public float wallCheckRadius;
		[TabGroup("Checks")]
		public LayerMask wallCheckLayer;

		[TabGroup("Wall Contact")]
		public float wallSlideVelocity = 3f;
		public float wallClimbSpeed = 1f;

		[TabGroup("Animations")]
		public PlayerAnimations animationParameters;

		public LayerMask ledgeCheckLayer;
		public float ledgeCheckDistance = 0.5f;
		public Vector2 startOffset;
		public Vector2 endOffset;
	}
}