// (c) Copyright HutongGames, LLC 2010-2013. All rights reserved.

using UnityEngine;
using System;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory(ActionCategory.GUIElement)]
	[Tooltip("Sets the Texture used by the GUITexture attached to a Game Object.")]
	#if UNITY_2017_2_OR_NEWER
	#pragma warning disable CS0618  
	[Obsolete("GUITexture is part of the legacy UI system and will be removed in a future release")]
	#endif
	public class SetGUITexture : ComponentAction<Image>
	{
		[RequiredField]
		[CheckForComponent(typeof(Image))]
		[Tooltip("The GameObject that owns the GUITexture.")]
        public FsmOwnerDefault gameObject;

        [Tooltip("Texture to apply.")]
		public FsmTexture texture;
		// public FsmSprite sprite;
		
		public override void Reset()
		{
			gameObject = null;
			texture = null;
		}

		public override void OnEnter()
		{
			// var go = Fsm.GetOwnerDefaultTarget(gameObject);
			// if (UpdateCache(go))
			// {
			// 	guiTexture.sprite = sprite.Value;
			// }
			
			var go = Fsm.GetOwnerDefaultTarget(gameObject);
			if (UpdateCache(go))
			{
				Texture2D tex = texture.Value as Texture2D;
				if (tex != null)
				{
					Sprite sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));
					guiTexture.sprite = sprite; // Tetap pakai guiTexture
				}
			}

			Finish();
		}
	}
}