/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using netDxf.Entities;
using netDxf;
using System.Windows.Controls;
using netDxf.Objects;
using netDxf.Tables;
using netDxf.Collections;
using netDxf.GTE;
using netDxf.Blocks;

namespace acTest2
{
    internal class HookObj
    {
        public static void Hook(int x, int y, int z, int peregor)
        {
            string file = "C:\\Users\\macar\\source\\repos\\WpfApp9\\acTest2\\test.dxf";
            netDxf.DxfDocument dxf = new netDxf.DxfDocument();
            List<int[]> hookFaces = new List<int[]>()
            {
                new[] {0,1,2,3},
                new[] {4,5,6,7},
                new[] {0,1,5,4},
                new[] {2,3,7,6},
                new[] {0,3,15,12},
                new[] {1,2,14,13 },
                new[] {4,7,11,8 },
                new[] {5,6,10,9 },
                new[] {8,9,10,11 },
                new[] {0,4,8,12 },
                new[] {1,5,9,13 },
                new[] {2,6,10,14 },
                new[] {3,7,11,15 },
                new[] {8,9,13,12 },
                new[] {10,11,15,14 },
                new[] {12,13,14,15 },
                
            };
            List<MeshEdge> edge = new List<MeshEdge>()
            { 
                 new MeshEdge(0,1,-1.0),//1 Top
                 new MeshEdge(1,2,-1.0),
                 new MeshEdge(2,3,-1.0),
                 new MeshEdge(3,0,-1.0),//
                 new MeshEdge(4,5,-1.0),//2
                 new MeshEdge(5,6,-1.0),
                 new MeshEdge(6,7,-1.0),
                 new MeshEdge(7,4,-1.0),//
                 new MeshEdge(8,9,-1.0),//3
                 new MeshEdge(9,10,-1.0),
                 new MeshEdge(10,11,-1.0),
                 new MeshEdge(11,8,-1.0),//
                 new MeshEdge(12,13,-1.0),//4
                 new MeshEdge(13,14,-1.0),
                 new MeshEdge(14,15,-1.0),
                 new MeshEdge(15,12,-1.0),//
                 new MeshEdge(0,12,-1.0),//1 Sides
                 new MeshEdge(1,13,-1.0),
                 new MeshEdge(2,14,-1.0),
                 new MeshEdge(3,15,-1.0),//
                 new MeshEdge(4,8,-1.0),// 2 
                 new MeshEdge(5,9,-1.0),
                 new MeshEdge(6,10,-1.0),
                 new MeshEdge(7,11,-1.0),//
                 new MeshEdge(0,4,-1.0),// 3 
                 new MeshEdge(1,5,-1.0),
                 new MeshEdge(2,6,-1.0),
                 new MeshEdge(3,7,-1.0),//
                 new MeshEdge(8,12,-1.0),//4
                 new MeshEdge(9,13,-1.0),
                 new MeshEdge(10,14,-1.0),
                 new MeshEdge(11,15,-1.0)//

            };
            var Hook = new Mesh(new List<Vector3> { new Vector3(x / 3, (y / 2) + 10, z), // 0
                                                    new Vector3(x/3, (y / 2) - 10, z), // 1
                                                    new Vector3((x/3)-5,(y/2)-10,z), // 2
                                                    new Vector3((x/3)-5,(y/2)+10,z), // 3
                                                    new Vector3(x / 3, (y / 2) + 5, z+5), // 4
                                                    new Vector3(x / 3, (y / 2) - 5, z+5), // 5
                                                    new Vector3((x / 3) - 5, (y / 2) - 5, z+5), // 6
                                                    new Vector3((x / 3) - 5, (y / 2) + 5, z+5), // 7
                                                    new Vector3(x / 3, (y / 2) + 5, z+15), // 8
                                                    new Vector3(x / 3, (y / 2) - 5, z+15), // 9
                                                    new Vector3((x / 3) - 5, (y / 2) - 5, z+15), // 10
                                                    new Vector3((x / 3) - 5, (y / 2) + 5, z+15), // 11
                                                    new Vector3(x / 3, (y / 2) + 10, z+20), // 12
                                                    new Vector3(x / 3, (y / 2) - 10, z+20), // 13
                                                    new Vector3((x / 3) - 5, (y / 2) - 10, z+20), // 14
                                                    new Vector3((x / 3) - 5, (y / 2) + 10, z+20) // 15
                                                    }, hookFaces );

            Hook.SubdivisionLevel = 5;
            dxf.Entities.Add(Hook);
            Circle circle = new Circle(new Vector3(0,0,0), 10);
            Circle circle1 = new Circle(new Vector3(0,0,5), 5);
            ///
            // колпачёк
            List<int[]> faces1 = new List<int[]>
            {
                new[] {0, 1, 9, 8},
                new[] {1, 2, 10, 9},
                new[] {2, 3, 11, 10},
                new[] {3, 4, 12, 11},
                new[] {4, 5, 13, 12},
                new[] {5, 6, 14, 13},
                new[] {6, 7, 15, 14},
                new[] {7, 0, 8, 15},
                new[] {0,1,2,3,4,5,6,7},
                new[] {8,9,10,11,12,13,14,15},
                new[] {16, 17, 19, 18},
                new[] {20, 21, 23, 22},
                new[] {16, 17, 21, 20},
                new[] {18, 19, 23, 22},
                new[] {17, 19, 23, 21},
                new[] {16, 18, 22, 20}
            };
            List<MeshEdge> edges = new List<MeshEdge>
            {
                new MeshEdge(0, 1, -1.0),
                new MeshEdge(1, 2, -1.0),
                new MeshEdge(2, 3, -1.0),
                new MeshEdge(3, 4, -1.0),
                new MeshEdge(4, 5, -1.0),
                new MeshEdge(5, 6, -1.0),
                new MeshEdge(6, 7, -1.0),
                new MeshEdge(7, 0, -1.0),
                new MeshEdge(8, 9, -1.0),
                new MeshEdge(9, 10, -1.0),
                new MeshEdge(10, 11, -1.0),
                new MeshEdge(11, 12, -1.0),
                new MeshEdge(12, 13, -1.0),
                new MeshEdge(13, 14, -1.0),
                new MeshEdge(14, 15, -1.0),
                new MeshEdge(15, 8, -1.0),
                new MeshEdge(0, 8, -1.0),
                new MeshEdge(1, 9, -1.0),
                new MeshEdge(2, 10, -1.0),
                new MeshEdge(3, 11, -1.0),
                new MeshEdge(4, 12, -1.0),
                new MeshEdge(5, 13, -1.0),
                new MeshEdge(6, 14, -1.0),
                new MeshEdge(7, 15, -1.0),
                new MeshEdge(16, 17, -1.0),//
                new MeshEdge(17, 19, -1.0),
                new MeshEdge(19, 18, -1.0),
                new MeshEdge(18, 16, -1.0),//
                new MeshEdge(20, 21),//
                new MeshEdge(21, 22),
                new MeshEdge(22, 23),
                new MeshEdge(23, 20),//
                new MeshEdge(16, 20),//
                new MeshEdge(17, 21),
                new MeshEdge(18, 22),
                new MeshEdge(19, 23),//
            };
            netDxf.Entities.Mesh bolty = new(new List<Vector3> {
                new Vector3(-80, (x/2)-15,z - ((z / (peregor+1))/2)),//0
                new Vector3(-80,(x/2)-15/Math.Sqrt(2),(z - ((z / (peregor+1))/2))+15/Math.Sqrt(2)),//1
                new Vector3(-80, x / 2, (z - ((z / (peregor + 1))/2)) + 15),//2
                new Vector3(-80,(x/2)+15/Math.Sqrt(2),(z - ((z / (peregor + 1))/2))+15/Math.Sqrt(2)),//3
                new Vector3(-80, (x / 2) + 15,(z - ((z / (peregor + 1))/2))),//4
                new Vector3(-80,(x/2)+15/Math.Sqrt(2),(z - ((z / (peregor + 1))/2))-15/Math.Sqrt(2)),//5
                new Vector3(-80, x / 2, (z - ((z / (peregor + 1))/2)) - 15),//6
                new Vector3(-80,(x/2)-15/Math.Sqrt(2),(z - ((z / (peregor + 1))/2))-15/Math.Sqrt(2)),//7
            // long side
                new Vector3(-100, (x/2)-15, (z - ((z / (peregor + 1))/2))),//8
                new Vector3(-100,(x/2)-15/Math.Sqrt(2),(z - ((z / (peregor + 1))/2))+15/Math.Sqrt(2)),//9
                new Vector3(-100, x / 2, (z - ((z / (peregor + 1))/2)) + 15),//10
                new Vector3(-100,(x/2)+15/Math.Sqrt(2),(z - ((z / (peregor + 1))/2))+15/Math.Sqrt(2)),//11
                new Vector3(-100, (x / 2) + 15, (z - ((z / (peregor + 1))/2))),//12
                new Vector3(-100, (x / 2) +15 / Math.Sqrt(2),(z - ((z / (peregor + 1))/2))-15/Math.Sqrt(2)),//13
                new Vector3(-100, x / 2, (z - ((z / (peregor + 1))/2)) - 15),//14
                new Vector3(-100, (x / 2) -15 / Math.Sqrt(2),(z - ((z / (peregor + 1))/2))-15/Math.Sqrt(2)),//15
            // kolpak
                new Vector3(-100,(x/2)-7.5, z - ((z / (peregor+1))/2)+7.5), //16
                new Vector3(-100,(x/2)-7.5,z - ((z / (peregor+1))/2)-7.5), //17
                new Vector3(-100,(x/2)+7.5,z - ((z / (peregor+1))/2)+7.5), //18
                new Vector3(-100,(x/2)+7.5,z - ((z / (peregor+1))/2)-7.5), //19
                new Vector3(-112,(x/2)-7.5,z - ((z / (peregor+1))/2)+7.5), //20
                new Vector3(-112,(x/2)-7.5,z - ((z / (peregor+1))/2)-7.5), //21
                new Vector3(-112,(x/2)+7.5,z - ((z / (peregor+1))/2)+7.5), //22
                new Vector3(-112,(x/2)+7.5,z - ((z / (peregor+1))/2)-7.5), //23
                }, faces1, edges);
            bolty.SubdivisionLevel = 5;
            //dxf.Entities.Add(bolty);
            List<Vector3> vertexes = new List<Vector3>
            {
                new Vector3(-5, -5, -5), //0
                new Vector3(5, -5, -5), //1
                new Vector3(5, 5, -5), //2
                new Vector3(-5, 5, -5), //3
                new Vector3(-5, -5, 5), //4
                new Vector3(5, -5, 5),//5
                new Vector3(5, 5, 5),//6
                new Vector3(-5, 5, 5)//7
            };

            //6 faces
            List<int[]> faces = new List<int[]>
            {
                new[] {0, 3, 2, 1},
                new[] {0, 1, 5, 4},
                new[] {1, 2, 6, 5},
                new[] {2, 3, 7, 6},
                new[] {0, 4, 7, 3},
                new[] {4, 5, 6, 7}
            };


            // the list of edges is optional and only really needed when applying creases values to them
            // crease negative values will sharpen the edge independently of the subdivision level. Any negative crease value will be reseted as -1.
            // by default edge creases are set to 0.0 (no edge sharpening)
            List<MeshEdge> edges2 = new List<MeshEdge>
            {
                new MeshEdge(0, 1),
                new MeshEdge(1, 2),
                new MeshEdge(2, 3),
                new MeshEdge(3, 0),
                new MeshEdge(4, 5, -1.0),
                new MeshEdge(5, 6, -1.0),
                new MeshEdge(6, 7, -1.0),
                new MeshEdge(7, 4, -1.0),
                new MeshEdge(0, 4),
                new MeshEdge(1, 5),
                new MeshEdge(2, 6),
                new MeshEdge(3, 7)
            };
            Mesh mesh = new Mesh(vertexes, faces, edges);
            ApplicationRegistry newAppReg = dxf.ApplicationRegistries.Add(new ApplicationRegistry("netDxf"));
            mesh.SubdivisionLevel = 3;
            XData xdata = new XData(newAppReg);
            xdata.XDataRecord.Add(new XDataRecord(XDataCode.String, "xdata string sample"));
            xdata.XDataRecord.Add(new XDataRecord(XDataCode.Int32, 50000));
            mesh.XData.Add(xdata);
            //dxf.Entities.Add(mesh);
            // разметочка
            ///
            DimensionStyle style = DimensionStyle.Iso25;
            ///
            

            // save
            dxf.Save(file);
        }
    }
}
*/