using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WW.Cad.IO;
using WW.Cad.Model;
using WW.Cad.Model.Entities;
using WW.Cad.Model.Tables;
using WW.Math;

namespace WpfApp9
{
    internal class Cadlib
    {
        //  время жизни переменной
        //  private/public

        public static void WriteDwgFile()
        {
            using var outStream = new FileStream("C:\\Users\\macar\\source\\repos\\WpfApp9\\WpfApp9\\Drawing.dwg", FileMode.Create);

            DxfModel model = new DxfModel(DxfVersion.Dxf15);
            DxfCircle circle = new DxfCircle(EntityColors.Blue, new Point2D(3, 2), 2d);

            model.Entities.Add(circle);

            DxfDimension.Aligned dimension = new DxfDimension.Aligned(model.CurrentDimensionStyle);
            dimension.DimensionLineLocation = new Point3D(7, 2, 0);
            // Touches bottom side of the circle.
            dimension.ExtensionLine1StartPoint = new Point3D(3, 0, 0);
            // Touches top side of the circle.
            dimension.ExtensionLine2StartPoint = new Point3D(3, 4, 0);
            model.Entities.Add(dimension);

            DxfVPort activeViewport = DxfVPort.CreateActiveVPort();
            activeViewport.Center = new Point2D(3, 2);
            activeViewport.Height = 15;
            model.VPorts.Add(activeViewport);

            //DwgWriter.Write("Drawing.dwg", model);
            DxfWriter.Write("C:\\Users\\macar\\source\\repos\\WpfApp9\\WpfApp9\\Drawing.dwg", model);
        }
   
    }
}
