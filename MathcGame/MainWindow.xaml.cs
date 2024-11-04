using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MathcGame
{
    using System.Windows.Threading;
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();// создание нового таймера 
        int tenthsOfSecondsElapsed;// таймер (отслеживание прошедшего времени)
        int matchesFound;// количество найденых совпадений
        public MainWindow()
        {
            InitializeComponent();

            timer.Interval = TimeSpan.FromSeconds(.1);
            timer.Tick += Timer_Tick;
            SetUpGame();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            tenthsOfSecondsElapsed++;
            timeTextBlock.Text = (tenthsOfSecondsElapsed / 10F).ToString("0.0s");
            if (matchesFound == 8)
            {
                timer.Stop();
                timeTextBlock.Text = timeTextBlock.Text + " - Play again?";
            }
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
                "🛴", "🛴", // список 
            };
            Random random = new Random();

            foreach (TextBlock textBlock in mainGrid.Children.OfType<TextBlock>())
            {
                if (textBlock.Name != "timeTextBlock")
                {
                    textBlock.Visibility = Visibility.Visible;
                    int index = random.Next(animalEmoji.Count);// переменной индекс присваивается случайный индекс из списка эмодзи от 0 до каличнства элементов в списке 
                    string nextEmoji = animalEmoji[index];// переменной типа стринг(строка) присваивается некстЭмодзи из списка анималЭмодзи какой-то элемент из списка 
                    textBlock.Text = nextEmoji;// присваивание текстБлоку индекс некстЭмодзи 
                    animalEmoji.RemoveAt(index);// удаление случайного эмодзи из списка элементов 

                }

            }
            timer.Start();
            tenthsOfSecondsElapsed = 0;
            matchesFound = 0;
        }
        TextBlock lastTextBlockClicked;
        bool findingMatch = false;

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock; 
            if (findingMatch == false)
            {
                textBlock.Visibility = Visibility.Hidden;
                lastTextBlockClicked = textBlock;
                findingMatch = true;
            }
            else if (textBlock.Text == lastTextBlockClicked.Text)
            {
                matchesFound++;
                textBlock.Visibility = Visibility.Hidden;
                findingMatch = false;
            }
            else 
            {
                lastTextBlockClicked.Visibility = Visibility.Visible;
                findingMatch = false;
            }
        }

        private void TimeTextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (matchesFound == 8) // сбрасывет игру, если были найдены все 8 пар
            {
                SetUpGame(); // сбрасывет игру, если были найдены все 8 пар 
            }
        }
    }

}
