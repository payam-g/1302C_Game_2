//Payam Ghobadpour
using System;
using System.Collections.Generic;
using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Input;

namespace Game1
{
	public class Player
	{
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
		private int health;
		public int Health
		{
			get
			{
				return health;
			}
			set
			{
				health = value;
			}
		}
		private bool isAlive;
		public bool IsAlive
		{
			get 
			{
				return isAlive;	
			}
			set
			{
				isAlive=value;
			}
		}
		
		private float rotSpeed;
		
		private long duration;
		private float size;
		private int frames;
		private int active;
		private long time;
		private List<Weapon> wlist;
		private int wepsel;
		
		public List<Weapon> WList
		{
			get { return wlist;}	
			set { wlist = value;}
		}
		
		public Player (GraphicsContext g, Collision c)
		{
			graphics = g;
			collisions = c;
			Texture2D tex = new Texture2D("/Application/Assets/player.png", false);
			s = new Sprite(g,tex);
			isAlive = true;
			movementSpeed = 5;
			rotSpeed = .05f;
			s.Position= new Vector3(25,25,0);
			duration = 50;
			size = 40;
			frames = 8;
			s.Width = size;
			s.Center= new Vector2(0.5f, 0.5f);
			s.Rotation = (float)Math.PI/2f;
			wlist = new List<Weapon>();
			health = 5;
		}
		
		public void Update(GamePadData gamepaddata, long elapsed)
		{
			time += elapsed;
			
			if(wlist.Count > 0)
			{
				if((gamepaddata.ButtonsDown & GamePadButtons.Left)!=0){
					Console.WriteLine(wepsel);
					if(wepsel==0){
						wepsel=wlist.Count-1;
					}
						else{wepsel--;}
				}
				if((gamepaddata.ButtonsDown & GamePadButtons.Right)!=0){
					Console.WriteLine(wepsel);
					if(wepsel==wlist.Count-1){
						wepsel=0;
					}
					else{wepsel++;}
				}
				wlist[wepsel].Update(this, elapsed, gamepaddata);
			}
			if((gamepaddata.Buttons & GamePadButtons.Triangle)!=0){
				s.Position.X += (float)Math.Sin (s.Rotation) * movementSpeed;
				s.Position.Y -= (float)Math.Cos (s.Rotation) * movementSpeed;
			}
			if((gamepaddata.Buttons & GamePadButtons.Cross)!=0){
				s.Position.X -= (float)Math.Sin (s.Rotation) * movementSpeed;
				s.Position.Y += (float)Math.Cos (s.Rotation) * movementSpeed;
			}
			if((gamepaddata.Buttons & GamePadButtons.Square)!=0){
				s.Rotation-=rotSpeed;
			}
			if((gamepaddata.Buttons & GamePadButtons.Circle)!=0){
				s.Rotation+=rotSpeed;
			}
			if((gamepaddata.Buttons & GamePadButtons.L)!=0){
				s.Position.X -= (float)Math.Sin (s.Rotation+(float)Math.PI/2f) * movementSpeed;
				s.Position.Y += (float)Math.Cos (s.Rotation+(float)Math.PI/2f) * movementSpeed;
			}
			if((gamepaddata.Buttons & GamePadButtons.R)!=0){
				s.Position.X += (float)Math.Sin (s.Rotation+(float)Math.PI/2f) * movementSpeed;
				s.Position.Y -= (float)Math.Cos (s.Rotation+(float)Math.PI/2f) * movementSpeed;
			}
			
			if(time>=duration){
				if(active<(frames-1)){
					active++;
				}
				else{
					active=0;
				}
				time=0;
			}
			else{}
			
		}
		
		public void Render()
		{
			if(wlist.Count > 0)
				wlist[wepsel].Render();
			s.SetTextureCoord(size*active,0,(size*(active+1)), size);
			s.Render();
		}
		
	}
}
 
