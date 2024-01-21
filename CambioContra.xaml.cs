using APP_Gimnasio.Models;
using APP_Gimnasio.ViewModels;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace APP_Gimnasio;

public partial class CambioContra : ContentPage
{
    public CambioContraViewModel _viewModel = new CambioContraViewModel();
    public CambioContra()
	{

		InitializeComponent();
        BindingContext = _viewModel;
        
    }

}