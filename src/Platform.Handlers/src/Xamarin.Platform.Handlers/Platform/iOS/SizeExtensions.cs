﻿using Xamarin.Forms;
using SizeF = CoreGraphics.CGSize;

namespace Xamarin.Platform
{
	public static class SizeExtensions
	{
		public static SizeF ToSizeF(this Size size)
		{
			return new SizeF((float)size.Width, (float)size.Height);
		}
	}
}
