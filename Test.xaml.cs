using jal_crud.ViewModels;
using System.Windows.Input;

namespace jal_crud;

public partial class Test : ContentPage
{
	public ICommand HelloCommand { get; set; }
	public Test()
	{
		InitializeComponent();
		BindingContext = new CategoriasViewModel();
	}
}