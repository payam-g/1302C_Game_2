//Payam Ghobadpour
using System;
using System.Collections.Generic;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Input;

namespace Game1
{
	public class Collision
	{
		public List<Bullet> blist;
		public List<Enemy> elist;
		public List<Item> ilist;
		public Player p;
		public static Random rand = new Random();
		private GraphicsContext graphics;
		
		public Collision (GraphicsContext g)
		{
			blist = new List<Bullet>();
			elist = new List<Enemy>();
			ilist = new List<Item>();
			graphics = g;
		}
		
		public static bool OnScreen(Vector3 p1, GraphicsContext g)
		{
			if(p1.X > g.Screen.Rectangle.Width)
				return false;
			if(p1.X < 0)
				return false;
			if(p1.Y > g.Screen.Rectangle.Height)
				return false;
			if(p1.Y < 0)
				return false;
			return true;
		}
		
		public static bool Colliding(Sprite s1, Sprite s2)
		{	
			if(Vector3.DistanceSquared(s1.Position, s2.Position) < Math.Pow((s1.Height + s2.Height)/2, 2))
			{
				return true;
			}
			return false;
			   
		}
		public static bool Colliding(Vector3 v1, Vector3 v2)
		{	
			if(Vector3.DistanceSquared(v1, v2) < (float)Math.Pow((v1.X + v2.X)/2, 2))
			{
				return true;
			}
			return false;
			   
		}
		
		public void SpawnEnemy(){
			int random = rand.Next(0,3);
			Vector3 randompos = new Vector3(rand.Next(30, 930), rand.Next (30, 514),0);
			switch(random){
			case 0:
				elist.Add(new Enemy1(graphics, this, randompos));
				break;
			case 1:
				elist.Add(new Enemy2(graphics, this, randompos));
				break;
			case 2:
				elist.Add(new Enemy3(graphics, this, randompos));
				break;
			}

		}
		
		public void Update(long elapsed){
			foreach(Bullet b in blist){
				b.Update();
				if(!OnScreen(b.s.Position, b.Graphics))
					b.IsAlive = false;
			}
			
			foreach(Item i in ilist)
			{
				if(Colliding(p.s, i.s))
				{
				    i.IsAlive = false;
					switch(i.CurrentType)
					{
					case Item.Type.Pistol:
						p.WList.Add (new Pistol(p.s.Position, graphics, this));
						break;
					case Item.Type.Machinegun:
						p.WList.Add (new Machinegun(p.s.Position, graphics, this));
						break;
					case Item.Type.Shotgun:
						p.WList.Add (new Shotgun(p.s.Position, graphics, this));
						break;
					}
					break;
				}
			}
			
			foreach(Enemy e in elist){
				e.Update(p.s.Position, elapsed);
				if(Colliding(e.s, p.s))
				{
					e.Attack(p);
				}
			}
			
			foreach(Bullet b in blist)
			{
				foreach(Enemy e in elist)
				{
					if(e.IsAlive && Colliding(b.s, e.s))	
					{
						b.IsAlive = false;
						e.IsAlive = false;
						SpawnEnemy();
						break;
					}
				}
			}
			
			for(int b = blist.Count - 1; b >= 0; b--)
			{
				if(!blist[b].IsAlive)
					blist.RemoveAt(b);
			}
			
			for(int e = elist.Count - 1; e >= 0; e--)
			{
				if(!elist[e].IsAlive)
					elist.RemoveAt(e);
			}
			
			for(int i = ilist.Count - 1; i >= 0; i--)
			{
				if(!ilist[i].IsAlive)
					ilist.RemoveAt(i);
			}
		}
		
		
		public void Render(){
			foreach(Bullet b in blist){
				b.Render();
			}
			
			foreach(Enemy e in elist){
				e.Render();
			}
			
			foreach(Item i in ilist)
				i.Render();
		}
	}
}

