using System;
using System.Windows.Input;

namespace FP_EN_Brusnikau_s24109.Classes.Miscellaneous
{
	public class RelayCommand : ICommand
	{
		private readonly Predicate<object> _canExecute;
		private readonly Action<object> _execute;

		public event EventHandler CanExecuteChanged
		{
			add => CommandManager.RequerySuggested += value;
			remove => CommandManager.RequerySuggested -= value;
		}

		public RelayCommand(Action<object> execute, Predicate<object> canExecute)
		{
			_canExecute = canExecute;
			_execute = execute;
		}

		public bool CanExecute(object parameter)
		{
			return _canExecute(parameter);
		}

		public void Execute(object parameter)
		{
			_execute(parameter);
		}
	}
}
