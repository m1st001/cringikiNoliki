using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!CheckSymbols())
            {
                MessageBox.Show("Введенный текст не 'х' и не 'о'", "КрИтИчесКая АшибКА", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            status.Text = CheckForWin();
            if (status.Text.Length > 19)
            {
                MessageBox.Show($@"{status.Text}", "Win!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Restart();
            }

            if (CheckForDraw())
            {
                MessageBox.Show($@"Ничья!", "Draw", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Restart();
            }
        }

        private string CheckForWin()
        {
            if (textBox1.Text.Length > 0) //Проверяем 3 линии из верхнего левого угла.
            {
                if (textBox1.Text.Equals(textBox2.Text) && textBox1.Text.Equals(textBox3.Text)) 
                {
                    return $@"Игрок '{textBox1.Text}' побеждает.";
                }

                if (textBox1.Text.Equals(textBox4.Text) && textBox1.Text.Equals(textBox7.Text))
                {
                    return $@"Игрок '{textBox1.Text}' побеждает.";
                }

                if (textBox1.Text.Equals(textBox5.Text) && textBox1.Text.Equals(textBox9.Text))
                {
                    return $@"Игрок '{textBox1.Text}' побеждает.";
                }
            }

            if (textBox5.Text.Length > 0) //Проверяем 2 линии из через центр.
            {
                if (textBox2.Text.Equals(textBox5.Text) && textBox2.Text.Equals(textBox8.Text)) 
                {
                    return $@"Игрок '{textBox5.Text}' побеждает.";
                }

                if (textBox4.Text.Equals(textBox5.Text) && textBox4.Text.Equals(textBox6.Text))
                {
                    return $@"Игрок '{textBox5.Text}' побеждает.";
                }
            }

            if (textBox3.Text.Length > 0) //Проверяем 3 оставшиеся линии.
            {
                if (textBox3.Text.Equals(textBox5.Text) && textBox3.Text.Equals(textBox7.Text)) 
                {
                    return $@"Игрок '{textBox3.Text}' побеждает.";
                }

                if (textBox3.Text.Equals(textBox6.Text) && textBox3.Text.Equals(textBox9.Text))
                {
                    return $@"Игрок '{textBox3.Text}' побеждает.";
                }

                if (textBox7.Text.Equals(textBox8.Text) && textBox7.Text.Equals(textBox9.Text))
                {
                    return $@"Игрок '{textBox7.Text}' побеждает.";
                }
            }
            return "Игра продолжается.";
        }

        private bool CheckForDraw()
        {
            int counter = 0;
            foreach (TextBox tb in this.Controls.OfType<TextBox>())
            {
                if (tb.Text.Length > 0)
                {
                    counter++;
                }
            }

            if (counter == 9)
            {
                return true;
            }

            return false;
        }

        private bool CheckSymbols()
        {
            string symbols = "xo";
            foreach (TextBox tb in this.Controls.OfType<TextBox>())
            {
                if (tb.Text.Length == 0)
                {
                    continue;
                }

                if (tb.Text.Length > 1)
                {
                    return false;
                }

                if (!symbols.Contains(tb.Text[0]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}