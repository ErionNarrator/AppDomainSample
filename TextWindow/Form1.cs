using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
namespace TextWindow
{
    public partial class Form1 : Form
    {
        /*ссылка на модуль, из которого быдем вызывать методы*/
        Module DrawerModule { get; set; }
        /*объект от которого будем вызывать методы*/
        object Drawer;
        public Form1(Module drawer, object targetWindow)
        {
            DrawerModule = drawer;
            Drawer = targetWindow;
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Form1_LocationChanged(object sender, EventArgs e)
        {
            /*вызываем метд Move главного окна приложения TextDrawer*/
            DrawerModule.GetType("TextDrawer.Form1").GetMethod("Move").Invoke(Drawer, new object[] { new Point(this.Location.X, this.Location.Y + this.Height), this.Width });
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int number1) && int.TryParse(textBox2.Text, out int number2))
            {
              int sum = number1 + number2;

                // Преобразуем результат в строку и сохраняем в DrawerModule
                // Здесь предполагается, что DrawerModule имеет метод для установки значения
                DrawerModule.GetType("TextDrawer.Form1").GetMethod("SetText").Invoke(Drawer, new object[] { sum.ToString() });
            }

        }
    }
}
