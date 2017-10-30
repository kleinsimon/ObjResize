using System.Windows;
using System.Windows.Controls;
using CorelDRAW;


namespace ObjResizer
{
    /// <summary>
    /// Interaktionslogik für UserControl1.xaml
    /// </summary>
    public partial class ObjResizeDock : UserControl
    {
        CorelDRAW.Application CDWin;

        public ObjResizeDock()
        {
            InitializeComponent();
        }

        public ObjResizeDock(object app)
        {
            InitializeComponent();
            CDWin = (CorelDRAW.Application)app;
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            startResize();
        }

        private void startResize()
        {
            CDWin.Application.Optimization = true;
            CDWin.ActiveDocument.BeginCommandGroup("Resize-Group");

            try
            {
                doResize();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            CDWin.ActiveWindow.Refresh();
            CDWin.Application.Refresh();

            CDWin.ActiveDocument.EndCommandGroup();
            CDWin.Application.Optimization = false;
        }

        private void doResize()
        {
            CorelDRAW.cdrReferencePoint refPoint = posSel.referencePoint;

            double scaleH = 1d;
            double scaleV = 1d;

            if (!double.TryParse(newWidthValue.Text, out scaleH) || !double.TryParse(newHeightValue.Text, out scaleV))
            {
                return;
            }

            scaleH = scaleH / 100;
            scaleV = scaleV / 100;

            foreach (Shape sh in CDWin.ActiveSelection.Shapes)
            {
                double ow = sh.SizeWidth;
                double oh = sh.SizeHeight;

                double nw = ow * scaleH;
                double nh = oh * scaleV;

                double ox = 0d;
                double oy = 0d;

                sh.GetPositionEx(refPoint, out ox, out oy);
                sh.SetSize(nw, nh);
                sh.SetPositionEx(refPoint, ox, oy);

            }
        }

        private void AboutButton_Click(object sender, RoutedEventArgs e)
        {
            about tmp = new about();
            tmp.ShowDialog();
        }
    }
}
