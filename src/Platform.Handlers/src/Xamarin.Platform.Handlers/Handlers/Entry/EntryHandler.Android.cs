using Android.Widget;

namespace Xamarin.Platform.Handlers
{
	public partial class EntryHandler : AbstractViewHandler<IEntry, EditText>
	{
		protected override EditText CreateView()
		{
			var editText = new EditText(Context);

			return editText;
		}
	}
}