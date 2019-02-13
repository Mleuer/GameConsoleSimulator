using SFML.Graphics;
using SFML.Window;
using SFML.System;

using GameConsoleSimulator.Utility;
using GameConsoleSimulator.Config;
using GameConsoleSimulator.Util;


namespace GameConsoleSimulator.View
{
	public class Window : RenderWindow
	{
		protected static readonly VideoMode defaultVideoMode;

		protected static readonly Font defaultFont;

		protected static VideoMode createDefaultVideoMode()
		{
			Vec2<uint> baseWindowSize = Configuration.MainWindowSize;
			
			float dpiScale = DisplayData.getDisplayScalingFactor();
			
			Vec2 <uint> scaledWindowSize = new Vec2<uint>((uint)(baseWindowSize.X * dpiScale),
				(uint)(baseWindowSize.Y * dpiScale));
			
			return new VideoMode(scaledWindowSize.X, scaledWindowSize.Y);
		}

		static Window()
		{
			defaultVideoMode = createDefaultVideoMode();
			defaultFont = new Font(Configuration.MainFontFilePath);
		}

		public Text Text { get; private set; }

		public TrueColor BackgroundColor { get; private set;}

		public Window(string title, TrueColor backgroundColor = new TrueColor()) :
			base(defaultVideoMode, title, Styles.Default, new ContextSettings())
		{
			Text = new Text
			{
				Font = defaultFont,
				CharacterSize = Configuration.DefaultTextCharacterSize
			};
			this.BackgroundColor = backgroundColor;
			this.SetVisible(true);
		}

		public void DisplayText(string chars, TrueColor color, Vec2<uint> where) 
		{
			Text.DisplayedString = chars;
			Text.FillColor = color.ConvertToSFMLColorType();

			var textSize = Text.GetLocalBounds();

			Vec2<uint> middle = new Vec2<uint>((uint)(textSize.Width / 2), (uint)(textSize.Height / 2));

			Vec2<uint> adjustedPos = where - middle;

			Text.Position = new Vector2f(adjustedPos.X, adjustedPos.Y);

			Draw(Text);
		}
	}

}