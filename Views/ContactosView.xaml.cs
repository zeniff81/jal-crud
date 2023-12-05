using jal_crud.ViewModels;

namespace jal_crud.Views;

public partial class ContactosView : ContentPage
{
	public ContactosView()
	{
		InitializeComponent();
		BindingContext = new ContactosViewModel();
	}
}