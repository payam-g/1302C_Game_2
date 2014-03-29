//Payam Ghobadpour
using System;
using System.Collections.Generic;
using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Input;


namespace Game1
{
	public class Item
	{
		private GraphicsContext graphics;
		private Collision col;
		public Sprite s;
		
		public enum Type
		{Pistol, Shotgun, Machinegun};
		
		private Item.Type type;
		public Item.Type CurrentType
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
		
		public Item (GraphicsContext g, Collision c, Vector3 pos, Item.Type i, Vector4 uc)
		{
			type = i;
			s = new Sprite(g, new Texture2D("/Application/Assets/weaponbase.png", false));
			s.Position = pos;
			s.SetColor(uc);
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

