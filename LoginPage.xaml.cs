
using APP_Gimnasio.ViewModels;

namespace APP_Gimnasio;

public partial class LoginPage : ContentPage
{

    public LoginPage()
	{

        InitializeComponent();
        BindingContext = new LoginPageViewModel();

    }

}