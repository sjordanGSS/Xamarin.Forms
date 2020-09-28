#if __IOS__
using RectangleF = CoreGraphics.CGRect;
using CustomNativeView = Xamarin.Platform.NativeLabel;
using NativeView = UIKit.UILabel;
#elif __MACOS__
using NativeView = AppKit.NSTextField;
#elif MONOANDROID
using NativeView = Android.Widget.TextView;
#elif NETCOREAPP
using NativeView = System.Windows.Controls.TextBlock;
#elif NETSTANDARD
using NativeView = System.Object;
# endif

namespace Xamarin.Platform.Handlers
{
	public partial class LabelHandler : AbstractViewHandler<ILabel, NativeView>
	{
		public static PropertyMapper<ILabel, LabelHandler> LabelMapper = new PropertyMapper<ILabel, LabelHandler>(ViewHandler.ViewMapper)
		{
			[nameof(IText.Text)] = MapText,
			[nameof(IText.TextColor)] = MapTextColor,
			[nameof(IText.Font)] = MapFont,
			[nameof(IText.TextTransform)] = MapTextTransform,
			[nameof(IText.CharacterSpacing)] = MapCharacterSpacing,
			[nameof(ILabel.LineHeight)] = MapLineHeight,
			[nameof(ILabel.FontSize)] = MapFontSize,
			[nameof(ILabel.FontAttributes)] = MapFontAttributes,
			[nameof(ILabel.HorizontalTextAlignment)] = MapHorizontalTextAlignment,
			[nameof(ILabel.VerticalTextAlignment)] = MapVerticalTextAlignment,
			[nameof(ILabel.TextDecorations)] = MapTextDecorations,
			[nameof(ILabel.LineBreakMode)] = MapLineBreakMode,
			[nameof(ILabel.MaxLines)] = MapMaxLines,
			[nameof(IPadding.Padding)] = MapPadding
		};

		public static void MapText(LabelHandler handler, ILabel label) => handler.TypedNativeView?.UpdateText(label);

		public static void MapTextColor(LabelHandler handler, ILabel label) => handler.TypedNativeView?.UpdateTextColor(label);

		public static void MapFont(LabelHandler handler, ILabel label) => handler.TypedNativeView?.UpdateFont(label);

		public static void MapTextTransform(LabelHandler handler, ILabel label) => handler.TypedNativeView?.UpdateText(label);

		public static void MapCharacterSpacing(LabelHandler handler, ILabel label) => handler.TypedNativeView?.UpdateCharacterSpacing(label);

		public static void MapLineHeight(LabelHandler handler, ILabel label) => handler.TypedNativeView?.UpdateLineHeight(label);

		public static void MapFontSize(LabelHandler handler, ILabel label) => handler.TypedNativeView?.UpdateFont(label);

		public static void MapFontAttributes(LabelHandler handler, ILabel label) => handler.TypedNativeView?.UpdateFont(label);

		public static void MapHorizontalTextAlignment(LabelHandler handler, ILabel label) => handler.TypedNativeView?.UpdateHorizontalTextAlignment(label);

		public static void MapVerticalTextAlignment(LabelHandler handler, ILabel label) => handler.TypedNativeView?.UpdateVerticalTextAlignment(label);

		public static void MapTextDecorations(LabelHandler handler, ILabel label) => handler.TypedNativeView?.UpdateTextDecorations(label);

		public static void MapLineBreakMode(LabelHandler handler, ILabel label) => handler.TypedNativeView?.UpdateLineBreakMode(label);

		public static void MapMaxLines(LabelHandler handler, ILabel label) => handler.TypedNativeView?.UpdateMaxLines(label);

		public static void MapPadding(LabelHandler handler, ILabel label) => handler.TypedNativeView?.UpdatePadding(label);

#if MONOANDROID
		protected override NativeView CreateView() => new NativeView(this.Context);
#elif __IOS__
		protected override NativeView CreateView() => (VirtualView == null && VirtualView!.Padding.IsEmpty) ? new NativeView(RectangleF.Empty) : new CustomNativeView(RectangleF.Empty);
#else
		protected override NativeView CreateView() => new NativeView();
#endif

		public LabelHandler() : base(LabelMapper)
		{

		}

		public LabelHandler(PropertyMapper mapper) : base(mapper ?? LabelMapper)
		{

		}
	}
}