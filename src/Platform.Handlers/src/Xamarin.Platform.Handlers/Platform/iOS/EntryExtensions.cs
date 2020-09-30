using Foundation;
using UIKit;
using Xamarin.Forms;

namespace Xamarin.Platform
{
	public static class EntryExtensions
	{
		public static void UpdateText(this UITextField textField, IEntry entry)
		{
			SetText(textField, entry);
		}

		public static void UpdateColor(this UITextField textField, IEntry entry)
		{

		}

		public static void UpdateFont(this UITextField textField, IEntry entry)
		{

		}

		public static void UpdateTextTransform(this UITextField textField, IEntry entry)
		{
			SetText(textField, entry);
		}

		public static void UpdateCharacterSpacing(this UITextField textField, IEntry entry)
		{
			var textAttr = textField.AttributedText?.AddCharacterSpacing(entry.Text, entry.CharacterSpacing);

			if (textAttr != null)
				textField.AttributedText = textAttr;

			var placeHolder = textField.AttributedPlaceholder?.AddCharacterSpacing(entry.Placeholder, entry.CharacterSpacing);

			if (placeHolder != null)
				textField.UpdateAttributedPlaceholder(placeHolder);
		}

		public static void UpdatePlaceholder(this UITextField textField, IEntry entry)
		{

		}

		public static void UpdatePlaceholderColor(this UITextField textField, IEntry entry)
		{

		}

		public static void UpdateMaxLength(this UITextField textField, IEntry entry)
		{
			var currentControlText = textField.Text;

			if (currentControlText?.Length > entry.MaxLength)
				textField.Text = currentControlText.Substring(0, entry.MaxLength);
		}

		public static void UpdateIsReadOnly(this UITextField textField, IEntry entry)
		{

		}

		public static void UpdateKeyboard(this UITextField textField, IEntry entry)
		{

		}

		public static void UpdateIsSpellCheckEnabled(this UITextField textField, IEntry entry)
		{

		}

		public static void UpdateHorizontalTextAlignment(this UITextField textField, IEntry entry)
		{
			// TODO: Pass the EffectiveFlowDirection.
			textField.TextAlignment = entry.HorizontalTextAlignment.ToNativeTextAlignment(EffectiveFlowDirection.Explicit);
		}

		public static void UpdateVerticalTextAlignment(this UITextField textField, IEntry entry)
		{
			textField.VerticalAlignment = entry.VerticalTextAlignment.ToNativeTextAlignment();
		}

		public static void UpdateIsPassword(this UITextField textField, IEntry entry)
		{

		}

		public static void UpdateReturnType(this UITextField textField, IEntry entry)
		{

		}

		public static void UpdateCursorPosition(this UITextField textField, IEntry entry)
		{

		}

		public static void UpdateSelectionLength(this UITextField textField, IEntry entry)
		{

		}

		public static void UpdateIsTextPredictionEnabled(this UITextField textField, IEntry entry)
		{

		}

		public static void UpdateClearButtonVisibility(this UITextField textField, IEntry entry)
		{

		}

		internal static void SetText(this UITextField textField, IEntry entry)
		{
			var text = entry.UpdateTransformedText(entry.Text, entry.TextTransform);

			if (textField.Text != text)
				textField.Text = text;
		}

		internal static void UpdateAttributedPlaceholder(this UITextField textField, NSAttributedString nsAttributedString) =>
			textField.AttributedPlaceholder = nsAttributedString;
	}
}