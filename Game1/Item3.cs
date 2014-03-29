//Payam Ghobadpour
using System;
using System.Collections.Generic;
using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Input;


namespace Game1
{
	public class Item3
	{
		private GraphicsContext graphics;
		private Collision col;
		public Sprite s;
		
		public enum Type
		{Machinegun};
		
		private Item3.Type type;
		public Item3.Type CurrentType
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
		
		public Item3 (GraphicsContext g, Collision c, Vector3 pos, Item3.Type i)
		{
			type = i;
			s = new Sprite(g, new Texture2D("/Application/Assets/weapon3.png", false));
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

