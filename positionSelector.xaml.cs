using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ObjResizer
{
    /// <summary>
    /// Interaktionslogik für positionSelector.xaml
    /// </summary>
    public partial class positionSelector : UserControl
    {
        Dictionary<CorelDRAW.cdrReferencePoint, UIElement> rbAssign = new Dictionary<CorelDRAW.cdrReferencePoint, UIElement>();

        public CorelDRAW.cdrReferencePoint referencePoint
        {
            get
            {
                var sel = getSelected();
                return rbAssign.FirstOrDefault(x => x.Value == sel).Key;
            }
            set
            {
                setView(value);
            }
        }

        public positionSelector()
        {
            InitializeComponent();

            rbAssign.Add(CorelDRAW.cdrReferencePoint.cdrBottomLeft, rb_bl);
            rbAssign.Add(CorelDRAW.cdrReferencePoint.cdrBottomMiddle, rb_bc);
            rbAssign.Add(CorelDRAW.cdrReferencePoint.cdrBottomRight, rb_br);
            rbAssign.Add(CorelDRAW.cdrReferencePoint.cdrCenter, rb_mc);
            rbAssign.Add(CorelDRAW.cdrReferencePoint.cdrMiddleLeft, rb_ml);
            rbAssign.Add(CorelDRAW.cdrReferencePoint.cdrMiddleRight, rb_mr);
            rbAssign.Add(CorelDRAW.cdrReferencePoint.cdrTopLeft, rb_tl);
            rbAssign.Add(CorelDRAW.cdrReferencePoint.cdrTopMiddle, rb_tc);
            rbAssign.Add(CorelDRAW.cdrReferencePoint.cdrTopRight, rb_tr);
        }

        private void setView(CorelDRAW.cdrReferencePoint refPos)
        {
            ((RadioButton)rbAssign[refPos]).IsChecked = true;
        }

        private UIElement getSelected()
        {
            foreach (RadioButton rb in rbGrid.Children)
            {
                if (rb.IsChecked == true)
                {
                    return rb;
                }
            }
            return rb_mc;
        }
    }
}
