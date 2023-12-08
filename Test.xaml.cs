using System.Windows.Input;

namespace jal_crud;

public partial class Test : ContentPage
{
	public ICommand HelloCommand { get; set; }
	public Test()
	{
		InitializeComponent();
		BindingContext = this;
		HelloCommand = new Command<int>(SayHello);
	}

	public void SayHello(int  Name)
	{
		DisplayAlert("Hello", "Hello", "OK");		
	}
}