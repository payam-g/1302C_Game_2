//Payam Ghobadpour
using System;
using System.Collections.Generic;
using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Input;

namespace Game1
{
	public class Enemy1:Enemy
	{
		public Enemy1 (GraphicsContext g, Collision c, Vector3 pos):base (g, c, new Texture2D("/Application/Assets/player.png",false), pos)
		{
			Duration = 50;
			Size = 40;
			Frames = 8;
			MovementSpeed = 2;
			s.SetColor(new Vector4(1f, 0f, 0f, 1f));

		}
		
		public override void Attack(Player p)
		{
			
		}
		
		public override void Update(Vector3 playerpos, long elapsed)
		{
			Time += elapsed;
			
			Vector3 tempPos = this.s.Position;
			float deltaX = tempPos.X - playerpos.X;
			float deltaY = tempPos.Y - playerpos.Y;
			
			float rotation = (float)Math.Atan2(deltaY, deltaX);
			
			this.s.Rotation = rotation;
			
			Vector3 velocity = new Vector3((float)Math.Cos (rotation) * -MovementSpeed, (float)Math.Sin (rotation) * -MovementSpeed, 0);
			
			this.s.Position += velocity;
			
			
			
			
			if(Time>=Duration){
				if(Active<(Frames-1)){
					Active++;
				}
				else{
					Active=0;
				}
				Time=0;
			}
			else{}
		}
		
		
	}
}

