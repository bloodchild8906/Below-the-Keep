using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Config
{
	[CreateAssetMenu(fileName = "PlayerData", menuName = "PlayerData"),InlineEditor(Expanded = false)]
	public class PlayerData : ScriptableObject
	{
		[TabGroup("Movement")]
		public int moveSpeed;
		[TabGroup("Jumping")]
		public int jumpStrength;

	}
}