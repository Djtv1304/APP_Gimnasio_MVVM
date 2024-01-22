using APP_Gimnasio.Models;
using APP_Gimnasio.ViewModels;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using System.Collections.ObjectModel;

namespace APP_Gimnasio;

public partial class NuevoPagoPage : ContentPage
{

    public NuevoPagoPageViewModel _viewModel = new NuevoPagoPageViewModel();

    public NuevoPagoPage()
    {

        InitializeComponent();
        BindingContext = _viewModel;

    }

    public async void OnAppearing()
    {

        base.OnAppearing();

    }

}