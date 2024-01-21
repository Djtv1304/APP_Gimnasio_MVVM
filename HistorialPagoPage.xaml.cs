using APP_Gimnasio.Models;
using System.Collections.ObjectModel;
using APP_Gimnasio.Service;
using APP_Gimnasio.ViewModels;

namespace APP_Gimnasio;

public partial class HistorialPagoPage : ContentPage
{
    private HistorialPagoPageViewModel _viewModel = new HistorialPagoPageViewModel();

    public HistorialPagoPage()
	{
		
        InitializeComponent();
        BindingContext = _viewModel;

	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        
        correo.Text = _viewModel.getCorreo();
    }
}