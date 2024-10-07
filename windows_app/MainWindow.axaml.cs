using Avalonia.Controls;
using Avalonia.Interactivity;
using System.IO;

namespace linear_programming_problems.windows_app;

public partial class MainWindow : Window{
    public MainWindow(){
        InitializeComponent();
    }
    private void NavigateToSolvingButton_Click(object sender, RoutedEventArgs e){
        bool isGraphicsMethodChecked = GraphicsMethod.IsChecked == true;
        bool isSimplexMethodChecked = SimplexMethod.IsChecked == true;

        switch((isGraphicsMethodChecked, isSimplexMethodChecked)){
            case(true, true):
                ShowError("Нельзя одновременно решать двумя методами. Это приведет к большой нагрузке системы");
                break;
            
            case(false,false):
                ShowError("Метод не определен. Выберите один из методов решения задачи линейного программирования");
                break;

            case(true,false):
                var graphics_window = new graphics_method.GraphicsMethodWindow();
                graphics_window.Show();
                break;

            case(false, true):
                var simplex_window = new simplex_method.SimplexMethodWindow();
                simplex_window.Show();
                break;
        }
    }
    private async void ShowError(string error_message){
        var dialog = new Window{
            Title="Ошибка!",
            Content = new TextBlock{
                Text = error_message
            },
            Width = 300,
            Height = 150
        };
        await dialog.ShowDialog(this);
    }
}