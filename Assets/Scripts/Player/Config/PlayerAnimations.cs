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
	}
}