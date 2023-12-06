using jal_crud.ViewModels;

namespace jal_crud.Views;

public partial class ContactoView : ContentPage
{
	public ContactoView()
	{
		InitializeComponent();
		BindingContext = new ContactosViewModel();
	}
}