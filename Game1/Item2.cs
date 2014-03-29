//Payam Ghobadpour
using System;
using System.Collections.Generic;
using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Input;


namespace Game1
{
	public class Item2
	{
		private GraphicsContext graphics;
		private Collision col;
		public Sprite s;
		
		public enum Type
		{Shotgun};
		
		private Item2.Type type;
		public Item2.Type CurrentType
		{
			get { return type;}	
		}
		
		private bool isAlive;
		public bool IsAlive
		{
			get { return isAlive;}
			set { isAlive = value;}
		}
		
		public GraphicsContext Graphics
		{
			get { return graphics;}
		}
		
		public Collision Col
		{
			get { return Col;}
		}
		
		public Item2 (GraphicsContext g, Collision c, Vector3 pos, Item2.Type i)
		{
			type = i;
			s = new Sprite(g, new Texture2D("/Application/Assets/weapon2.png", false));
			s.Position = pos;
			graphics = g;
			col = c;
			IsAlive = true;
		}
		
		public void Render()
		{
			s.Render();	
		}
	}
}

