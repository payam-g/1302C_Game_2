//Payam Ghobadpour
using System;
using System.Collections.Generic;
using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Input;

namespace Game1
{
	public class Bullet
	{
		private GraphicsContext graphics;

		public GraphicsContext Graphics {
			get {
				return graphics;	
			}
		}

		private Collision collisions;

		public Collision Collisions {
			get {
				return collisions;
			}
		}

		public Sprite s;
		private float velocity;

		public float Velocity {
			get {
				return velocity;	
			}
			set {
				velocity = value;
			}
		}

		private bool isAlive;

		public bool IsAlive {
			get {
				return isAlive;	
			}
			set {
				isAlive = value;
			}
		}
		
		public Bullet (GraphicsContext g, Collision c, float rot, Vector3 pos)
		{
			graphics = g;
			collisions = c;
			Texture2D t = new Texture2D("/Application/Assets/bullet.png",false);
			s = new Sprite (g, t);
			s.SetColor(new Vector4(1,1,1,1));
			isAlive = true;
			velocity = 10;
			s.Position = pos;
			s.Rotation = rot;
			s.Center = new Vector2(0.5f, 0.5f);
		}
		
		public void Update ()
		{
			s.Position.X += (float)Math.Sin (s.Rotation) * velocity;
			s.Position.Y -= (float)Math.Cos (s.Rotation) * velocity;
		}
		
		public void Render ()
		{
			s.Render ();
		}
		
	}
}
 
