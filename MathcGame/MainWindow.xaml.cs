






















using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MathcGame
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            SetUpGame();
        }

        private void SetUpGame()
        {
            List<String> animalEmoji = new List<String>()
            {
                "🦔", "🦔",
                "🐶", "🐶",
                "🤖", "🤖",
                "😎", "😎",
                "💎", "💎",
                "🎈", "🎈",
                "👧", "👧",
                "🛴", "🛴",
            };
            Random random = new Random();

            foreach (TextBlock textBlock in mainGrid.Children.OfType<TextBlock>())
            {
                int index = random.Next(animalEmoji.Count);// переменной индекс присваивается случайный индекс из списка эмодзи от 0 до каличнства элементов в списке 
                string nextEmoji = animalEmoji[index];// переменой типа стринг(строка) присваивается некстЭмодзи из списка из анималЭмодзи присваивается какой-то элемент из списка 
                textBlock.Text = nextEmoji;// присваивание техтБлоку индекс некстЭмодзи 
                animalEmoji.RemoveAt(index);// удаление эмодзи из списка элементов 

            }

        }
    }

}
