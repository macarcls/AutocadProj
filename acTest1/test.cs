using ACadSharp.IO;
using ACadSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;
using ACadSharp.Entities;
using System.Numerics;



namespace acTest1
{
    internal class Test
    {
        public static void WriteDwg(string file, CadDocument doc)
        {
            using (DwgWriter writer = new DwgWriter(file, doc))
            {
                ACadSharp.Entities.Line lline = new ACadSharp.Entities.Line();
                new CSMath.XYZ(5,5,5);
                Line line = new(new CSMath.XYZ(5, 5, 0), new CSMath.XYZ(10, 5, 0));
                Rect3D rect3D = new Rect3D();
                rect3D.X = 10;
                rect3D.Y = 10;
                rect3D.Z = 10;
                //doc.Entities.Add(line);
                writer.Write();
            }
        }
    }
}
