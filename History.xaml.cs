using System.Linq.Expressions;

namespace Calculator;

public partial class History1 : ContentPage
{
    public List<HistoryItem> Items { get; set; }
    public History1()
    {
        InitializeComponent();
       
    }

   
    List<HistoryItem> history = new List<HistoryItem>();

     

    private async void Delete_Clicked(object sender, EventArgs e)
    {
        int result = await  Calculator.historyViewModel.DeleteHistory();
        ListViewItems.ItemsSource = new List<HistoryItem>();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        history = await Calculator.historyViewModel.GetHistory();
        ListViewItems.ItemsSource = history;

    }

}