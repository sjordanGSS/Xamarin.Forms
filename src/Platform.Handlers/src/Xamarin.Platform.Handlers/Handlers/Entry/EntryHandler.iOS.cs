using CoreGraphics;
using UIKit;

namespace Xamarin.Platform.Handlers
{
	public partial class EntryHandler : AbstractViewHandler<IEntry, UITextField>
	{
		protected override UITextField CreateView()
		{
			var textField = new UITextField(CGRect.Empty)
			{
				BorderStyle = UITextBorderStyle.RoundedRect,
				ClipsToBounds = true
			};

			return textField;
		}
	}
}