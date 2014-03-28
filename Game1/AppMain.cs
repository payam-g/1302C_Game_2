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
		private static List<Weapon> wlist;
		private static Weapon pistol;
		private static Weapon shotgun;
		private static Weapon machinegun;
		private static int wepsel;
		
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
			wlist = new List<Weapon>();
			pistol = new Pistol(p.s.Position + 300, graphics, col);
			shotgun = new Shotgun(p.s.Position + 200,graphics,col);
			machinegun = new Machinegun(p.s.Position + 100,graphics,col);
			wlist.Add(pistol);
			wlist.Add(shotgun);
			wlist.Add(machinegun);
			col.elist.Add (new Enemy1(graphics, col, new Vector3(rand.Next (0,960),rand.Next (0,544),0)));
		
		}

		public static void Update ()
		{
			// Query gamepad for current state
			var gamePadData = GamePad.GetData (0);
			p.Update(gamePadData, elapsed);
			if((gamePadData.ButtonsDown & GamePadButtons.Left)!=0){
				Console.WriteLine(wepsel);
				if(wepsel==0){
					wepsel=wlist.Count-1;
				}
					else{wepsel--;}
			}
			if((gamePadData.ButtonsDown & GamePadButtons.Right)!=0){
				Console.WriteLine(wepsel);
				if(wepsel==wlist.Count-1){
					wepsel=0;
				}
				else{wepsel++;}
			}
			
			wlist[wepsel].Update(p, elapsed, gamePadData);
			col.Update(elapsed);
		}

		public static void Render ()
		{
			// Clear the screen
			graphics.SetClearColor (1f, 1f, 1f, 1f);
			graphics.Clear ();
			
			wlist[wepsel].Render();
			p.Render();
			col.Render();
			
			
			// Present the screen
			graphics.SwapBuffers ();
		}
	}
}
