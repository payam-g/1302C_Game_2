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
	public class Pistol:Weapon
	{
		public Pistol (Vector3 pos, GraphicsContext g, Collision c):base(g, c, new Texture2D("/Application/Assets/weapon1.png",false))
		{
			FireRate = 0;//Seconds per bullet
			ReloadRate = 1000;//Milliseconds
			Mag = 10;//Max rounds in magazine
			s.Position = pos;
		}
		
		public override void Shoot(){
			Bullet b = new Bullet(Graphics, Collisions, s.Rotation, s.Position);
			Collisions.blist.Add(b);
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

