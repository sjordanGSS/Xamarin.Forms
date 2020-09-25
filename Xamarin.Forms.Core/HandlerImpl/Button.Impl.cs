using System;
using Xamarin.Platform;

namespace Xamarin.Forms
{
	public partial class Button : IButton
	{
		public TextAlignment HorizontalTextAlignment { get; }

		public TextAlignment VerticalTextAlignment { get; }

		Color IText.TextColor
		{
			get => TextColor;
		}

		string IText.UpdateTransformedText(string source, TextTransform textTransform)
		{
			throw new NotImplementedException();
		}

		void IButton.Clicked()
		{
			throw new NotImplementedException();
		}

		void IButton.Pressed()
		{
			throw new NotImplementedException();
		}

		void IButton.Released()
		{
			throw new NotImplementedException();
		}
	}
}