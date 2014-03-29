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
	public class AppMain
	{
		private static GraphicsContext graphics;
		private static long start;
		private static long elapsed;
		private static Stopwatch clock;
		private static Collision col;
		private static Player p;
		private static Weapon pistol;
		private static Weapon shotgun;
		private static Weapon machinegun;
		
		public static void Main (string[] args)
		{
			Initialize ();

			while (true) {
				start = clock.ElapsedMilliseconds;
				SystemEvents.CheckEvents ();
				Update ();
				Render ();
				elapsed = clock.ElapsedMilliseconds-start;
			}
		}

		public static void Initialize ()
		{
			// Set up the graphics system
			Random rand = new Random();
			graphics = new GraphicsContext ();
			clock = new Stopwatch();
			clock.Start();
			col = new Collision(graphics);
			p = new Player(graphics, col);
			col.p = p;
			col.elist.Add (new Enemy1(graphics, col, new Vector3(rand.Next (0,960),rand.Next (0,544),0)));
			col.ilist.Add(new Item(graphics, col, new Vector3(rand.Next(60,901), rand.Next(44,501), 0), Item.Type.Pistol, new Vector4(1,.5f,0,1)));
			col.ilist.Add(new Item(graphics, col, new Vector3(rand.Next(60,901), rand.Next(44,501), 0), Item.Type.Shotgun, new Vector4(0,1,0,1)));
			col.ilist.Add(new Item(graphics, col, new Vector3(rand.Next(60,901), rand.Next(44,501), 0), Item.Type.Machinegun,new Vector4(0,0,1,1)));


		}

		public static void Update ()
		{
			// Query gamepad for current state
			var gamePadData = GamePad.GetData (0);			
			col.Update(elapsed);
						p.Update(gamePadData, elapsed);
		}

		public static void Render ()
		{
			// Clear the screen
			graphics.SetClearColor (1f, 1f, 1f, 1f);
			graphics.Clear ();
			

			p.Render();
			col.Render();
			
			
			// Present the screen
			graphics.SwapBuffers ();
		}
	}
}
