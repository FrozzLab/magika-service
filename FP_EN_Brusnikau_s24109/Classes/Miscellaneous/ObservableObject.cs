using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FP_EN_Brusnikau_s24109.Classes.Miscellaneous
{
	public class ObservableObject : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler? PropertyChanged;

		protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
