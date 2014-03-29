//Payam Ghobadpour
using System;
using System.Collections.Generic;
using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Input;


namespace Game1
{
	public class PistolItem : Item
	{
		public PistolItem (GraphicsContext g, Collision c, Vector3 pos) : base(g, c, pos, new Texture2D("/Application/Assets/weapon1.png", false))
		{
			
		}
		
		public override void Collision(Player p)
		{
//			if(p.WList.Count > 0)
//			{
//				//Check if player already has weapon
//				bool gun = false;
//				foreach(Weapon w in p.WList)
//				{
//					//If the current weapon is not a pistol, it will return null.
//					Console.WriteLine(w.GetType());
//	//				if(pstl != null)
//	//					gun = true;
//				}
//				
//				//If he/she doesn't, gives them the weapon
//				if(!gun)
//				{
//					p.WList.Add(new Pistol(p.s.Position, Graphics, Col));
//					IsAlive = false;
//				}
//				
//			}
//			else
//				p.WList.Add(new Pistol(p.s.Position, Graphics, Col));
			p.WList.Add(new Pistol(p.s.Position, Graphics, Col));
			IsAlive = false;
		}
	}
}

