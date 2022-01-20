using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Config
{
	[CreateAssetMenu(fileName = "PlayerAnimations", menuName = "Data/Player/PlayerAnimations"), InlineEditor]
	public class PlayerAnimations : ScriptableObject
	{
		public string idle="Idle";
		public string move="Run";
		public string land="Land";
		public string jump="Airborne";
		public string airborne="Airborne";
        public string yVelocity="Y_Velocity";
        public string wallSlide="WallSlide";
        public string wallClimb="WallClimb";
        public string wallGrab="WallGrab";
		public string ledgeClimbState="LedgeClimbState";
		public string ledgeClimb = "LedgeClimb";
        public string dash = "Airborne";
	}
}