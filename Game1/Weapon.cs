//Payam Ghobadpour
using System;
using System.Collections.Generic;
using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Input;

namespace Game1
{
	public abstract class Weapon
	{  
		
		private bool pickedUp;
		
		public bool PickedUp{
			get {
				return pickedUp;
			}
			set{
				pickedUp = value;
			}
		}
		
		private Vector3 location;
		
		public Vector3 Location{
			get {
				return location;
			}
			set {
				location = value;
			}
		}
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
		
		private float fireRate;
		
		public float FireRate {
			get {
				return fireRate;
			}
			set {
				fireRate = value;
			}
		}
		
		private long recoil;
		
		public long Recoil {
			get {
				return recoil;
			}
			set {
				recoil = value;
			}
		}
		
		private int spent;

		public int Spent {
			get {
				return spent;
			}
			set{ spent = value;}
		}
		
		private int mag;
		
		public int Mag{
			get{
				return mag;
			}
			set{
				mag = value;
			}
		}
		
		private long reloadTime;
		
		public long ReloadTime {
			get {
				return reloadTime;
			}
			set {
				reloadTime = value;
			} 
		}
		
		private long reloadRate;
		
		public long ReloadRate {
			get {
				return reloadRate;
			}
			set {
				reloadRate = value;
			}
		}

		public Weapon (GraphicsContext g, Collision c, Texture2D t)
		{
			graphics = g;
			collisions = c;
			s = new Sprite (g, t);
			s.Center = new Vector2(0.5f, 0.8f);
			
		}
		
		public virtual void Fire (GamePadData gamepaddata, long elapsed)
		{
			recoil += elapsed;
			if((gamepaddata.Buttons & GamePadButtons.Down)!=0 && mag>=spent)
			{
				if (recoil >= fireRate * 1000f) {
					Shoot ();
					spent++;
					recoil = 0;
				} 
				
				else{}
			}
			else if (mag<=spent){
				Reload(elapsed);
			}
			else{}
		}

		public abstract void Shoot ();
		
		public virtual void Reload(long elapsed){
			Console.WriteLine("Reloading...");
			reloadTime+=elapsed;
			
			if(reloadTime>=reloadRate){
				spent = 0;
				reloadTime=0;
			}
			
			else{}
		}
		
		public virtual void Spawn()
		{
		Random rand1 = new Random();
		Vector3 spawn = new Vector3 (rand1.Next(60, 901), rand1.Next (44,500), 0);
			
		}
		
		public virtual void Update (Player player, long elapsed, GamePadData gamepaddata)
		{
			s.Position = player.s.Position;
			s.Rotation = player.s.Rotation;
			Fire (gamepaddata, elapsed);	
		}
		
		public virtual void Render ()
		{
			s.Render ();
		}
		
	}
}
 
