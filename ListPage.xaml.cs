using Belu_Ioana_Proiect.Models;
namespace Belu_Ioana_Proiect;

public partial class ListPage : ContentPage
{
	public ListPage()
	{
		InitializeComponent();
	}
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var slist = (Jurnal)BindingContext;
        slist.Date = DateTime.UtcNow;
        await App.Database.SaveJurnalAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (Jurnal)BindingContext;
        await App.Database.DeleteJurnalAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnChooseButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AlimentPage((Jurnal)
       this.BindingContext)
        {
            BindingContext = new Alimente()
        });
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var shopl = (Jurnal)BindingContext;

        listView.ItemsSource = await App.Database.GetListaAlimenteAsync(shopl.ID);
    }

}