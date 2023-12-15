using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MauiTestApp;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private void ListView_OnRefreshing(object? sender, EventArgs e)
    {
        Thread.Sleep(1000);
        this.MyListView.IsRefreshing = false;
    }
}

public class MyTest : INotifyPropertyChanged
{
    static MyTest _Instance;
    public static MyTest Instance => _Instance ?? new();
    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public ObservableCollection<Option> Items { get; set; } =  new ()
    {
        new Option { Enabled = false, Name = "Option1"},
        new Option { Enabled = false, Name = "Option2"},
        new Option { Enabled = false, Name = "Option3"}
    };
}

public class Option
{
    public string Name { get; set; }
    
    public bool Enabled {
        get;
        set;
    }
}