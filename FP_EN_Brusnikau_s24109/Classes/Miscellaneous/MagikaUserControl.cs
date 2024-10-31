using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace FP_EN_Brusnikau_s24109.Classes.Miscellaneous
{
	public class MagikaUserControl : UserControl
	{
		public int WindowWidth { get; set; } = 1300;
		public int WindowHeight { get; set; } = 800;

		public MagikaUserControl()
		{

			if (!DesignerProperties.GetIsInDesignMode(this))
			{
				Loaded += OnLoaded;
			}
		}

		private void OnLoaded(object sender, RoutedEventArgs e)
		{
			Application.Current.MainWindow.Width = WindowWidth;	
			Application.Current.MainWindow.Height = WindowHeight;

			CenterWindowOnScreen(Application.Current.MainWindow);
		}

		private void CenterWindowOnScreen(Window window)
		{
			var screen = SystemParameters.WorkArea;
			double screenWidth = screen.Width;
			double screenHeight = screen.Height;

			window.Left = (screenWidth - window.Width) / 2;
			window.Top = (screenHeight - window.Height) / 2;
		}
	}
}
