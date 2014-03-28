//Payam Ghobadpour
using System;
using System.Collections.Generic;
using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Input;

namespace Game1
{
	public abstract class Enemy
	{
		public static Random rand = new Random();
		private GraphicsContext graphics;
		public GraphicsContext Graphics
		{
			get 
			{
				return graphics;	
			}
		}
		private Collision collisions;
		public Collision Collisions
		{
			get
			{
				return collisions;
			}
		}
		public Sprite s;
		
		private float movementSpeed;
		public float MovementSpeed
		{
			get 
			{
				return movementSpeed;	
			}
			set
			{
				movementSpeed=value;
			}
		}
		private bool isAlive;
		public bool IsAlive
		{
			get 
			{
				return isAlive;	
			}
			set {
				isAlive = value;
			}
		}
		
		private long duration;
		public long Duration{
			get{
				return duration;
			}
			set{
				duration = value;
			}
		}
		private float size;
		public float Size{
			get{
				return size;
			}
			set{
				size = value;
			}
		}
		private int frames;
		public int Frames{
			get{
				return frames;
			}
			set{
				frames = value;
			}
		}
		private int active;
		public int Active{
			get{
				return active;
			}
			set{
				active = value;
			}
		}
		private long time;
		public long Time{
			get{
				return time;
			}
			set{
				time = value;
			}
		}
		
		public Enemy (GraphicsContext g, Collision c, Texture2D t, Vector3 pos)
		{
			graphics = g;
			collisions = c;
			s = new Sprite(g,t);
			s.Center = new Vector2(0.5f, 0.5f);
			s.Position = pos;
			s.Width = 40;
			isAlive = true;
			
		}
		
		public abstract void Attack(Player p);
		
		public abstract void Update(Vector3 playerpos, long elapsed);
		
		public virtual void Render()
		{
			s.SetTextureCoord(size*active,0,(size*(active+1)), size);
			s.Render();
		}
		
	}
}
 
