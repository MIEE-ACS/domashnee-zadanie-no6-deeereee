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

namespace Dz_6
{

    abstract class GardenPlant
    {
        public string name { get; set; }
        public int efficiency { get; set; } //Урожайность
        public string color { get; set; }
        public int ripenning_time { get; set; }

        public GardenPlant(string name, int efficiency, string color, int ripenning_time)
        {
            this.name = name;
            this.efficiency = efficiency;
            this.color = color;
            this.ripenning_time = ripenning_time;
        }

        public override string ToString()
        {
            return string.Format("Название: {0} Урожайность: {1} Цвет: {2} Время созревания: {3} ", name, efficiency, color, ripenning_time );

        }

        public override bool Equals(object obj)
        {
            if (obj is GardenPlant)
            {
                GardenPlant x = (GardenPlant)obj;
                return name == x.name & efficiency == x.efficiency & color == x.color & ripenning_time == x.ripenning_time;
            }
            else
            {
                return false;
            }
        }


    }

    class Vegetable : GardenPlant
    {
        public Vegetable (string name, int efficiency, string color, int ripenning_time) : base (name, efficiency, color, ripenning_time ) { }


        public override string ToString()
        {
            return base.ToString();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

    }

    class FruitTree : GardenPlant
    {
        public FruitTree (string name, int efficiency, string color, int ripenning_time) : base(name, efficiency, color, ripenning_time) { }

        public override string ToString()
        {
            return base.ToString();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

    }

    class Berry : GardenPlant
    {
        public Berry (string name, int efficiency, string color, int ripenning_time) : base(name, efficiency, color, ripenning_time) { }

        public override string ToString()
        {
            return base.ToString();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

    }

    class AppleTree : FruitTree
    {
        public AppleTree (string name, int efficiency, string color, int ripenning_time) : base(name, efficiency, color, ripenning_time) { }

        public override string ToString()
        {
            return base.ToString();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

    }

    class Potato : Vegetable
    {
        public Potato (string name, int efficiency, string color, int ripenning_time) : base(name, efficiency, color, ripenning_time) { }

        public override string ToString()
        {
            return base.ToString();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

    }

    class Raspberry : Berry
    {
        public Raspberry (string name, int efficiency, string color, int ripenning_time) : base(name, efficiency, color, ripenning_time) { }

        public override string ToString()
        {
            return base.ToString();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

    }

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        List<GardenPlant> result = new List<GardenPlant>();
        int n = 0;
      
        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            string name = tb_name.Text;
            
            string col = tb_color.Text;
            

            if (Int32.TryParse(tb_eff.Text, out int eff) && Int32.TryParse(tb_time.Text, out int time))
            {
                if (rb_veg.IsChecked == true)
                {
                    result.Add(new Vegetable(name, eff, col, time));
                   // tb_color.Text = result[0].ToString();
                }
                else if (rb_fru.IsChecked == true)
                {
                    result.Add(new FruitTree(name, eff, col, time));
                }
                else if (rb_ber.IsChecked == true)
                {
                    result.Add(new Berry(name, eff, col, time));
                }
                else if (rb_rasb.IsChecked == true)
                {
                    result.Add(new Raspberry(name, eff, col, time));
                }
                else if (rb_apple.IsChecked == true)
                {
                    result.Add(new AppleTree(name, eff, col, time));
                }
                else if (rb_potato.IsChecked == true)
                {
                    result.Add(new Potato(name, eff, col, time));
                }
                MessageBox.Show("Объект добавлен");
                n++;
               
                if (n < 3)
                {
                    MessageBox.Show("Для начала работы нужно добавить три объекта");
                }
            }
            else
            {
                MessageBox.Show("Введены некоректные данные!");
            }

            tb_color.Text = "";
            tb_eff.Text = "";
            tb_name.Text = "";
            tb_time.Text = "";






        }

        private void Button_Click_All(object sender, RoutedEventArgs e)
        {
            if (n < 3)
            {
                MessageBox.Show("Для начала работы нужно добавить три объекта");
            }
            else
            {
                dgrid.ItemsSource = null;
                dgrid.ItemsSource = result;
            }
        }

        private void Button_Click_Max(object sender, RoutedEventArgs e)
        {

            if (n < 3)
            {
                MessageBox.Show("Для начала работы нужно добавить три объекта");
            }
            else
            {
                List<GardenPlant> result1 = new List<GardenPlant>();

                result1.AddRange(result);
               
                result1.Sort((x, y) => x.ripenning_time.CompareTo(y.ripenning_time));
                dgrid2.ItemsSource = null;
                dgrid2.ItemsSource = result1;

            }
        }

        private void Button_Click_3max(object sender, RoutedEventArgs e)
        {

            if (n < 3)
            {
                MessageBox.Show("Для начала работы нужно добавить три объекта");
            }
            else
            {
                List<GardenPlant> result1 = new List<GardenPlant>();
                result1.AddRange(result);
                List<GardenPlant> max = new List<GardenPlant>();
                result1.Sort((x, y) => -x.efficiency.CompareTo(y.efficiency));

                for (int i = 0; i < 3; i++)
                {
                    max.Add(result1[i]);
                }

                dgrid3.ItemsSource = null;
                dgrid3.ItemsSource = max;
            }
        }

        private void Button_Click_Del(object sender, RoutedEventArgs e)
        {
            string x = tb_del.Text;
            result = result.Where(line => line.name != x).ToList();
            
        }
    }
}
