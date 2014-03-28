//Payam Ghobadpour
using System;
using System.Collections.Generic;
using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Input;
using System.Diagnostics;

namespace Game1
{
	public class Shotgun:Weapon
	{
		public Shotgun (Vector3 pos, GraphicsContext g, Collision c):base(g, c, new Texture2D("/Application/Assets/weapon2.png",false))
		{
			FireRate = 0.1f;//Bullets per Second
			ReloadRate = 2500;//Milliseconds
			Mag = 6;//Max rounds in magazine
			s.Position = pos;
		}
		
		public override void Shoot(){
			float spread = 1;
			for(int i=-2;i<3;i++){
				Bullet b = new Bullet(Graphics, Collisions, s.Rotation+(float)(Math.PI*i*spread/20), s.Position);
				Collisions.blist.Add(b);
			}
		}
		
		public override void Fire (GamePadData gamepaddata, long elapsed)
		{
			Recoil += elapsed;
			if((gamepaddata.ButtonsDown & GamePadButtons.Down)!=0 && Mag>Spent)
			{
				if (Recoil >= FireRate * 1000f) {
					Shoot ();
					Spent++;
					Recoil = 0;
				} 
				
				else{}
			}
			if (Mag<=Spent){
				Reload(elapsed);
			}
			else{}
		}
	}
	
}

