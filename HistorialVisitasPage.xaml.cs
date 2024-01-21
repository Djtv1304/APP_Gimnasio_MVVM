using APP_Gimnasio.Models;
using APP_Gimnasio.ViewModels;
using System.Collections.ObjectModel;

namespace APP_Gimnasio;

public partial class HistorialVisitasPage : ContentPage
{
    private HistorialVisitasPageViewModel _viewModel = new HistorialVisitasPageViewModel();

    public HistorialVisitasPage()
	{

		InitializeComponent();
		BindingContext = _viewModel;

	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

        // Diferente aproximación para cargar la lista de visitas
        //listaVisitas.ItemsSource = new ObservableCollection<Visita>(await _viewModel.GetVisitas());

        correo.Text = _viewModel.GetCorreo();

    }
}