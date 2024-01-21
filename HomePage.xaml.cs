using APP_Gimnasio.Models;
using APP_Gimnasio.ViewModels;
using System.Collections.ObjectModel;

namespace APP_Gimnasio;

public partial class HomePage : ContentPage
{

    private HomePageViewModel _viewModel = new HomePageViewModel();
    
    public HomePage()
	{

		InitializeComponent();
        BindingContext = _viewModel;

	}

 
    protected override void OnAppearing()
    {

        base.OnAppearing();

        _viewModel.validarLogin();
        Username.Text = _viewModel.getCorreo();
        idMiembro.Text = _viewModel.getIdMiembro();

    }



}