//Payam Ghobadpour
using System;
using System.Collections.Generic;
using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Input;

namespace Game1
{
	public class Enemy3:Enemy
	{
		private Vector3 random;
		
		public Enemy3 (GraphicsContext g, Collision c, Vector3 pos):base (g, c, new Texture2D("/Application/Assets/player.png",false), pos)
		{
			Duration = 50;
			Size = 40;
			Frames = 8;
			MovementSpeed = 2;
			s.SetColor(new Vector4(0f, 0f, 1f, 1f));
			random = new Vector3(rand.Next(30, 930), rand.Next (30, 514),0);

		}
		
		public override void Attack(Player p)
		{
			
		}
		
		public override void Update(Vector3 playerpos, long elapsed)
		{
			Time += elapsed;
			if(Collision.Colliding(this.s.Position,random)){
			random = new Vector3(rand.Next(30, 930), rand.Next (30, 514),0);
			}
			Vector3 tempPos = this.s.Position;
			float deltaX = tempPos.X - random.X;
			float deltaY = tempPos.Y - random.Y;
			
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

