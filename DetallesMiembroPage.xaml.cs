

using APP_Gimnasio.ViewModels;

namespace APP_Gimnasio;

public partial class DetallesMiembroPage : ContentPage
{
    public DetallesMiembroPageViewModel _viewModel = new DetallesMiembroPageViewModel();
    
    public DetallesMiembroPage()
	{

		InitializeComponent();
        BindingContext = _viewModel;
        
	}

    protected override void OnAppearing()
    {

        base.OnAppearing();

        idUsuario.Text = _viewModel.getIdMiembro();
        NombreMiembro.Text = _viewModel.getNombresCompletos();
        Correo.Text = _viewModel.getCorreo();
        Fecha.Text = _viewModel.getFechaInscripcion();

    }

}