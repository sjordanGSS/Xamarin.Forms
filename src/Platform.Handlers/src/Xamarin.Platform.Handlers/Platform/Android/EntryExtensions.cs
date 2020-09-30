using System.Collections.Generic;
using Android.Text;
using Android.Widget;

namespace Xamarin.Platform
{
	public static class EntryExtensions
	{
		public static void UpdateText(this EditText editText, IEntry entry)
		{
			SetText(editText, entry);
		}

		public static void UpdateColor(this EditText editText, IEntry entry)
		{

		}

		public static void UpdateFont(this EditText editText, IEntry entry)
		{

		}

		public static void UpdateTextTransform(this EditText editText, IEntry entry)
		{
			SetText(editText, entry);
		}

		public static void UpdateCharacterSpacing(this EditText editText, IEntry entry)
		{
			if (NativeVersion.IsAtLeast(21))
			{
				editText.LetterSpacing = entry.CharacterSpacing.ToEm();
			}
		}

		public static void UpdatePlaceholder(this EditText editText, IEntry entry)
		{
			editText.Hint = entry.Placeholder;

			if (editText.IsFocused)
			{
				// TODO: Port KeyboardManager to Xamarin.Platform.
				//TypedNativeView.ShowKeyboard();
			}
		}

		public static void UpdatePlaceholderColor(this EditText editText, IEntry entry)
		{

		}

		public static void UpdateMaxLength(this EditText editText, IEntry entry)
		{
			var currentFilters = new List<IInputFilter>(editText?.GetFilters() ?? new IInputFilter[0]);

			for (var i = 0; i < currentFilters.Count; i++)
			{
				if (currentFilters[i] is InputFilterLengthFilter)
				{
					currentFilters.RemoveAt(i);
					break;
				}
			}

			currentFilters.Add(new InputFilterLengthFilter(entry.MaxLength));

			editText?.SetFilters(currentFilters.ToArray());

			var currentControlText = editText?.Text;

			if (editText != null && currentControlText != null && currentControlText.Length > entry.MaxLength)
				editText.Text = currentControlText.Substring(0, entry.MaxLength);
		}

		public static void UpdateIsReadOnly(this EditText editText, IEntry entry)
		{
			bool isReadOnly = !entry.IsReadOnly;
			editText.FocusableInTouchMode = isReadOnly;
			editText.Focusable = isReadOnly;
		}

		public static void UpdateKeyboard(this EditText editText, IEntry entry)
		{

		}

		public static void UpdateIsSpellCheckEnabled(this EditText editText, IEntry entry)
		{

		}

		public static void UpdateHorizontalTextAlignment(this EditText editText, IEntry entry)
		{
			editText.UpdateTextAlignment(entry.HorizontalTextAlignment, entry.VerticalTextAlignment);
		}

		public static void UpdateVerticalTextAlignment(this EditText editText, IEntry entry)
		{
			editText.UpdateTextAlignment(entry.HorizontalTextAlignment, entry.VerticalTextAlignment);
		}

		public static void UpdateIsPassword(this EditText editText, IEntry entry)
		{

		}

		public static void UpdateReturnType(this EditText editText, IEntry entry)
		{

		}

		public static void UpdateCursorPosition(this EditText editText, IEntry entry)
		{

		}

		public static void UpdateSelectionLength(this EditText editText, IEntry entry)
		{

		}

		public static void UpdateIsTextPredictionEnabled(this EditText editText, IEntry entry)
		{

		}

		public static void UpdateClearButtonVisibility(this EditText editText, IEntry entry)
		{

		}

		internal static void SetText(this EditText editText, IEntry entry)
		{
			var text = entry.UpdateTransformedText(entry.Text, entry.TextTransform);

			if (editText.Text == text)
				return;

			editText.Text = text;

			if (editText.IsFocused)
			{
				editText.SetSelection(text.Length);
				// TODO: Port KeyboardManager to Xamarin.Platform.
				//editText.ShowKeyboard();
			}
		}
	}
}