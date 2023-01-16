namespace Belu_Ioana_Proiect;

public partial class CalculatorPage : ContentPage
{
	public CalculatorPage()
	{
		InitializeComponent();
		BindingContext = new CalculatorPageViewModel();
	}
}