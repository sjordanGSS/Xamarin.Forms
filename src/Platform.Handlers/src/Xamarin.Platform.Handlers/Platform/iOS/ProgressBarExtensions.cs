﻿using UIKit;
using Xamarin.Forms;

namespace Xamarin.Platform
{
	public static class ProgressBarExtensions
	{
		public static void UpdateProgress(this UIProgressView nativeProgressBar, IProgress progress)
		{
			nativeProgressBar.Progress = (float)progress.Progress;
		}

		public static void UpdateProgressColor(this UIProgressView nativeProgressBar, IProgress progress)
		{
			nativeProgressBar.ProgressTintColor = progress.ProgressColor == Color.Default ? null : progress.ProgressColor.ToNative();
		}

		public static void UpdateBackgroundColor(this UIProgressView nativeProgressBar, IProgress progress)
		{
			nativeProgressBar.TrackTintColor = progress.BackgroundColor != Color.Default ? progress.BackgroundColor.ToNative() : null;
		}
	}
}