using APP_Gimnasio.Models;
using APP_Gimnasio.ViewModels;

namespace APP_Gimnasio;

public partial class DetallesMembresiaPage : ContentPage
{
    public DetallesMembresiaPageViewModel _viewModel = new DetallesMembresiaPageViewModel();

    public DetallesMembresiaPage()
	{

		InitializeComponent();
		BindingContext = _viewModel;

	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        
        tipo.Text = _viewModel.getMembresia();
        duracion.Text = _viewModel.getDuracionMembresia();
        precio.Text = _viewModel.getPrecioMembresia();

    }
}