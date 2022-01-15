using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Config
{
	[CreateAssetMenu(fileName = "PlayerData", menuName = "PlayerData"),InlineEditor(Expanded = false)]
	public class PlayerData : ScriptableObject
	{
		[ShowInInspector, TabGroup("Movement")]
		public float moveSpeed;


		[ShowInInspector, TabGroup("Jumping")]
		public float jumpStrength;

		[ShowInInspector, TabGroup("Checks")]
		public float groundCheckRadius;
		[ShowInInspector, TabGroup("Checks")]
		public LayerMask groundCheckLayer;
		[ShowInInspector, TabGroup("Checks")]
		public float wallCheckRadius;
		[ShowInInspector, TabGroup("Checks")]
		public LayerMask wallCheckLayer;
	}
}