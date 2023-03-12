﻿using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Telegram
{
    /// <summary>
    /// Interaction logic for SingUp.xaml
    /// </summary>
    public partial class SingUp : Window
    {
        private bool flag_singup = true;
        private bool flag_registration = true;
        public SingUp()
        {
            InitializeComponent();
        }

        private void SingUp_Start(object sender, RoutedEventArgs e)
        {
            StartStackPanel.Visibility = Visibility.Hidden;
            SingUpStackPanel.Visibility = Visibility.Visible;
        }

        private void ButtonShowPassword_Click(object sender, RoutedEventArgs e)
        {
            flag_singup = !flag_singup;
            TextBoxPasswordLogin.Visibility = (flag_singup) ? Visibility.Hidden : Visibility.Visible;
            PasswordBoxLogin.Visibility = (flag_singup) ? Visibility.Visible : Visibility.Hidden;
            TextBoxPasswordLogin.Text = PasswordBoxLogin.Password;
        }

        private void pbPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PlaceHolderTextBlock.Visibility = (sender as PasswordBox).Password.Length == 0 ? Visibility.Visible : Visibility.Hidden;
        }

        private void TextBoxPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            PasswordBoxLogin.Password = (sender as TextBox).Text;
        }

        private void ButtonShowPassword_Registration_Click(object sender, RoutedEventArgs e)
        {
            flag_registration = !flag_registration;
            TextBoxPasswordRegistration.Visibility = (flag_registration) ? Visibility.Hidden : Visibility.Visible;
            PasswordBoxRegistration.Visibility = (flag_registration) ? Visibility.Visible : Visibility.Hidden;
            TextBoxPasswordRegistration.Text = PasswordBoxRegistration.Password;
        }

        private void PasswordForgotPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PlaceHolderTextBlockRegistration.Visibility = (sender as PasswordBox).Password.Length == 0 ? Visibility.Visible : Visibility.Hidden;
        }

        private void TextBoxPasswordForgotPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            PasswordBoxRegistration.Password = (sender as TextBox).Text;
        }

        private void TextBlock_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            SingUpStackPanel.Visibility = Visibility.Hidden;
            ForgotPasswordStackPanel.Visibility = Visibility.Visible;
            TextBoxCode1.Focus(); // Focus Code
        }

        private void TextBoxPasswordRegistration_TextChanged(object sender, TextChangedEventArgs e)
        {
            PasswordBoxRegistration.Password = (sender as TextBox).Text;
        }

        private void PasswordBoxRegistration_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PlaceHolderTextBlockRegistration.Visibility = (sender as PasswordBox).Password.Length == 0 ? Visibility.Visible : Visibility.Hidden;
        }


        private void RegistrationPassword2_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PlaceHolderTextBlockRegistration2.Visibility = (sender as PasswordBox).Password.Length == 0 ? Visibility.Visible : Visibility.Hidden;
        }

        private void OpenRegistrationMenuButton_Click(object sender, RoutedEventArgs e)
        {
            SingUpStackPanel.Visibility = Visibility.Hidden;
            RegistrationStackPanel.Visibility = Visibility.Visible;
        }

        private void OnlyNumberPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            bool flag = regex.IsMatch(e.Text);
            e.Handled = flag;
        }
        private void TextBoxCode_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Back) return;
            if (!char.IsDigit((sender as TextBox).Text[0]))
            {
                (sender as TextBox).Text = "";
                e.Handled = true;
            }
            else
            {
                var textBox = sender as TextBox;
                if (char.IsDigit(textBox.Text[0]))
                {
                    if (textBox.Tag == null) return;
                    int.TryParse(textBox.Tag.ToString(), out int index);
                    if (index != 0)
                    {
                        if (FindName("TextBoxCode" + (++index)) is TextBox nextTextBox)
                        {
                            nextTextBox.Focus();
                            nextTextBox.SelectAll();
                            e.Handled = true;
                        }
                    }
                }
            }
        }
    }
}