using Belu_Ioana_Proiect.Models;

namespace Belu_Ioana_Proiect;

public partial class AlimentPage : ContentPage
{
    Jurnal sl;
    public AlimentPage(Jurnal slist)
    {
        InitializeComponent();
        sl = slist;

    }
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var alimente = (Alimente)BindingContext;
        await App.Database.SaveAlimenteAsync(alimente);
        listView.ItemsSource = await App.Database.GetAlimenteAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var alimente = (Alimente)BindingContext;
        await App.Database.DeleteAlimenteAsync(alimente);
        listView.ItemsSource = await App.Database.GetAlimenteAsync();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetAlimenteAsync();
    }
    async void OnAddButtonClicked(object sender, EventArgs e)
    {
        Alimente p;
        if (listView.SelectedItem != null)
        {
            p = listView.SelectedItem as Alimente;
            var lp = new ListaAlimente()
            {
                JurnalID = sl.ID,
                AlimenteID = p.ID
            };
            await App.Database.SaveListaAlimenteAsync(lp);
            p.ListaAlimente = new List<ListaAlimente> { lp };
            await Navigation.PopAsync();
        }
    }
}