using APP_Gimnasio.ViewModels;

namespace APP_Gimnasio;

public partial class RegistrarVisitaPage : ContentPage
{
	public RegistrarVisitaPageViewModel _viewModel = new RegistrarVisitaPageViewModel();
	public RegistrarVisitaPage()
	{

		InitializeComponent();
		BindingContext = _viewModel;

	}
}