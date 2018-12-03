using Microsoft.Windows.Shell;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace UWPHost
{
    public class Window :System.Windows.Window
    {
        Window Appx_GUI;
        public Window()
        {
            Appx_GUI = this as Window;
        }
        
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            if(this.WindowState!=WindowState.Maximized)
            {
                Properties.Settings.Default.Width = this.Width;
                Properties.Settings.Default.Height = this.Height;
                Properties.Settings.Default.Left = this.Left;
                Properties.Settings.Default.Top = this.Top;
            }
            
            Properties.Settings.Default.WindowState = this.WindowState;
            Properties.Settings.Default.Save();
        }

        protected override void OnSourceInitialized(EventArgs e)
        {
            Window win = this;
            base.OnSourceInitialized(e);
            ResourceDictionary ThemeDictionary = new ResourceDictionary();
            ThemeDictionary.Source = new Uri("UWPHOST;component/Themes/Generic.xaml", UriKind.RelativeOrAbsolute);
            var style = ThemeDictionary["Generic"] as Style;
            this.Style = style;

            win.CommandBindings.Add(new CommandBinding(SystemCommands.CloseWindowCommand, new ExecutedRoutedEventHandler(closeCommand_Executed)));
            win.CommandBindings.Add(new CommandBinding(SystemCommands.MinimizeWindowCommand, new ExecutedRoutedEventHandler(minimizeWindow_Executed)));
            win.CommandBindings.Add(new CommandBinding(SystemCommands.MaximizeWindowCommand, new ExecutedRoutedEventHandler(maximizeWindow_Executed)));
            win.CommandBindings.Add(new CommandBinding(SystemCommands.RestoreWindowCommand, new ExecutedRoutedEventHandler(restoreWindow_Executed)));


            this.Width = Properties.Settings.Default.Width;
            this.Height = Properties.Settings.Default.Height;
            this.Left = Properties.Settings.Default.Left;
            this.Top = Properties.Settings.Default.Top;
            this.WindowState = Properties.Settings.Default.WindowState;

        }


    protected override void OnStateChanged(EventArgs e)
        {
            Appx_GUI = this;
            base.OnStateChanged(e);
            if (this.WindowState == WindowState.Maximized)
            {
                Grid Container = (Grid)Appx_GUI.Template.FindName("container", Appx_GUI);
                Container.Margin = new Thickness(8, 8, 8, 8);
                try
                {
                    Button btn = (Button)Appx_GUI.Template.FindName("maximize_btn", Appx_GUI);
                    TextBlock icon_max = (TextBlock)btn.Template.FindName("maximize_icon", btn);
                    TextBlock icon_res = (TextBlock)btn.Template.FindName("restore_icon", btn);
                    icon_max.Visibility = Visibility.Hidden;
                    icon_res.Visibility = Visibility.Visible;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                try
                {
                    Appx_GUI = this as UWPHost.Window;
                    Grid Container = (Grid)Appx_GUI.Template.FindName("container", Appx_GUI);
                    Container.Margin = new Thickness(1, 1, 1, 1);
                    Button btn = (Button)Container.FindName("maximize_btn");
                    TextBlock icon_max = (TextBlock)btn.Template.FindName("maximize_icon", btn);
                    TextBlock icon_res = (TextBlock)btn.Template.FindName("restore_icon", btn);
                    icon_max.Visibility = Visibility.Visible;
                    icon_res.Visibility = Visibility.Hidden;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            OnStateChanged(null);
        }

        private void closeCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Close();
        }

        private void minimizeWindow_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void restoreWindow_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.WindowState = WindowState.Normal;
        }

        private void maximizeWindow_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Appx_GUI = this;
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
                Grid Container = (Grid)Appx_GUI.Template.FindName("container", Appx_GUI);
                Container.Margin = new Thickness(1, 1, 1, 1);
                try
                {
                    Button btn = (Button)Appx_GUI.Template.FindName("maximize_btn", Appx_GUI);
                    TextBlock icon_max = (TextBlock)btn.Template.FindName("maximize_icon", btn);
                    TextBlock icon_res = (TextBlock)btn.Template.FindName("restore_icon", btn);
                    icon_max.Visibility = Visibility.Visible;
                    icon_res.Visibility = Visibility.Hidden;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                this.WindowState = WindowState.Maximized;
                Grid Container = (Grid)Appx_GUI.Template.FindName("container", Appx_GUI);
                Container.Margin = new Thickness(8, 8, 8, 8);
                try
                {
                    Button btn = (Button)Appx_GUI.Template.FindName("maximize_btn", Appx_GUI);
                    TextBlock icon_max = (TextBlock)btn.Template.FindName("maximize_icon", btn);
                    TextBlock icon_res = (TextBlock)btn.Template.FindName("restore_icon", btn);
                    icon_max.Visibility = Visibility.Hidden;
                    icon_res.Visibility = Visibility.Visible;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }



        #region Dependency Properties

        public String Theme
        {
            get { return (String)GetValue(ThemeProperty); }
            set { SetValue(ThemeProperty, value); }
        }

        public static readonly DependencyProperty ThemeProperty =
            DependencyProperty.Register("Theme", typeof(String), typeof(Window), new PropertyMetadata("Light"));





        public bool ShowTitlebar
        {
            get { return (bool)GetValue(ShowTitlebarProperty); }
            set { SetValue(ShowTitlebarProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ShowTitlebar.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ShowTitlebarProperty =
            DependencyProperty.Register("ShowTitlebar", typeof(bool), typeof(Window), new PropertyMetadata(true));


        public SolidColorBrush TitlebarBrush
        {
            get { return (SolidColorBrush)GetValue(TitlebarBrushProperty); }
            set { SetValue(TitlebarBrushProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TitlebarBrush.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitlebarBrushProperty =
            DependencyProperty.Register("TitlebarBrush", typeof(SolidColorBrush), typeof(Window), new PropertyMetadata(new SolidColorBrush(Colors.Transparent)));


        #endregion
    }
}
