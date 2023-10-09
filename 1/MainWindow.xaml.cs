using System.Collections.ObjectModel;
using System.Windows;

namespace TaskManager
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<string> tasks = new ObservableCollection<string>(); // Список задач

        public MainWindow()
        {
            InitializeComponent(); // Инициализация компонентов WPF
            taskListBox.ItemsSource = tasks; // Привязка списка задач к ListBox в XAML
        }

        // Обработчик нажатия кнопки "Добавить"
        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            string taskText = taskTextBox.Text.Trim(); // Получение текста задачи из TextBox
            if (!string.IsNullOrEmpty(taskText)) // Проверка, что текст задачи не пустой
            {
                tasks.Add(taskText); // Добавление задачи в список
                taskTextBox.Clear(); // Очистка текстового поля
            }
        }

        // Обработчик нажатия кнопки "Удалить"
        private void DeleteTaskButton_Click(object sender, RoutedEventArgs e)
        {
            if (taskListBox.SelectedItem != null) // Проверка, что задача выбрана
            {
                tasks.Remove(taskListBox.SelectedItem as string); // Удаление выбранной задачи из списка
            }
        }

        // Обработчик нажатия кнопки "Выполнено"
        private void CompleteTaskButton_Click(object sender, RoutedEventArgs e)
        {
            if (taskListBox.SelectedItem != null) // Проверка, что задача выбрана
            {
                int selectedIndex = taskListBox.SelectedIndex; // Получение индекса выбранной задачи
                string selectedTask = tasks[selectedIndex]; // Получение выбранной задачи
                tasks.RemoveAt(selectedIndex); // Удаление выбранной задачи из списка
                tasks.Insert(selectedIndex, "[Выполнено] " + selectedTask); // Вставка помеченной как выполненной задачи
            }
        }
    }
}
