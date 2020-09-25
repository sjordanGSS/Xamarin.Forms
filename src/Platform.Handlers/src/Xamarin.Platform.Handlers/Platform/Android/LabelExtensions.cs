using Android.Graphics;
using Android.Text;
using Android.Widget;
using Xamarin.Forms;

namespace Xamarin.Platform
{
	public static class LabelExtensions
	{
		static float LineSpacingExtraDefault = -1.0f;
		static float LineSpacingMultiplierDefault = -1.0f;

		public static void UpdateText(this TextView textView, ILabel label)
		{

		}

		public static void UpdateTextColor(this TextView textView, ILabel label)
		{

		}

		public static void UpdateFont(this TextView textView, ILabel label)
		{

		}

		public static void UpdateCharacterSpacing(this TextView textView, ILabel label)
		{
			if (NativeVersion.IsAtLeast(21))
			{
				textView.LetterSpacing = label.CharacterSpacing.ToEm();
			}
		}

		public static void UpdateLineHeight(this TextView textView, ILabel label)
		{
			if (LineSpacingExtraDefault < 0)
				LineSpacingExtraDefault = textView.LineSpacingExtra;

			if (LineSpacingMultiplierDefault < 0)
				LineSpacingMultiplierDefault = textView.LineSpacingMultiplier;

			if (label.LineHeight == -1)
				textView.SetLineSpacing(LineSpacingExtraDefault, LineSpacingMultiplierDefault);
			else if (textView.LineHeight >= 0)
				textView.SetLineSpacing(0, textView.LineHeight);
		}

		public static void UpdateHorizontalTextAlignment(this TextView textView, ILabel label)
		{
			textView.Gravity = label.HorizontalTextAlignment.ToHorizontalGravityFlags() | label.VerticalTextAlignment.ToVerticalGravityFlags();
		}

		public static void UpdateVerticalTextAlignment(this TextView textView, ILabel label)
		{
			textView.Gravity = label.HorizontalTextAlignment.ToHorizontalGravityFlags() | label.VerticalTextAlignment.ToVerticalGravityFlags();
		}

		public static void UpdateTextDecorations(this TextView textView, ILabel label)
		{
			var textDecorations = label.TextDecorations;

			if ((textDecorations & TextDecorations.Strikethrough) == 0)
				textView.PaintFlags &= ~PaintFlags.StrikeThruText;
			else
				textView.PaintFlags |= PaintFlags.StrikeThruText;

			if ((textDecorations & TextDecorations.Underline) == 0)
				textView.PaintFlags &= ~PaintFlags.UnderlineText;
			else
				textView.PaintFlags |= PaintFlags.UnderlineText;
		}

		public static void UpdateLineBreakMode(this TextView textView, ILabel label)
		{
			textView.SetLineBreakMode(label);
		}

		public static void UpdateMaxLines(this TextView textView, ILabel label)
		{
			var maxLines = label.MaxLines;

			if (maxLines == 0)
			{
				// MaxLines is not explicitly set, so just let it be whatever gets set by LineBreakMode
				textView.SetLineBreakMode(label);
				return;
			}

			textView.SetMaxLines(maxLines);
		}

		public static void UpdatePadding(this TextView textView, ILabel label)
		{
			var context = textView.Context;

			if (context == null)
				return;

			textView.SetPadding(
				(int)context.ToPixels(label.Padding.Left),
				(int)context.ToPixels(label.Padding.Top),
				(int)context.ToPixels(label.Padding.Right),
				(int)context.ToPixels(label.Padding.Bottom));
		}

		internal static void SetLineBreakMode(this TextView textView, ILabel label)
		{
			var lineBreakMode = label.LineBreakMode;

			int maxLines = int.MaxValue;
			bool singleLine = false;

			switch (lineBreakMode)
			{
				case LineBreakMode.NoWrap:
					maxLines = 1;
					textView.Ellipsize = null;
					break;
				case LineBreakMode.WordWrap:
					textView.Ellipsize = null;
					break;
				case LineBreakMode.CharacterWrap:
					textView.Ellipsize = null;
					break;
				case LineBreakMode.HeadTruncation:
					maxLines = 1;
					singleLine = true; // Workaround for bug in older Android API versions (https://bugzilla.xamarin.com/show_bug.cgi?id=49069)
					textView.Ellipsize = TextUtils.TruncateAt.Start;
					break;
				case LineBreakMode.TailTruncation:
					maxLines = 1;
					textView.Ellipsize = TextUtils.TruncateAt.End;
					break;
				case LineBreakMode.MiddleTruncation:
					maxLines = 1;
					singleLine = true; // Workaround for bug in older Android API versions (https://bugzilla.xamarin.com/show_bug.cgi?id=49069)
					textView.Ellipsize = TextUtils.TruncateAt.Middle;
					break;
			}

			textView.SetSingleLine(singleLine);
			textView.SetMaxLines(maxLines);
		}
	}
}