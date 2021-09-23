using HelixToolkit.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace MuEditor.Forms.FormsAdministrador
{
    /// <summary>
    /// Lógica interna para Develop.xaml
    /// </summary>
    ///


    public partial class Develop : Window
    {
        BoxVisual3D box = new();


        public Develop()
        {
            InitializeComponent();
        }

        public class rotate
        {
            public static int x = 0;
            public static int y = 0;
            public static int z = 0;
            public static int w = 0;
        }
        private void rotateTranform3D()
        {
            ObjReader CurrentHelixObjReader = new();
            Model3DGroup MyModel = CurrentHelixObjReader.Read("Models3D/Exported/" + item.Text + ".obj");
            foo.Content = MyModel;


            rotate.x = int.Parse(x.Text);
            rotate.y = int.Parse(y.Text);
            rotate.z = int.Parse(z.Text);
            rotate.w = int.Parse(w.Text);

            foo.Transform = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(0, 10, 23), 90)); // 0 10 23 175
            CameraHelper.ZoomExtents(myView.Camera, myView.Viewport, 3000);

            // myView.CameraController.CameraUpDirection = new Vector3D(1, 3, 10); // 1,3,10
            // myView.CameraController.CameraTarget = new Point3D(-1, 0, 0);
            //myView.Children.Add(box);
            /* boxcontrol.DataContext = this;
             RotateTransform3D rotateTransform3D = new(new AxisAngleRotation3D(new Vector3D(rotate.x, rotate.y, rotate.z), 0));
             rotateTransform3D.CenterX = 0;
             rotateTransform3D.CenterY = 0;
             rotateTransform3D.CenterZ = 0;
             MyModel.Transform = rotateTransform3D;*/
        }

        public double boxheigth
        {
            get { return box.Height; }
            set { box.Height = value; }
        }

        public double boxwidth
        {
            get { return box.Width; }
            set { box.Width = value; }
        }

        public double boxlength
        {
            get { return box.Length; }
            set { box.Length = value; }
        }


        public double boxX
        {
            get { return box.Center.X; }
            set { box.Center = new Point3D(value, box.Center.Y, box.Center.Z); }
        }


        public double boxY
        {
            get { return box.Center.Y; }
            set { box.Center = new Point3D(box.Center.X, value, box.Center.Z); }
        }

        public double boxZ
        {
            get { return box.Center.Z; }
            set { box.Center = new Point3D(box.Center.X, box.Center.Y, value); }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (x.Text == "")
                return;

            //rotateTranform3D();
        }

        private void y_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (y.Text == "")
                return;

            //rotateTranform3D();
        }

        private void z_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (z.Text == "")
                return;

            //rotateTranform3D();
        }

        private void w_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (w.Text == "")
                return;

            //rotateTranform3D();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            foo.Content = null;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            rotateTranform3D();
        }
    }

}
