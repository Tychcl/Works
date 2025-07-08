using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;

namespace CustomWindow.Controls
{
    public partial class CWWindow : System.Windows.Window
    {

        private Point positionBeforeDrag;
        private bool isMouseButtonDown;
        private Point mouseDownPosition;

        public Grid WindowRoot { get; private set; }
        public Grid LayoutRoot { get; private set; }
        public Button MinimizeButton { get; private set; }
        public Button MaximizeButton { get; private set; }
        public Button RestoreButton { get; private set; }
        public Button CloseButton { get; private set; }
        public Grid HeaderBar { get; private set; }

        public T GetRequiredTemplateChild<T>(string childName) where T : DependencyObject
        {
            return (T)base.GetTemplateChild(childName);
        }

        public override void OnApplyTemplate()
        {
            this.WindowRoot = this.GetRequiredTemplateChild<Grid>("WindowRoot");
            this.LayoutRoot = this.GetRequiredTemplateChild<Grid>("LayoutRoot");
            this.MinimizeButton = this.GetRequiredTemplateChild<System.Windows.Controls.Button>("MinimizeButton");
            this.MaximizeButton = this.GetRequiredTemplateChild<System.Windows.Controls.Button>("MaximizeButton");
            this.RestoreButton = this.GetRequiredTemplateChild<System.Windows.Controls.Button>("RestoreButton");
            this.CloseButton = this.GetRequiredTemplateChild<System.Windows.Controls.Button>("CloseButton");
            this.HeaderBar = this.GetRequiredTemplateChild<Grid>("PART_HeaderBar");


            if (this.CloseButton != null)
            {
                this.CloseButton.Click += CloseButton_Click;
            }

            if (this.MinimizeButton != null)
            {
                this.MinimizeButton.Click += MinimizeButton_Click;
            }

            if (this.RestoreButton != null)
            {
                this.RestoreButton.Click += RestoreButton_Click;
            }

            if (this.MaximizeButton != null)
            {
                this.MaximizeButton.Click += MaximizeButton_Click;
            }

            if (this.HeaderBar != null)
            {
                this.HeaderBar.AddHandler(Grid.MouseLeftButtonDownEvent, new MouseButtonEventHandler(this.OnHeaderBarMouseLeftButtonDown));
            }

            base.OnApplyTemplate();
        }

        protected void ToggleWindowState()
        {
            if (base.WindowState != WindowState.Maximized)
            {
                base.WindowState = WindowState.Maximized;
            }
            else
            {
                base.WindowState = WindowState.Normal;
            }
        }

        private void MaximizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.ToggleWindowState();
        }

        private void RestoreButton_Click(object sender, RoutedEventArgs e)
        {
            this.ToggleWindowState();
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        protected virtual void OnHeaderBarMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Point position = e.GetPosition(this);

            if (e.ClickCount == 2 && base.ResizeMode == ResizeMode.CanResize)
            {
                this.ToggleWindowState();
                return;
            }

            if (base.WindowState == WindowState.Maximized)
            {
                this.isMouseButtonDown = true;
                this.mouseDownPosition = position;
            }
            else
            {
                try
                {
                    this.positionBeforeDrag = new System.Windows.Point(base.Left, base.Top);
                    base.DragMove();
                }
                catch
                {
                }
            }
        }
    }
}
