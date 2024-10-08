using Avalonia;
using Avalonia.Controls;
using Avalonia.Layout;

namespace linear_programming_problems.windows_app.graphics_method;

public partial class GraphicsMethodWindow : Window{
    public GraphicsMethodWindow(){
        InitializeComponent();
        ComboboxValues.SelectionChanged += ComboboxValuesSelectionChanged;
    }
    private void ComboboxValuesSelectionChanged(object sender, SelectionChangedEventArgs e){
        int selected_value = int.Parse((sender as ComboBox).SelectedItem as string);
        GenerateInputFields(selected_value);
    }
    private void GenerateInputFields(int count){
        InputFields.Items.Clear();
        for (int i=1; i<= count; i++){
            StackPanel input_field_panel = new StackPanel{
                Orientation = Orientation.Horizontal
            };
            TextBlock text_block = new TextBlock{
                Text = $"x_{i}:",
                Margin = new Thickness(5)
            };
            TextBox text_box = new TextBox{
                Width = 100,
                Margin = new Thickness(5)
            };
            input_field_panel.Children.Add(text_block);
            input_field_panel.Children.Add(text_box);
            InputFields.Items.Add(input_field_panel);
        }
        if(count <1 || count >2){
            ShowError("Ошибка! Не выбрано ничего или\nвыбрано больше двух переменных\nневозможно построить многоугольник решений");
        } else {
            
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