using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Matematika
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        int lastRadio = 0;
        int result;
        public MainPage()
        {
            this.InitializeComponent();
            
        }

        private void SubtractButton_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)DecimalRadio.IsChecked)
            {
                try
                {
                    lastRadio = 1;
                    result = Convert.ToInt32(TextBox1.Text) - Convert.ToInt32(TextBox2.Text);
                    rezultatBlock.Text = result.ToString();
                }
                catch
                {
                    rezultatBlock.Text = "Not valid input!";
                }
            }
            if ((bool)HexRadio.IsChecked)
            {
                try
                {
                    lastRadio = 2;
                    result = Convert.ToInt32(TextBox1.Text, 16) - Convert.ToInt32(TextBox2.Text, 16);
                    rezultatBlock.Text = result.ToString("X");
                }
                catch
                {
                    rezultatBlock.Text = "Not valid input!";
                }
            }
            if ((bool)OctRadio.IsChecked)
            {
                try
                {
                    lastRadio = 3;

                    int octal = 0, Oop1 = Convert.ToInt32(TextBox1.Text), Oop2 = Convert.ToInt32(TextBox2.Text), op1 = 0, op2 = 0;
                    for (int t=Oop1; t!= 0;)
                    {
                        if(t%10==8 || t%10==9)
                        
                        { throw new Exception(); }
                        t /= 10;
                    }
                    for (int t = Oop2; t != 0;)
                    {
                        if (t % 10 == 8 || t % 10 == 9)
                        { throw new Exception(); }
                        t /= 10;
                    }
                    for (int i = 1; Oop1 != 0;)
                    {
                        op1 += (Oop1 % 10) * i;
                        Oop1 /= 10;
                        i *= 8;
                    }
                    for (int i = 1; Oop2 != 0;)
                    {
                        op2 += (Oop2 % 10) * i;
                        Oop2 /= 10;
                        i *= 8;
                    }
                    result = op1 - op2;
                    while (result != 0)
                    {
                        if (result % 8 == 0)
                        {
                            octal = octal * 10 + 9;
                            result = result / 8;
                        }
                        else
                        {
                            octal = octal * 10 + result % 8;
                            result /= 8;
                        }
                    }

                    while (octal != 0)
                    {
                        if (octal % 10 == 9)
                        {
                            result = result * 10;
                            octal = octal / 10;
                        }
                        else
                        {
                            result = result * 10 + octal % 10;
                            octal = octal / 10;
                        }
                    }
                    rezultatBlock.Text = Convert.ToString(result);
                }
                catch
                {
                    rezultatBlock.Text = "Not valid input!";
                }

            }
            if ((bool)BinaryRadio.IsChecked)
            {
                try
                {

                    lastRadio = 4;
                    int binary = 0, bop1 = Convert.ToInt32(TextBox1.Text), bop2 = Convert.ToInt32(TextBox2.Text), op1 = 0, op2 = 0;
                    for (int t = bop1; t != 0;)
                    {
                        if (t % 10 == 0 || t % 10 == 1)
                        { t /= 10; }
                        else
                        { throw new Exception(); }
                    }
                    for (int t = bop2; t != 0;)
                    {
                        if (t % 10 == 0 || t % 10 == 1)
                        { t /= 10; }
                        else
                        { throw new Exception(); }
                    }
                    for (int i = 1; bop1 != 0;)
                    {
                        if (bop1 % 10 == 1)
                        {
                            op1 = op1 + i;
                            bop1 = bop1 / 10;
                        }
                        else if (bop1 % 10 == 0)
                        {
                            bop1 = bop1 / 10;
                        }
                        i = i * 2;
                    }
                    for (int i = 1; bop2 != 0;)
                    {
                        if (bop2 % 10 == 1)
                        {
                            op2 = op2 + i;
                            bop2 = bop2 / 10;
                        }
                        else if (bop2 % 10 == 0)
                        {
                            bop2 = bop2 / 10;
                        }
                        i = i * 2;
                    }
                    result = op1 - op2;
                    for (int i = 0; result != 0; i++)
                    {
                        if (result % 2 == 0)
                        {
                            binary = binary * 10 + 2;
                            result = result / 2;
                        }
                        else if (result % 2 == 1)
                        {
                            binary = binary * 10 + 1;
                            result = result / 2;
                        }
                    }

                    while (binary != 0)
                    {
                        if (binary % 10 == 2)
                        {
                            result = result * 10;
                            binary = binary / 10;
                        }
                        else if (binary % 10 == 1)
                        {
                            result = result * 10 + 1;
                            binary = binary / 10;
                        }
                    }
                    rezultatBlock.Text = Convert.ToString(result);
                }
                catch
                {
                    rezultatBlock.Text = "Not valid input!";
                }
            }
        }

        private void DecimalRadio_Checked(object sender, RoutedEventArgs e)
        {
            
        }

        private void HexRadio_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void DecimalRadio_Clicked(object sender, RoutedEventArgs e)
        {
            if (lastRadio == 2)
            {
                lastRadio = 1;
                result = Convert.ToInt32(result);
                rezultatBlock.Text = result.ToString();
            }
            if (lastRadio == 3)
            {
                lastRadio = 1;
                result = Convert.ToInt32(result);
                int octal = 0;
                for (int i = 1; result != 0;)
                {
                    octal += (result % 10) * i;
                    result /= 10;
                    i *= 8;
                }
                result = octal;
                rezultatBlock.Text = Convert.ToString(result);
            }
            if (lastRadio == 4)
            {
                int binary = 0;
                result = Convert.ToInt32(result);
                for (int i = 1; result != 0;)
                {
                    if (result % 10 == 1)
                    {
                        binary += i;
                        result /= 10;
                    }
                    else if (result % 10 == 0)
                    {
                        result /= 10;
                    }
                    i *= 2;
                }
                result = binary;
                rezultatBlock.Text = Convert.ToString(result);
                lastRadio = 1;
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)DecimalRadio.IsChecked)
            {
                try
                {
                    lastRadio = 1;
                    result = Convert.ToInt32(TextBox1.Text) + Convert.ToInt32(TextBox2.Text);
                    rezultatBlock.Text = result.ToString();
                }
                catch
                {
                    rezultatBlock.Text = "Not valid input!";
                }
            }
            if ((bool)HexRadio.IsChecked)
            {
                try
                {
                    lastRadio = 2;
                    result = Convert.ToInt32(TextBox1.Text, 16) + Convert.ToInt32(TextBox2.Text, 16);
                    rezultatBlock.Text = result.ToString("X");
                }
                catch
                {
                    rezultatBlock.Text = "Not valid input!";
                }
            }
            if ((bool)OctRadio.IsChecked)
            {
                try
                {
                    lastRadio = 3;

                    int octal = 0, Oop1 = Convert.ToInt32(TextBox1.Text), Oop2 = Convert.ToInt32(TextBox2.Text), op1 = 0, op2 = 0;
                    for (int t = Oop1; t != 0;)
                    {
                        if (t % 10 == 8 || t % 10 == 9)
                        { throw new Exception(); }
                        t /= 10;
                    }
                    for (int t = Oop2; t != 0;)
                    {
                        if (t % 10 == 8 || t % 10 == 9)
                        { throw new Exception(); }
                        t/= 10;
                    }
                    for (int i = 1; Oop1 != 0;)
                    {
                        op1 += (Oop1 % 10) * i;
                        Oop1 /= 10;
                        i *= 8;
                    }
                    for (int i = 1; Oop2 != 0;)
                    {
                        op2 += (Oop2 % 10) * i;
                        Oop2 /= 10;
                        i *= 8;
                    }
                    result = op1 + op2;
                    while (result != 0)
                    {
                        if (result % 8 == 0)
                        {
                            octal = octal * 10 + 9;
                            result = result / 8;
                        }
                        else
                        {
                            octal = octal * 10 + result % 8;
                            result /= 8;
                        }
                    }

                    while (octal != 0)
                    {
                        if (octal % 10 == 9)
                        {
                            result = result * 10;
                            octal = octal / 10;
                        }
                        else
                        {
                            result = result * 10 + octal % 10;
                            octal = octal / 10;
                        }
                    }
                    rezultatBlock.Text = Convert.ToString(result);
                }
                catch
                {
                    rezultatBlock.Text = "Not valid input!";
                }

            }
            if ((bool)BinaryRadio.IsChecked)
            {
                try
                {

                    lastRadio = 4;
                    int binary = 0, bop1 = Convert.ToInt32(TextBox1.Text), bop2 = Convert.ToInt32(TextBox2.Text), op1 = 0, op2 = 0;
                    for (int t = bop1; t != 0;)
                    {
                        if (t % 10 == 0 || t % 10 == 1)
                        { t /= 10; }
                        else
                        { throw new Exception(); }
                    }
                    for (int t = bop2; t != 0;)
                    {
                        if (t % 10 == 0 || t % 10 == 1)
                        { t /= 10; }
                        else
                        { throw new Exception(); }
                    }
                    for (int i = 1; bop1 != 0;)
                    {
                        if (bop1 % 10 == 1)
                        {
                            op1 = op1 + i;
                            bop1 = bop1 / 10;
                        }
                        else if (bop1 % 10 == 0)
                        {
                            bop1 = bop1 / 10;
                        }
                        i = i * 2;
                    }
                    for (int i = 1; bop2 != 0;)
                    {
                        if (bop2 % 10 == 1)
                        {
                            op2 = op2 + i;
                            bop2 = bop2 / 10;
                        }
                        else if (bop2 % 10 == 0)
                        {
                            bop2 = bop2 / 10;
                        }
                        i = i * 2;
                    }
                    result = op1 + op2;
                    for (int i = 0; result != 0; i++)
                    {
                        if (result % 2 == 0)
                        {
                            binary = binary * 10 + 2;
                            result = result / 2;
                        }
                        else if (result % 2 == 1)
                        {
                            binary = binary * 10 + 1;
                            result = result / 2;
                        }
                    }

                    while (binary != 0)
                    {
                        if (binary % 10 == 2)
                        {
                            result = result * 10;
                            binary = binary / 10;
                        }
                        else if (binary % 10 == 1)
                        {
                            result = result * 10 + 1;
                            binary = binary / 10;
                        }
                    }
                    rezultatBlock.Text = Convert.ToString(result);
                }
                catch
                {
                    rezultatBlock.Text = "Not valid input!";
                }
            }
        }

        private void MultiplyButton_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)DecimalRadio.IsChecked)
            {
                try
                {
                    lastRadio = 1;
                    result = Convert.ToInt32(TextBox1.Text) * Convert.ToInt32(TextBox2.Text);
                    rezultatBlock.Text = result.ToString();
                }
                catch
                {
                    rezultatBlock.Text = "Not valid input!";
                }
            }
            if ((bool)HexRadio.IsChecked)
            {
                try
                {
                    lastRadio = 2;
                    result = Convert.ToInt32(TextBox1.Text, 16) * Convert.ToInt32(TextBox2.Text, 16);
                    rezultatBlock.Text = result.ToString("X");
                }
                catch
                {
                    rezultatBlock.Text = "Not valid input!";
                }
            }
            if ((bool)OctRadio.IsChecked)
            {
                try
                {
                    lastRadio = 3;

                    int octal = 0, Oop1 = Convert.ToInt32(TextBox1.Text), Oop2 = Convert.ToInt32(TextBox2.Text), op1 = 0, op2 = 0;
                    for (int t = Oop1; t != 0;)
                    {
                        if (t % 10 == 8 || t % 10 == 9)
                        { throw new Exception(); }
                        t /= 10;
                    }
                    for (int t = Oop2; t != 0;)
                    {
                        if (t % 10 == 8 || t % 10 == 9)
                        { throw new Exception(); }
                        t /= 10;
                    }
                    for (int i = 1; Oop1 != 0;)
                    {
                        op1 += (Oop1 % 10) * i;
                        Oop1 /= 10;
                        i *= 8;
                    }
                    for (int i = 1; Oop2 != 0;)
                    {
                        op2 += (Oop2 % 10) * i;
                        Oop2 /= 10;
                        i *= 8;
                    }
                    result = op1 * op2;
                    while (result != 0)
                    {
                        if (result % 8 == 0)
                        {
                            octal = octal * 10 + 9;
                            result = result / 8;
                        }
                        else
                        {
                            octal = octal * 10 + result % 8;
                            result /= 8;
                        }
                    }

                    while (octal != 0)
                    {
                        if (octal % 10 == 9)
                        {
                            result = result * 10;
                            octal = octal / 10;
                        }
                        else
                        {
                            result = result * 10 + octal % 10;
                            octal = octal / 10;
                        }
                    }
                    rezultatBlock.Text = Convert.ToString(result);
                }
                catch
                {
                    rezultatBlock.Text = "Not valid input!";
                }

            }
            if ((bool)BinaryRadio.IsChecked)
            {
                try
                {

                    lastRadio = 4;
                    int binary = 0, bop1 = Convert.ToInt32(TextBox1.Text), bop2 = Convert.ToInt32(TextBox2.Text), op1 = 0, op2 = 0;
                    for (int t = bop1; t != 0;)
                    {
                        if (t % 10 == 0 || t % 10 == 1)
                        { t /= 10; }
                        else
                        { throw new Exception(); }
                    }
                    for (int t = bop2; t != 0;)
                    {
                        if (t % 10 == 0 || t % 10 == 1)
                        { t /= 10; }
                        else
                        { throw new Exception(); }
                    }
                    for (int i = 1; bop1 != 0;)
                    {
                        if (bop1 % 10 == 1)
                        {
                            op1 = op1 + i;
                            bop1 = bop1 / 10;
                        }
                        else if (bop1 % 10 == 0)
                        {
                            bop1 = bop1 / 10;
                        }
                        i = i * 2;
                    }
                    for (int i = 1; bop2 != 0;)
                    {
                        if (bop2 % 10 == 1)
                        {
                            op2 = op2 + i;
                            bop2 = bop2 / 10;
                        }
                        else if (bop2 % 10 == 0)
                        {
                            bop2 = bop2 / 10;
                        }
                        i = i * 2;
                    }
                    result = op1 * op2;
                    for (int i = 0; result != 0; i++)
                    {
                        if (result % 2 == 0)
                        {
                            binary = binary * 10 + 2;
                            result = result / 2;
                        }
                        else if (result % 2 == 1)
                        {
                            binary = binary * 10 + 1;
                            result = result / 2;
                        }
                    }

                    while (binary != 0)
                    {
                        if (binary % 10 == 2)
                        {
                            result = result * 10;
                            binary = binary / 10;
                        }
                        else if (binary % 10 == 1)
                        {
                            result = result * 10 + 1;
                            binary = binary / 10;
                        }
                    }
                    rezultatBlock.Text = Convert.ToString(result);
                }
                catch
                {
                    rezultatBlock.Text = "Not valid input!";
                }
            }
        }

        private void DivideButton_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)DecimalRadio.IsChecked)
            {
                try
                {
                    lastRadio = 1;
                    result = Convert.ToInt32(TextBox1.Text) / Convert.ToInt32(TextBox2.Text);
                    rezultatBlock.Text = result.ToString();
                }
                catch
                {
                    rezultatBlock.Text = "Not valid input!";
                }
            }
            if ((bool)HexRadio.IsChecked)
            {
                try
                {
                    lastRadio = 2;
                    result = Convert.ToInt32(TextBox1.Text, 16) / Convert.ToInt32(TextBox2.Text, 16);
                    rezultatBlock.Text = result.ToString("X");
                }
                catch
                {
                    rezultatBlock.Text = "Not valid input!";
                }
            }
            if ((bool)OctRadio.IsChecked)
            {
                try
                {
                    lastRadio = 3;

                    int octal = 0, Oop1 = Convert.ToInt32(TextBox1.Text), Oop2 = Convert.ToInt32(TextBox2.Text), op1 = 0, op2 = 0;
                    for (int t = Oop1; t != 0;)
                    {
                        if (t % 10 == 8 || t % 10 == 9)
                        { throw new Exception(); }
                    }
                    for (int t = Oop2; t != 0;)
                    {
                        if (t % 10 == 8 || t % 10 == 9)
                        { throw new Exception(); }
                    }
                    for (int i = 1; Oop1 != 0;)
                    {
                        op1 += (Oop1 % 10) * i;
                        Oop1 /= 10;
                        i *= 8;
                    }
                    for (int i = 1; Oop2 != 0;)
                    {
                        op2 += (Oop2 % 10) * i;
                        Oop2 /= 10;
                        i *= 8;
                    }
                    result = op1 / op2;
                    while (result != 0)
                    {
                        if (result % 8 == 0)
                        {
                            octal = octal * 10 + 9;
                            result = result / 8;
                        }
                        else
                        {
                            octal = octal * 10 + result % 8;
                            result /= 8;
                        }
                    }

                    while (octal != 0)
                    {
                        if (octal % 10 == 9)
                        {
                            result = result * 10;
                            octal = octal / 10;
                        }
                        else
                        {
                            result = result * 10 + octal % 10;
                            octal = octal / 10;
                        }
                    }
                    rezultatBlock.Text = Convert.ToString(result);
                }
                catch
                {
                    rezultatBlock.Text = "Not valid input!";
                }

            }
            if ((bool)BinaryRadio.IsChecked)
            {
                try
                {

                    lastRadio = 4;
                    int binary = 0, bop1 = Convert.ToInt32(TextBox1.Text), bop2 = Convert.ToInt32(TextBox2.Text), op1 = 0, op2 = 0;
                    for (int t = bop1; t != 0;)
                    {
                        if (t % 10 == 0 || t % 10 == 1)
                        { t /= 10; }
                        else
                        { throw new Exception(); }
                    }
                    for (int t = bop2; t != 0;)
                    {
                        if (t % 10 == 0 || t % 10 == 1)
                        { t /= 10; }
                        else
                        { throw new Exception(); }
                    }
                    for (int i = 1; bop1 != 0;)
                    {
                        if (bop1 % 10 == 1)
                        {
                            op1 = op1 + i;
                            bop1 = bop1 / 10;
                        }
                        else if (bop1 % 10 == 0)
                        {
                            bop1 = bop1 / 10;
                        }
                        i = i * 2;
                    }
                    for (int i = 1; bop2 != 0;)
                    {
                        if (bop2 % 10 == 1)
                        {
                            op2 = op2 + i;
                            bop2 = bop2 / 10;
                        }
                        else if (bop2 % 10 == 0)
                        {
                            bop2 = bop2 / 10;
                        }
                        i = i * 2;
                    }
                    result = op1 / op2;
                    for (int i = 0; result != 0; i++)
                    {
                        if (result % 2 == 0)
                        {
                            binary = binary * 10 + 2;
                            result = result / 2;
                        }
                        else if (result % 2 == 1)
                        {
                            binary = binary * 10 + 1;
                            result = result / 2;
                        }
                    }

                    while (binary != 0)
                    {
                        if (binary % 10 == 2)
                        {
                            result = result * 10;
                            binary = binary / 10;
                        }
                        else if (binary % 10 == 1)
                        {
                            result = result * 10 + 1;
                            binary = binary / 10;
                        }
                    }
                    rezultatBlock.Text = Convert.ToString(result);
                }
                catch
                {
                    rezultatBlock.Text = "Not valid input!";
                }
            }
        }

        private void HexRadio_Click(object sender, RoutedEventArgs e)
        {
            if (lastRadio == 1)
            {
                lastRadio = 2;
                rezultatBlock.Text = result.ToString("X");
            }
            if (lastRadio == 3)
            {
                lastRadio = 2;
                result = Convert.ToInt32(result);
                int octal = 0;
                for (int i = 1; result != 0;)
                {
                    octal += (result % 10) * i;
                    result /= 10;
                    i *= 8;
                }
                result = octal;
                rezultatBlock.Text = result.ToString("X");
            }
            if (lastRadio == 4)
            {
                int binary = 0;
                result = Convert.ToInt32(result);
                for (int i = 1; result != 0;)
                {
                    if (result % 10 == 1)
                    {
                        binary += i;
                        result /= 10;
                    }
                    else if (result % 10 == 0)
                    {
                        result /= 10;
                    }
                    i *= 2;
                }
                result = binary;
                rezultatBlock.Text = result.ToString("X");
                lastRadio = 2;
            }
        }

        private void OctalRadio_Click(object sender, RoutedEventArgs e)
        {
            if (lastRadio == 1)
            {
                lastRadio = 3;
                int octal = 0;
                while (result != 0)
                {
                    if (result % 8 == 0)
                    {
                        octal = octal * 10 + 9;
                        result = result / 8;
                    }
                    else
                    {
                        octal = octal * 10 + result % 8;
                        result /= 8;
                    }
                }

                while (octal != 0)
                {
                    if (octal % 10 == 9)
                    {
                        result = result * 10;
                        octal = octal / 10;
                    }
                    else
                    {
                        result = result * 10 + octal % 10;
                        octal = octal / 10;
                    }
                }
                rezultatBlock.Text = result.ToString();
            }
            if (lastRadio == 2)
            {
                lastRadio = 3;
                result = Convert.ToInt32(result);
                int octal = 0;
                while (result != 0)
                {
                    if (result % 8 == 0)
                    {
                        octal = octal * 10 + 9;
                        result = result / 8;
                    }
                    else
                    {
                        octal = octal * 10 + result % 8;
                        result /= 8;
                    }
                }

                while (octal != 0)
                {
                    if (octal % 10 == 9)
                    {
                        result = result * 10;
                        octal = octal / 10;
                    }
                    else
                    {
                        result = result * 10 + octal % 10;
                        octal = octal / 10;
                    }
                }
                rezultatBlock.Text = result.ToString();
            }
            if (lastRadio == 4)
            {
                int binary = 0;
                result = Convert.ToInt32(result);
                int octal = 0;
                
                for (int i = 1; result != 0;)
                {
                    if (result % 10 == 1)
                    {
                        binary += i;
                        result /= 10;
                    }
                    else if (result % 10 == 0)
                    {
                        result /= 10;
                    }
                    i *= 2;
                }
                result = binary;
                while (result != 0)
                {
                    if (result % 8 == 0)
                    {
                        octal = octal * 10 + 9;
                        result = result / 8;
                    }
                    else
                    {
                        octal = octal * 10 + result % 8;
                        result /= 8;
                    }
                }

                while (octal != 0)
                {
                    if (octal % 10 == 9)
                    {
                        result = result * 10;
                        octal = octal / 10;
                    }
                    else
                    {
                        result = result * 10 + octal % 10;
                        octal = octal / 10;
                    }
                }
                rezultatBlock.Text = result.ToString();
                lastRadio = 3;
            }
        }

        private void BinaryRadio_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (lastRadio == 1)
                {
                    lastRadio = 4;
                    int binary = 0;
                    result = Convert.ToInt32(result);
                    for (int i = 0; result != 0; i++)
                    {
                        if (result % 2 == 0)
                        {
                            binary = binary * 10 + 2;
                            result = result / 2;
                        }
                        else if (result % 2 == 1)
                        {
                            binary = binary * 10 + 1;
                            result = result / 2;
                        }
                    }

                    while (binary != 0)
                    {
                        if (binary % 10 == 2)
                        {
                            result = result * 10;
                            binary = binary / 10;
                        }
                        else if (binary % 10 == 1)
                        {
                            result = result * 10 + 1;
                            binary = binary / 10;
                        }
                    }
                    rezultatBlock.Text = result.ToString();
                }
                if (lastRadio == 2)
                {
                    lastRadio = 4;
                    int binary = 0;
                    result = Convert.ToInt32(result);
                    for (int i = 0; result != 0; i++)
                    {
                        if (result % 2 == 0)
                        {
                            binary = binary * 10 + 2;
                            result = result / 2;
                        }
                        else if (result % 2 == 1)
                        {
                            binary = binary * 10 + 1;
                            result = result / 2;
                        }
                    }

                    while (binary != 0)
                    {
                        if (binary % 10 == 2)
                        {
                            result = result * 10;
                            binary = binary / 10;
                        }
                        else if (binary % 10 == 1)
                        {
                            result = result * 10 + 1;
                            binary = binary / 10;
                        }
                    }
                    rezultatBlock.Text = result.ToString();
                }
                if (lastRadio == 3)
                {
                    lastRadio = 4;
                    int binary = 0;
                    result = Convert.ToInt32(result);
                    int octal = 0;
                    for (int i = 1; result != 0;)
                    {
                        octal += (result % 10) * i;
                        result /= 10;
                        i *= 8;
                    }
                    result = octal;
                    for (int i = 0; result != 0; i++)
                    {
                        if (result % 2 == 0)
                        {
                            binary = binary * 10 + 2;
                            result = result / 2;
                        }
                        else if (result % 2 == 1)
                        {
                            binary = binary * 10 + 1;
                            result = result / 2;
                        }
                    }

                    while (binary != 0)
                    {
                        if (binary % 10 == 2)
                        {
                            result = result * 10;
                            binary = binary / 10;
                        }
                        else if (binary % 10 == 1)
                        {
                            result = result * 10 + 1;
                            binary = binary / 10;
                        }
                    }
                    rezultatBlock.Text = Convert.ToString(result);
                }
            }
            catch 
            {
                rezultatBlock.Text = "Number is too big for conversion";
            }
        }
    }
}
