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
	public class Machinegun:Weapon
	{
		public Machinegun (Vector3 pos, GraphicsContext g, Collision c):base(g, c, new Texture2D("/Application/Assets/weapon3.png",false))
		{
			FireRate = 0.1f;//Bullets per Second
			ReloadRate = 4000;//Milliseconds
			Mag = 50;//Max rounds in magazine
			s.Position = pos;
		}
		
		public override void Shoot(){
			Bullet b = new Bullet(Graphics, Collisions, s.Rotation, s.Position);
			Collisions.blist.Add(b);
		}

	}
	
}

