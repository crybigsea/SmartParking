using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SmartParking.Base
{
    public class PasswordHelper
    {
        static bool _isUpdating = false;

        public static string GetPassword(DependencyObject obj)
        {
            return (string)obj.GetValue(PasswordProperty);
        }

        public static void SetPassword(DependencyObject obj, string value)
        {
            obj.SetValue(PasswordProperty, value);
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.RegisterAttached("Password", typeof(string), typeof(PasswordHelper),
                new PropertyMetadata(new PropertyChangedCallback((d, e) =>
                {
                    PasswordBox passwordBox = (PasswordBox)d;
                    passwordBox.PasswordChanged -= PasswordBox_PasswordChanged;
                    if (!_isUpdating)
                        passwordBox.Password = e.NewValue.ToString();
                    passwordBox.PasswordChanged += PasswordBox_PasswordChanged;
                })));



        public static int GetAttach(DependencyObject obj)
        {
            return (int)obj.GetValue(AttachProperty);
        }

        public static void SetAttach(DependencyObject obj, int value)
        {
            obj.SetValue(AttachProperty, value);
        }

        // Using a DependencyProperty as the backing store for Attach.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AttachProperty =
            DependencyProperty.RegisterAttached("Attach", typeof(int), typeof(PasswordHelper), new PropertyMetadata(new PropertyChangedCallback((d, e) =>
            {
                PasswordBox passwordBox = (PasswordBox)d;
                passwordBox.PasswordChanged += PasswordBox_PasswordChanged;
            })));

        private static void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox passwordBox = (PasswordBox)sender;
            _isUpdating = true;
            SetPassword(passwordBox, passwordBox.Password);
            _isUpdating = false;
        }
    }
}
