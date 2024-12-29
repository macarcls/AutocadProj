using netDxf;
using netDxf.Blocks;
using netDxf.Entities;
using netDxf.Objects;
using netDxf.Tables;
using System.IO;

namespace acTest2
{
    internal class Graphic
    {
        public int x { get; set; }
        public int y { get; set; } 
        public int nozzle_d { get; set; } 
        public int peregor_hot { get; set; }
        public int peregor_cold { get; set; }
        public int cold_side_count_of_nozzles { get; set; } 
        public int Hot_side_count_of_nozzles { get; set; }
        public int count_pl { get; set; }
        public void create_V()
        {
            // your DXF file name
            string file = "C:\\Users\\macar\\source\\repos\\WpfApp9\\acTest2\\sample1.dxf";

            // create a new document, by default it will create an AutoCad2000 DXF version
            DxfDocument doc = new DxfDocument();
            //var layout = new Layout("layout");
            //layout.BasePoint = new Vector3(0, 0, 0);
            //doc.Layouts.Add(layout);
            //doc.Entities.ActiveLayout = layout.Name;
            int z = count_pl + (count_pl * 5) + (80 * 2);
            // Hook:
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
            var Hook = new Mesh(new List<Vector3> { new Vector3(x / 3, (y / 2) + 20, z), // 0
                                                    new Vector3(x/3, (y / 2) - 20, z), // 1
                                                    new Vector3((x/3)-10,(y/2)-20,z), // 2
                                                    new Vector3((x/3)-10,(y/2)+20,z), // 3
                                                    new Vector3(x / 3, (y / 2) + 10, z+5), // 4
                                                    new Vector3(x / 3, (y / 2) - 10, z+5), // 5
                                                    new Vector3((x / 3) - 10, (y / 2) - 10, z+10), // 6
                                                    new Vector3((x / 3) - 10, (y / 2) + 10, z+10), // 7
                                                    new Vector3(x / 3, (y / 2) + 10, z+30), // 8
                                                    new Vector3(x / 3, (y / 2) - 10, z+30), // 9
                                                    new Vector3((x / 3) - 10, (y / 2) - 10, z+30), // 10
                                                    new Vector3((x / 3) - 10, (y / 2) + 10, z+30), // 11
                                                    new Vector3(x / 3, (y / 2) + 20, z+40), // 12
                                                    new Vector3(x / 3, (y / 2) - 20, z+40), // 13
                                                    new Vector3((x / 3) - 10, (y / 2) - 20, z+40), // 14
                                                    new Vector3((x / 3) - 10, (y / 2) + 20, z+40) // 15
                                                    }, hookFaces);

            Hook.SubdivisionLevel = 5;
            var Hook2 = (Mesh)Hook.Clone();
            Hook2.TransformBy(Matrix4.Translation(x / 3, 0, 0));      
            doc.Entities.Add(Hook);
            doc.Entities.Add(Hook2);
            // Walls:
            List<int[]> faces = new List<int[]>
            {
                new[] {0, 3, 2, 1},
                new[] {0, 1, 5, 4},
                new[] {1, 2, 6, 5},
                new[] {2, 3, 7, 6},
                new[] {0, 4, 7, 3},
                new[] {4, 5, 6, 7}
            };
            Layer Walls = new("Walls");
            Walls.Color = AciColor.DarkGray;
            netDxf.Entities.Mesh mesh = new Mesh(new List<Vector3> {new Vector3(0,0,0), new Vector3(0,y,0), new Vector3(-80,y,0), new Vector3(-80,0,0), new Vector3(0,0,z), new Vector3(0,y,z),new Vector3(-80,y,z),new Vector3(-80,0,z)}, faces);
            netDxf.Entities.Mesh mesh1 = new(new List<Vector3> { new Vector3(0, 0, 0), new Vector3(x, 0, 0), new Vector3(x, -80, 0), new Vector3(0, -80, 0), new Vector3(0, 0, z), new Vector3(x, 0, z), new Vector3(x, -80, z), new Vector3(0, -80, z) }, faces);
            netDxf.Entities.Mesh mesh2 = new(new List<Vector3> { new Vector3(0, y, 0), new Vector3(0, y+80, 0), new Vector3(x, y+80, 0), new Vector3(x, y, 0), new Vector3(0, y, z), new Vector3(0, y+80, z), new Vector3(x, y+80, z), new Vector3(x, y, z) }, faces);
            netDxf.Entities.Mesh mesh3 = new(new List<Vector3> { new Vector3(x, y, 0), new Vector3(x+80, y, 0), new Vector3(x+80, 0, 0), new Vector3(x, 0, 0), new Vector3(x, y, z), new Vector3(x+80, y, z), new Vector3(x+80, 0, z), new Vector3(x, 0, z) }, faces);
            netDxf.Entities.Mesh top_mesh = new(new List<Vector3> { new Vector3(0, 0, z), new Vector3(0, y, z), new Vector3(x, y, z), new Vector3(x, 0, z), new Vector3(0, 0, z-80), new Vector3(0, y, z-80), new Vector3(x, y, z-80), new Vector3(x, 0, z-80) }, faces);
            netDxf.Entities.Mesh bot_mesh = new(new List<Vector3> { new Vector3(0, 0, 0), new Vector3(0, y, 0), new Vector3(x, y, 0), new Vector3(x, 0, 0), new Vector3(0, 0, 80), new Vector3(0, y, 80), new Vector3(x, y, 80), new Vector3(x, 0, 80) }, faces);
            mesh.Layer = Walls;
            mesh1.Layer = Walls;
            mesh2.Layer = Walls;
            mesh3.Layer = Walls;
            top_mesh.Layer = Walls;
            bot_mesh.Layer = Walls;
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
            List<MeshEdge> edges2 = new List<MeshEdge>
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
                new Vector3(-80, (x/2)-15,z - ((z / (peregor_hot+1))/2)),//0
                new Vector3(-80,(x/2)-15/Math.Sqrt(2),(z - ((z / (peregor_hot+1))/2))+15/Math.Sqrt(2)),//1
                new Vector3(-80, x / 2, (z - ((z / (peregor_hot + 1))/2)) + 15),//2
                new Vector3(-80,(x/2)+15/Math.Sqrt(2),(z - ((z / (peregor_hot + 1))/2))+15/Math.Sqrt(2)),//3
                new Vector3(-80, (x / 2) + 15,(z - ((z / (peregor_hot + 1))/2))),//4
                new Vector3(-80,(x/2)+15/Math.Sqrt(2),(z - ((z / (peregor_hot + 1))/2))-15/Math.Sqrt(2)),//5
                new Vector3(-80, x / 2, (z - ((z / (peregor_hot + 1))/2)) - 15),//6
                new Vector3(-80,(x/2)-15/Math.Sqrt(2),(z - ((z / (peregor_hot + 1))/2))-15/Math.Sqrt(2)),//7
            // long side
                new Vector3(-100, (x/2)-15, (z - ((z / (peregor_hot + 1))/2))),//8
                new Vector3(-100,(x/2)-15/Math.Sqrt(2),(z - ((z / (peregor_hot + 1))/2))+15/Math.Sqrt(2)),//9
                new Vector3(-100, x / 2, (z - ((z / (peregor_hot + 1))/2)) + 15),//10
                new Vector3(-100,(x/2)+15/Math.Sqrt(2),(z - ((z / (peregor_hot + 1))/2))+15/Math.Sqrt(2)),//11
                new Vector3(-100, (x / 2) + 15, (z - ((z / (peregor_hot + 1))/2))),//12
                new Vector3(-100, (x / 2) +15 / Math.Sqrt(2),(z - ((z / (peregor_hot + 1))/2))-15/Math.Sqrt(2)),//13
                new Vector3(-100, x / 2, (z - ((z / (peregor_hot + 1))/2)) - 15),//14
                new Vector3(-100, (x / 2) -15 / Math.Sqrt(2),(z - ((z / (peregor_hot + 1))/2))-15/Math.Sqrt(2)),//15
            // kolpak
                new Vector3(-100,(x/2)-7.5, z - ((z / (peregor_hot+1))/2)+7.5), //16
                new Vector3(-100,(x/2)-7.5,z - ((z / (peregor_hot+1))/2)-7.5), //17
                new Vector3(-100,(x/2)+7.5,z - ((z / (peregor_hot+1))/2)+7.5), //18
                new Vector3(-100,(x/2)+7.5,z - ((z / (peregor_hot+1))/2)-7.5), //19
                new Vector3(-112,(x/2)-7.5,z - ((z / (peregor_hot+1))/2)+7.5), //20
                new Vector3(-112,(x/2)-7.5,z - ((z / (peregor_hot+1))/2)-7.5), //21
                new Vector3(-112,(x/2)+7.5,z - ((z / (peregor_hot+1))/2)+7.5), //22
                new Vector3(-112,(x/2)+7.5,z - ((z / (peregor_hot+1))/2)-7.5), //23
                }, faces1, edges);
            netDxf.Entities.Mesh bolty2 = new(new List<Vector3> {
                new Vector3(80, (x/2)-15,z - ((z / (peregor_hot+1))/2)),//0
                new Vector3(80,(x/2)-15/Math.Sqrt(2),(z - ((z / (peregor_hot+1))/2))+15/Math.Sqrt(2)),//1
                new Vector3(80, x / 2, (z - ((z / (peregor_hot + 1))/2)) + 15),//2
                new Vector3(80,(x/2)+15/Math.Sqrt(2),(z - ((z / (peregor_hot + 1))/2))+15/Math.Sqrt(2)),//3
                new Vector3(80, (x / 2) + 15,(z - ((z / (peregor_hot + 1))/2))),//4
                new Vector3(80,(x/2)+15/Math.Sqrt(2),(z - ((z / (peregor_hot + 1))/2))-15/Math.Sqrt(2)),//5
                new Vector3(80, x / 2, (z - ((z / (peregor_hot + 1))/2)) - 15),//6
                new Vector3(80,(x/2)-15/Math.Sqrt(2),(z - ((z / (peregor_hot + 1))/2))-15/Math.Sqrt(2)),//7
            // long side
                new Vector3(100, (x/2)-15, (z - ((z / (peregor_hot + 1))/2))),//8
                new Vector3(100,(x/2)-15/Math.Sqrt(2),(z - ((z / (peregor_hot + 1))/2))+15/Math.Sqrt(2)),//9
                new Vector3(100, x / 2, (z - ((z / (peregor_hot + 1))/2)) + 15),//10
                new Vector3(100,(x/2)+15/Math.Sqrt(2),(z - ((z / (peregor_hot + 1))/2))+15/Math.Sqrt(2)),//11
                new Vector3(100, (x / 2) + 15, (z - ((z / (peregor_hot + 1))/2))),//12
                new Vector3(100, (x / 2) +15 / Math.Sqrt(2),(z - ((z / (peregor_hot + 1))/2))-15/Math.Sqrt(2)),//13
                new Vector3(100, x / 2, (z - ((z / (peregor_hot + 1))/2)) - 15),//14
                new Vector3(100, (x / 2) -15 / Math.Sqrt(2),(z - ((z / (peregor_hot + 1))/2))-15/Math.Sqrt(2)),//15
            // kolpak
                new Vector3(100,(x/2)-7.5, z - ((z / (peregor_hot+1))/2)+7.5), //16
                new Vector3(100,(x/2)-7.5,z - ((z / (peregor_hot+1))/2)-7.5), //17
                new Vector3(100,(x/2)+7.5,z - ((z / (peregor_hot+1))/2)+7.5), //18
                new Vector3(100,(x/2)+7.5,z - ((z / (peregor_hot+1))/2)-7.5), //19
                new Vector3(112,(x/2)-7.5,z - ((z / (peregor_hot+1))/2)+7.5), //20
                new Vector3(112,(x/2)-7.5,z - ((z / (peregor_hot+1))/2)-7.5), //21
                new Vector3(112,(x/2)+7.5,z - ((z / (peregor_hot+1))/2)+7.5), //22
                new Vector3(112,(x/2)+7.5,z - ((z / (peregor_hot+1))/2)-7.5), //23
                }, faces1, edges);
            bolty2.SubdivisionLevel = 5;
            bolty.SubdivisionLevel = 5;
            bolty.TransformBy(Matrix4.Translation(0, (y / 2) - 30, -((z - ((z / (peregor_hot + 1)) / 2))) + 40));
            
            bolty2.TransformBy(Matrix4.Translation(x, (y / 2) - 30, -((z - ((z / (peregor_hot + 1)) / 2))) + 40));
            //doc.Entities.Add(bolt2);
            //bolt;
             for (int i = 1;i < z/80; i++)
             {
                 var boltn = (Mesh)bolty.Clone();
                 boltn.TransformBy(Matrix4.Translation(0, 0, i * 80));
                 doc.Entities.Add(boltn);
             }
             for (int i = 1; i < (x-80) / 80; i++)
             {
                 var boltn = (Mesh)bolty.Clone();
                 boltn.TransformBy(Matrix4.Translation(0, -(i * 80), 0));
                 doc.Entities.Add(boltn);
             }
             for (int i = 1; i < z / 80; i++)
             {
                 var boltn = (Mesh)bolty.Clone();
                 boltn.TransformBy(Matrix4.Translation(0, -(((y / 2) - 30)*2), i*80));
                 doc.Entities.Add(boltn);
             }
             for (int i = 1; i< (x-80) / 80; i++)
             {
                 var boltn = (Mesh)bolty.Clone();
                 boltn.TransformBy(Matrix4.Translation(0, -(i * 80), z - 80));
                 doc.Entities.Add(boltn);
             }
             //bolt2
             for (int i = 1; i < z / 80; i++)
             {
                 var boltn = (Mesh)bolty2.Clone();
                 boltn.TransformBy(Matrix4.Translation(0, 0, i * 80));
                 doc.Entities.Add(boltn);
             }
             for (int i = 1; i < (x - 80) / 80; i++)
             {
                 var boltn = (Mesh)bolty2.Clone();
                 boltn.TransformBy(Matrix4.Translation(0, -(i * 80), 0));
                 doc.Entities.Add(boltn);
             }
             for (int i = 1; i < z / 80; i++)
             {
                 var boltn = (Mesh)bolty2.Clone();
                 boltn.TransformBy(Matrix4.Translation(0, -(((y / 2) - 30) * 2), i * 80));
                 doc.Entities.Add(boltn);
             }
             for (int i = 1; i < (x - 80) / 80; i++)
             {
                 var boltn = (Mesh)bolty2.Clone();
                 boltn.TransformBy(Matrix4.Translation(0, -(i * 80), z - 80));
                 doc.Entities.Add(boltn);
             }
            //x side
            
            netDxf.Entities.Mesh boltx = new(new List<Vector3> {
                new Vector3((x/2)-15, -80,z - ((z / (peregor_hot+1))/2)),//0
                new Vector3((x/2)-15/Math.Sqrt(2),-80,(z - ((z / (peregor_hot+1))/2))+15/Math.Sqrt(2)),//1
                new Vector3(x / 2, -80, (z - ((z / (peregor_hot + 1))/2)) + 15),//2
                new Vector3((x/2)+15/Math.Sqrt(2),-80,(z - ((z / (peregor_hot + 1))/2))+15/Math.Sqrt(2)),//3
                new Vector3((x / 2) + 15, -80,(z - ((z / (peregor_hot + 1))/2))),//4
                new Vector3((x/2)+15/Math.Sqrt(2),-80,(z - ((z / (peregor_hot + 1))/2))-15/Math.Sqrt(2)),//5
                new Vector3(x / 2, -80, (z - ((z / (peregor_hot + 1))/2)) - 15),//6
                new Vector3((x/2)-15/Math.Sqrt(2),-80,(z - ((z / (peregor_hot + 1))/2))-15/Math.Sqrt(2)),//7
            // long side
                new Vector3((x/2)-15, -100, (z - ((z / (peregor_hot + 1))/2))),//8
                new Vector3((x/2)-15/Math.Sqrt(2),-100,(z - ((z / (peregor_hot + 1))/2))+15/Math.Sqrt(2)),//9
                new Vector3(x / 2, -100, (z - ((z / (peregor_hot + 1))/2)) + 15),//10
                new Vector3((x/2)+15/Math.Sqrt(2),-100,(z - ((z / (peregor_hot + 1))/2))+15/Math.Sqrt(2)),//11
                new Vector3((x / 2) + 15, -100, (z - ((z / (peregor_hot + 1))/2))),//12
                new Vector3((x / 2) +15 / Math.Sqrt(2), -100,(z - ((z / (peregor_hot + 1))/2))-15/Math.Sqrt(2)),//13
                new Vector3(x / 2, -100, (z - ((z / (peregor_hot + 1))/2)) - 15),//14
                new Vector3((x / 2) -15 / Math.Sqrt(2), -100,(z - ((z / (peregor_hot + 1))/2))-15/Math.Sqrt(2)),//15
            // kolpak
                new Vector3((x/2)-7.5,-100, z - ((z / (peregor_hot+1))/2)+7.5), //16
                new Vector3((x/2)-7.5,-100,z - ((z / (peregor_hot+1))/2)-7.5), //17
                new Vector3((x/2)+7.5,-100,z - ((z / (peregor_hot+1))/2)+7.5), //18
                new Vector3((x/2)+7.5,-100,z - ((z / (peregor_hot+1))/2)-7.5), //19
                new Vector3((x/2)-7.5,-112,z - ((z / (peregor_hot+1))/2)+7.5), //20
                new Vector3((x/2)-7.5,-112,z - ((z / (peregor_hot+1))/2)-7.5), //21
                new Vector3((x/2)+7.5,-112,z - ((z / (peregor_hot+1))/2)+7.5), //22
                new Vector3((x/2)+7.5,-112,z - ((z / (peregor_hot+1))/2)-7.5), //23
                }, faces1, edges);
            netDxf.Entities.Mesh boltx2 = new(new List<Vector3> {
                new Vector3((x/2)-15, 80,z - ((z / (peregor_hot+1))/2)),//0
                new Vector3((x/2)-15/Math.Sqrt(2),80,(z - ((z / (peregor_hot+1))/2))+15/Math.Sqrt(2)),//1
                new Vector3(x / 2, 80, (z - ((z / (peregor_hot + 1))/2)) + 15),//2
                new Vector3((x/2)+15/Math.Sqrt(2),80,(z - ((z / (peregor_hot + 1))/2))+15/Math.Sqrt(2)),//3
                new Vector3((x / 2) + 15, 80,(z - ((z / (peregor_hot + 1))/2))),//4
                new Vector3((x/2)+15/Math.Sqrt(2),80,(z - ((z / (peregor_hot + 1))/2))-15/Math.Sqrt(2)),//5
                new Vector3(x / 2, 80, (z - ((z / (peregor_hot + 1))/2)) - 15),//6
                new Vector3((x/2)-15/Math.Sqrt(2),80,(z - ((z / (peregor_hot + 1))/2))-15/Math.Sqrt(2)),//7
            // long side
                new Vector3((x/2)-15, 100, (z - ((z / (peregor_hot + 1))/2))),//8
                new Vector3((x/2)-15/Math.Sqrt(2),100,(z - ((z / (peregor_hot + 1))/2))+15/Math.Sqrt(2)),//9
                new Vector3(x / 2, 100, (z - ((z / (peregor_hot + 1))/2)) + 15),//10
                new Vector3((x/2)+15/Math.Sqrt(2),100,(z - ((z / (peregor_hot + 1))/2))+15/Math.Sqrt(2)),//11
                new Vector3((x / 2) + 15, 100, (z - ((z / (peregor_hot + 1))/2))),//12
                new Vector3((x / 2) +15 / Math.Sqrt(2), 100,(z - ((z / (peregor_hot + 1))/2))-15/Math.Sqrt(2)),//13
                new Vector3(x / 2, 100, (z - ((z / (peregor_hot + 1))/2)) - 15),//14
                new Vector3((x / 2) -15 / Math.Sqrt(2), 100,(z - ((z / (peregor_hot + 1))/2))-15/Math.Sqrt(2)),//15
            // kolpak
                new Vector3((x/2)-7.5,100, z - ((z / (peregor_hot+1))/2)+7.5), //16
                new Vector3((x/2)-7.5,100,z - ((z / (peregor_hot+1))/2)-7.5), //17
                new Vector3((x/2)+7.5,100,z - ((z / (peregor_hot+1))/2)+7.5), //18
                new Vector3((x/2)+7.5,100,z - ((z / (peregor_hot+1))/2)-7.5), //19
                new Vector3((x/2)-7.5,112,z - ((z / (peregor_hot+1))/2)+7.5), //20
                new Vector3((x/2)-7.5,112,z - ((z / (peregor_hot+1))/2)-7.5), //21
                new Vector3((x/2)+7.5,112,z - ((z / (peregor_hot+1))/2)+7.5), //22
                new Vector3((x/2)+7.5,112,z - ((z / (peregor_hot+1))/2)-7.5), //23
                }, faces1, edges);
            boltx.SubdivisionLevel = 5;
            boltx.TransformBy(Matrix4.Translation((y / 2) - 30, 0, -((z - ((z / (peregor_hot + 1)) / 2))) + 40));
            boltx2.SubdivisionLevel = 5;

            boltx2.TransformBy(Matrix4.Translation((y / 2) - 30, x , -((z - ((z / (peregor_hot + 1)) / 2))) + 40));
            //bolt
            for (int i = 1; i < z / 80; i++)
            {
                var boltn = (Mesh)boltx.Clone();
                boltn.TransformBy(Matrix4.Translation(0, 0, i * 80));
                doc.Entities.Add(boltn);
            }
            for (int i = 1; i < (x - 80) / 80; i++)
            {
                var boltn = (Mesh)boltx.Clone();
                boltn.TransformBy(Matrix4.Translation(-(i * 80), 0, 0));
                doc.Entities.Add(boltn);
            }
            for (int i = 1; i < z / 80; i++)
            {
                var boltn = (Mesh)boltx.Clone();
                boltn.TransformBy(Matrix4.Translation(-(((y / 2) - 30) * 2), 0, i * 80));
                doc.Entities.Add(boltn);
            }
            for (int i = 1; i < (x - 80) / 80; i++)
            {
                var boltn = (Mesh)boltx.Clone();
                boltn.TransformBy(Matrix4.Translation(-(i * 80), 0, z - 80));
                doc.Entities.Add(boltn);
            }

            //bolt2
            for (int i = 1; i < z / 80; i++)
            {
                var boltn = (Mesh)boltx2.Clone();
                boltn.TransformBy(Matrix4.Translation(0, 0, i * 80));
                doc.Entities.Add(boltn);
            }
            for (int i = 1; i < (x - 80) / 80; i++)
            {
                var boltn = (Mesh)boltx2.Clone();
                boltn.TransformBy(Matrix4.Translation(-(i * 80), 0, 0));
                doc.Entities.Add(boltn);
            }
            for (int i = 1; i < z / 80; i++)
            {
                var boltn = (Mesh)boltx2.Clone();
                boltn.TransformBy(Matrix4.Translation(-(((y / 2) - 30) * 2), 0, i * 80));
                doc.Entities.Add(boltn);
            }
            for (int i = 1; i < (x - 80) / 80; i++)
            {
                var boltn = (Mesh)boltx2.Clone();
                boltn.TransformBy(Matrix4.Translation(-(i * 80), 0, z - 80));
                doc.Entities.Add(boltn);
            }

            // nozzles cold
            ///
            Circle circle = new Circle(new Vector3(0, 0, 0), nozzle_d / 2);
            Circle circle1 = new Circle(new Vector3(0, 0, 0), nozzle_d / 2 + 20);
            circle.Thickness = 120;
            circle1.Thickness = 20;
            circle.TransformBy(new Matrix4(1, 0, 0, 0,
                                           0, 0, -1, 0,
                                           0, 1, 0, 0,
                                           0, 0, 0, 1
                                            ));
            circle1.TransformBy(new Matrix4(1, 0, 0, 0,
                                           0, 0, -1, 0,
                                           0, 1, 0, 0,
                                           0, 0, 0, 1
                                            ));
            circle.Center = new Vector3(x / 2, -80, z - ((z / (peregor_cold + 1)) / 2));
            circle1.Center = new Vector3(x / 2, -180, z - ((z / (peregor_cold + 1)) / 2));
            doc.Entities.Add(circle);
            doc.Entities.Add(circle1);
            var block = new Block("nn");
            HatchBoundaryPath hatch_path = new(new List<EntityObject> { circle, circle1 });
            Hatch hatch_nozzle = new(HatchPattern.Solid, true);
            hatch_nozzle.BoundaryPaths.Add(hatch_path);
            hatch_nozzle.TransformBy(new Matrix4(1, 0, 0, 0,
                                                 0, 0, -1, 0,
                                                 0, 1, 0, 0,
                                                 0, 0, 0, 1
                                            ));
            var hatch_nozzle1 = (Hatch)hatch_nozzle.Clone();
            hatch_nozzle.TransformBy(Matrix4.Translation(0, -180, 0));
            hatch_nozzle1.TransformBy(Matrix4.Translation(0, -200, 0));
            doc.Entities.Add(hatch_nozzle);
            doc.Entities.Add(hatch_nozzle1);
            DimensionStyle dimensionStyle = DimensionStyle.Iso25;
            dimensionStyle.ArrowSize = 5;
            dimensionStyle.DimLineColor = AciColor.Red;
            dimensionStyle.TextHorizontalPlacement = DimensionStyleTextHorizontalPlacement.Centered;
            dimensionStyle.TextColor = AciColor.Red;
            dimensionStyle.TextHeight = 20;
            dimensionStyle.TextFillColor = AciColor.DarkGray;
            DiametricDimension Diametricdimension = new DiametricDimension(circle, 45, dimensionStyle);
            Diametricdimension.TransformBy(Matrix4.Translation(0, -122, 0));
            doc.Entities.Add(Diametricdimension);
            ///

            ///
            Circle circle2 = new Circle(new Vector3(0, 0, 0), nozzle_d / 2);
            Circle circle3 = new Circle(new Vector3(0, 0, 0), nozzle_d / 2 + 20);
            circle2.Thickness = -120;
            circle3.Thickness = -20;
            circle2.TransformBy(new Matrix4(1, 0, 0, 0,
                                           0, 0, -1, 0,
                                           0, 1, 0, 0,
                                           0, 0, 0, 1
                                            ));
            circle3.TransformBy(new Matrix4(1, 0, 0, 0,
                                           0, 0, -1, 0,
                                           0, 1, 0, 0,
                                           0, 0, 0, 1
                                            ));
            circle2.Center = new Vector3(x / 2, y+80, ((z / (peregor_cold + 1)) / 2));
            circle3.Center = new Vector3(x / 2, y+180, ((z / (peregor_cold + 1)) / 2));
            doc.Entities.Add(circle2);
            doc.Entities.Add(circle3);
            HatchBoundaryPath hatch_path2 = new(new List<EntityObject> { circle2, circle3 });
            Hatch hatch_nozzle2 = new(HatchPattern.Solid, true);
            hatch_nozzle2.BoundaryPaths.Add(hatch_path2);
            hatch_nozzle2.TransformBy(new Matrix4(1, 0, 0, 0,
                                                 0, 0, -1, 0,
                                                 0, 1, 0, 0,
                                                 0, 0, 0, 1
                                            ));
            hatch_nozzle2.TransformBy(Matrix4.Translation(0, y+180, 0));

            var hatch_nozzle3 = (Hatch)hatch_nozzle2.Clone();
            hatch_nozzle3.TransformBy(Matrix4.Translation(0, 20, 0));
            doc.Entities.Add(hatch_nozzle2);
            doc.Entities.Add(hatch_nozzle3);
            ///
// nozzles hot            
            ///
            Circle circle4 = new Circle(new Vector3(0, 0, 0), nozzle_d / 2);
            Circle circle5 = new Circle(new Vector3(0, 0, 0), nozzle_d / 2 + 20);
            circle4.Thickness = -120;
            circle5.Thickness = -20;
            circle4.TransformBy(new Matrix4(0, 0, 1, 0,
                                            0, 1, 0, 0,
                                            -1, 0, 0, 0,
                                            0, 0, 0, 1
                                            ));
            circle5.TransformBy(new Matrix4(0, 0, 1, 0,
                                            0, 1, 0, 0,
                                            -1, 0, 0, 0,
                                            0, 0, 0, 1
                                            ));
            circle4.Center = new Vector3(-80, y/2,z - ((z / (peregor_hot + 1)) / 2));
            circle5.Center = new Vector3(-180, y/2 ,z - ((z / (peregor_hot + 1)) / 2));
            doc.Entities.Add(circle4);
            doc.Entities.Add(circle5);
            HatchBoundaryPath hatch_path3 = new(new List<EntityObject> { circle4, circle5 });
            Hatch hatch_nozzle4 = new(HatchPattern.Solid, true);
            hatch_nozzle4.BoundaryPaths.Add(hatch_path3);
            hatch_nozzle4.TransformBy(new Matrix4(0, 0, 1, 0,
                                                0, 1, 0, 0,
                                                -1, 0, 0, 0,
                                                0, 0, 0, 1
                                                ));
            /*hatch_nozzle4.TransformBy(new Matrix4(0, 0, 1, 0,
                                                0, 1, 0, 0,
                                                -1, 0, 0, 0,
                                                0, 0, 0, 1
                                                ));*/
            hatch_nozzle4.TransformBy(new Matrix4(1, 0, 0, 0,
                                                 0, 0, -1, 0,
                                                 0, 1, 0, 0,
                                                 0, 0, 0, 1
                                            ));
            hatch_nozzle4.TransformBy(Matrix4.Translation(-200, 0, 0));

            var hatch_nozzle5 = (Hatch)hatch_nozzle4.Clone();
            hatch_nozzle4.TransformBy(Matrix4.Translation(20, 0, 0));
            doc.Entities.Add(hatch_nozzle4);
            doc.Entities.Add(hatch_nozzle5);
            ///



            ///
            Circle circle6 = new Circle(new Vector3(0, 0, 0), nozzle_d / 2);
            Circle circle7 = new Circle(new Vector3(0, 0, 0), nozzle_d / 2 + 20);
            circle6.Thickness = 120;
            circle7.Thickness = 20;
            circle6.TransformBy(new Matrix4(0, 0, 1, 0,
                                            0, 1, 0, 0,
                                            -1, 0, 0, 0,
                                            0, 0, 0, 1
                                            ));
            circle7.TransformBy(new Matrix4(0, 0, 1, 0,
                                            0, 1, 0, 0,
                                            -1, 0, 0, 0,
                                            0, 0, 0, 1
                                            ));
            circle6.Center = new Vector3(x+80, y / 2,((z / (peregor_hot + 1)) / 2));
            circle7.Center = new Vector3(x+180, y / 2,((z / (peregor_hot + 1)) / 2));
            doc.Entities.Add(circle6);
            doc.Entities.Add(circle7);
            HatchBoundaryPath hatch_path4 = new(new List<EntityObject> { circle6, circle7 });
            Hatch hatch_nozzle6 = new(HatchPattern.Solid, true);
            hatch_nozzle6.BoundaryPaths.Add(hatch_path4);
            hatch_nozzle6.TransformBy(new Matrix4(0, 0, 1, 0,
                                                0, 1, 0, 0,
                                                -1, 0, 0, 0,
                                                0, 0, 0, 1
                                                ));
            /*hatch_nozzle4.TransformBy(new Matrix4(0, 0, 1, 0,
                                                0, 1, 0, 0,
                                                -1, 0, 0, 0,
                                                0, 0, 0, 1
                                                ));*/
            hatch_nozzle6.TransformBy(new Matrix4(1, 0, 0, 0,
                                                 0, 0, -1, 0,
                                                 0, 1, 0, 0,
                                                 0, 0, 0, 1
                                            ));
            hatch_nozzle6.TransformBy(Matrix4.Translation(x+180, 0, 0));
            var hatch_nozzle7 = (Hatch)hatch_nozzle6.Clone();
            hatch_nozzle6.TransformBy(Matrix4.Translation(20, 0, 0));
            doc.Entities.Add(hatch_nozzle6);
            doc.Entities.Add(hatch_nozzle7);
            ///

            
            // stand:
            List<int[]> faces_st = new List<int[]> {
                new[] {0, 3, 2, 1},
                new[] {0, 1, 5, 4},
                new[] {1, 2, 6, 5},
                new[] {2, 3, 7, 6},
                new[] {0, 4, 7, 3},
                new[] {4, 5, 6, 7},
                new[] {9,10,22,21},
                new[] {9,21,27,15},
                new[] {15,16,28,27 },
                new[] {16,28,22,10},
                new[] {9,10,16,15},
                new[] {21,22,28,27 },
                new[] {18,19,31,30},
                new[] {18,30,24,12 },
                new[] {12,13,25,24 },
                new[] {13,25,31,19 },
                new[] {12,13,19,18 },
                new[] {24,25,31,30}

            };
            Layer stand = new("stand");
            stand.Color = AciColor.DarkGray;
            Mesh stand_m = new Mesh(new List<Vector3> {
                new Vector3((x/2)-(x/10), y/2,0), //0
                new Vector3(x/2,(y/2)-(y/10),0), //1
                new Vector3((x/2)+(x/10),y/2,0), //2
                new Vector3(x/2,(y/2)+(y/10),0), //3
                // bot side
                new Vector3((x/2)-(x/10), y/2,-(x/10)), //4
                new Vector3(x/2,(y/2)-(y/10),-(x/10)), //5
                new Vector3((x/2)+(x/10),y/2,-(x / 10)), //6
                new Vector3(x/2,(y/2)+(y/10),-(x / 10)), //7
                // stand top
                    //0
                new Vector3(0,0,-(x/10)), //8
                new Vector3(x/10,0,-(x/10)),//9
                new Vector3(0,y/10,-(x/10)),//10
                    //x
                new Vector3(x,0,-(x/10)),//11
                new Vector3(x-(x/10),0,-(x/10)),//12
                new Vector3(x, x/10,-(x/10)),//13
                    //x,y
                new Vector3(x,y,-(x/10)),//14
                new Vector3(x,y-(x/10),-(x/10)),//15
                new Vector3(x-(x/10),y,-(x/10)),//16
                    //y
                new Vector3(0,y,-(x/10)),//17
                new Vector3(0,y-(x/10),-(x/10)),//18
                new Vector3(x/10,y,-(x/10)),//19
                // stand bot
                    //0
                new Vector3(0,0,-((x/10)-10)),//20
                new Vector3(x/10,0,-((x/10)-10)),//21
                new Vector3(0,y/10,-((x / 10) - 10)),//22
                    //x
                new Vector3(x,0,-((x / 10) - 10)),//23
                new Vector3(x-(x/10),0,-((x / 10) - 10)),//24
                new Vector3(x, x/10,-((x / 10) - 10)),//25
                    //x,y
                new Vector3(x,y,-((x / 10) - 10)),//26
                new Vector3(x,y-(x/10),-((x / 10) - 10)),//27
                new Vector3(x-(x/10),y,-((x / 10) - 10)),//28
                    //y
                new Vector3(0,y,-((x / 10) - 10)),//29
                new Vector3(0,y-(x/10),-((x / 10) - 10)),//30
                new Vector3(x/10,y,-((x / 10) - 10)),//31
                },faces_st);
            stand_m.Layer = stand;
            /*stand_m.TransformBy(new Matrix4(1.5, 0, 0, 0,
                                            0, 1.5, 0, 0,
                                            0, 0, 1.5, 0,
                                            0, 0, 0, 1));*/
            stand_m.TransformBy(Matrix4.Scale(1.5));
            stand_m.TransformBy(Matrix4.Translation(-(((x*1.5)-x)/2),-(((x*1.5)-x)/2),0));
            //  Add Entities:
            
            

            doc.Entities.Add(mesh);
            doc.Entities.Add(mesh1);
            doc.Entities.Add(mesh2);
            doc.Entities.Add(mesh3);
            doc.Entities.Add(top_mesh);
            doc.Entities.Add(bot_mesh);
            doc.Entities.Add(stand_m);
            
            //doc.Entities.Add(nozzle);
            //doc.Entities.Add(nozzle1_2);
            //doc.Entities.Add(nozzle_hot);
            //doc.Entities.Add(nozzle_hot1_2);

            //  Save to file:
            doc.Save(file);
        }
        {
            // your DXF file name
            string file = Path.Combine(Environment.CurrentDirectory,@"sample1.dxf");
            // create a new document, by default it will create an AutoCad2000 DXF version
            DxfDocument doc = new DxfDocument();
            // bolt:
            //x side
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
            netDxf.Entities.Mesh boltx = new(new List<Vector3> {
                new Vector3((x/2)-15, -80,z - ((z / (peregor_hot+1))/2)),//0
                new Vector3((x/2)-15/Math.Sqrt(2),-80,(z - ((z / (peregor_hot+1))/2))+15/Math.Sqrt(2)),//1
                new Vector3(x / 2, -80, (z - ((z / (peregor_hot + 1))/2)) + 15),//2
                new Vector3((x/2)+15/Math.Sqrt(2),-80,(z - ((z / (peregor_hot + 1))/2))+15/Math.Sqrt(2)),//3
                new Vector3((x / 2) + 15, -80,(z - ((z / (peregor_hot + 1))/2))),//4
                new Vector3((x/2)+15/Math.Sqrt(2),-80,(z - ((z / (peregor_hot + 1))/2))-15/Math.Sqrt(2)),//5
                new Vector3(x / 2, -80, (z - ((z / (peregor_hot + 1))/2)) - 15),//6
                new Vector3((x/2)-15/Math.Sqrt(2),-80,(z - ((z / (peregor_hot + 1))/2))-15/Math.Sqrt(2)),//7
            // long side
                new Vector3((x/2)-15, -100, (z - ((z / (peregor_hot + 1))/2))),//8
                new Vector3((x/2)-15/Math.Sqrt(2),-100,(z - ((z / (peregor_hot + 1))/2))+15/Math.Sqrt(2)),//9
                new Vector3(x / 2, -100, (z - ((z / (peregor_hot + 1))/2)) + 15),//10
                new Vector3((x/2)+15/Math.Sqrt(2),-100,(z - ((z / (peregor_hot + 1))/2))+15/Math.Sqrt(2)),//11
                new Vector3((x / 2) + 15, -100, (z - ((z / (peregor_hot + 1))/2))),//12
                new Vector3((x / 2) +15 / Math.Sqrt(2), -100,(z - ((z / (peregor_hot + 1))/2))-15/Math.Sqrt(2)),//13
                new Vector3(x / 2, -100, (z - ((z / (peregor_hot + 1))/2)) - 15),//14
                new Vector3((x / 2) -15 / Math.Sqrt(2), -100,(z - ((z / (peregor_hot + 1))/2))-15/Math.Sqrt(2)),//15
            // kolpak
                new Vector3((x/2)-7.5,-100, z - ((z / (peregor_hot+1))/2)+7.5), //16
                new Vector3((x/2)-7.5,-100,z - ((z / (peregor_hot+1))/2)-7.5), //17
                new Vector3((x/2)+7.5,-100,z - ((z / (peregor_hot+1))/2)+7.5), //18
                new Vector3((x/2)+7.5,-100,z - ((z / (peregor_hot+1))/2)-7.5), //19
                new Vector3((x/2)-7.5,-112,z - ((z / (peregor_hot+1))/2)+7.5), //20
                new Vector3((x/2)-7.5,-112,z - ((z / (peregor_hot+1))/2)-7.5), //21
                new Vector3((x/2)+7.5,-112,z - ((z / (peregor_hot+1))/2)+7.5), //22
                new Vector3((x/2)+7.5,-112,z - ((z / (peregor_hot+1))/2)-7.5), //23
                }, faces1, edges);
            netDxf.Entities.Mesh boltx2 = new(new List<Vector3> {
                new Vector3((x/2)-15, 80,z - ((z / (peregor_hot+1))/2)),//0
                new Vector3((x/2)-15/Math.Sqrt(2),80,(z - ((z / (peregor_hot+1))/2))+15/Math.Sqrt(2)),//1
                new Vector3(x / 2, 80, (z - ((z / (peregor_hot + 1))/2)) + 15),//2
                new Vector3((x/2)+15/Math.Sqrt(2),80,(z - ((z / (peregor_hot + 1))/2))+15/Math.Sqrt(2)),//3
                new Vector3((x / 2) + 15, 80,(z - ((z / (peregor_hot + 1))/2))),//4
                new Vector3((x/2)+15/Math.Sqrt(2),80,(z - ((z / (peregor_hot + 1))/2))-15/Math.Sqrt(2)),//5
                new Vector3(x / 2, 80, (z - ((z / (peregor_hot + 1))/2)) - 15),//6
                new Vector3((x/2)-15/Math.Sqrt(2),80,(z - ((z / (peregor_hot + 1))/2))-15/Math.Sqrt(2)),//7
            // long side
                new Vector3((x/2)-15, 100, (z - ((z / (peregor_hot + 1))/2))),//8
                new Vector3((x/2)-15/Math.Sqrt(2),100,(z - ((z / (peregor_hot + 1))/2))+15/Math.Sqrt(2)),//9
                new Vector3(x / 2, 100, (z - ((z / (peregor_hot + 1))/2)) + 15),//10
                new Vector3((x/2)+15/Math.Sqrt(2),100,(z - ((z / (peregor_hot + 1))/2))+15/Math.Sqrt(2)),//11
                new Vector3((x / 2) + 15, 100, (z - ((z / (peregor_hot + 1))/2))),//12
                new Vector3((x / 2) +15 / Math.Sqrt(2), 100,(z - ((z / (peregor_hot + 1))/2))-15/Math.Sqrt(2)),//13
                new Vector3(x / 2, 100, (z - ((z / (peregor_hot + 1))/2)) - 15),//14
                new Vector3((x / 2) -15 / Math.Sqrt(2), 100,(z - ((z / (peregor_hot + 1))/2))-15/Math.Sqrt(2)),//15
            // kolpak
                new Vector3((x/2)-7.5,100, z - ((z / (peregor_hot+1))/2)+7.5), //16
                new Vector3((x/2)-7.5,100,z - ((z / (peregor_hot+1))/2)-7.5), //17
                new Vector3((x/2)+7.5,100,z - ((z / (peregor_hot+1))/2)+7.5), //18
                new Vector3((x/2)+7.5,100,z - ((z / (peregor_hot+1))/2)-7.5), //19
                new Vector3((x/2)-7.5,112,z - ((z / (peregor_hot+1))/2)+7.5), //20
                new Vector3((x/2)-7.5,112,z - ((z / (peregor_hot+1))/2)-7.5), //21
                new Vector3((x/2)+7.5,112,z - ((z / (peregor_hot+1))/2)+7.5), //22
                new Vector3((x/2)+7.5,112,z - ((z / (peregor_hot+1))/2)-7.5), //23
                }, faces1, edges);
            boltx.SubdivisionLevel = 5;
            boltx2.SubdivisionLevel = 5;
            boltx.TransformBy(Matrix4.Translation(-(((y / 2) - 30)+80), 0, -((z - ((z / (peregor_hot + 1)) / 2))) + 40));
            doc.Entities.Add(boltx);
            boltx2.TransformBy(Matrix4.Translation(-(((y / 2) - 30) + 80), x , -((z - ((z / (peregor_hot + 1)) / 2))) + 40));
            //bolt
            for (int i = 1; i < (z+80) / 80; i++)
            {
                var boltn = (Mesh)boltx.Clone();
                boltn.TransformBy(Matrix4.Translation(i * 80, 0, 0));
                doc.Entities.Add(boltn);
            }
            for (int i = 1; i < x / 80; i++)
            {
                var boltn = (Mesh)boltx.Clone();
                boltn.TransformBy(Matrix4.Translation(0, 0, i * 80));
                doc.Entities.Add(boltn);
            }
            for (int i = 1; i < (z+80) / 80; i++)
            {
                var boltn = (Mesh)boltx.Clone();
                boltn.TransformBy(Matrix4.Translation(i*80, 0, (((y / 2) - 30) * 2)));
                doc.Entities.Add(boltn);
            }
            for (int i = 1; i < x / 80; i++)
            {
                var boltn = (Mesh)boltx.Clone();
                boltn.TransformBy(Matrix4.Translation(z, 0, i * 80));
                doc.Entities.Add(boltn);
            }

            //bolt2
            for (int i = 1; i < (z+80) / 80; i++)
            {
                var boltn = (Mesh)boltx2.Clone();
                boltn.TransformBy(Matrix4.Translation(i * 80, 0, 0));
                doc.Entities.Add(boltn);
            }
            for (int i = 1; i < x / 80; i++)
            {
                var boltn = (Mesh)boltx2.Clone();
                boltn.TransformBy(Matrix4.Translation(0, 0, (i * 80)));
                doc.Entities.Add(boltn);
            }
            for (int i = 1; i < (z+80) / 80; i++)
            {
                var boltn = (Mesh)boltx2.Clone();
                boltn.TransformBy(Matrix4.Translation(i*80, 0, (((y / 2) - 30) * 2)));
                doc.Entities.Add(boltn);
            }
            for (int i = 1; i < x / 80; i++)
            {
                var boltn = (Mesh)boltx2.Clone();
                boltn.TransformBy(Matrix4.Translation(z, 0, i * 80));
                doc.Entities.Add(boltn);
            }

            // Walls:
            List<int[]> faces = new List<int[]>
            {
                new[] {0, 3, 2, 1},
                new[] {0, 1, 5, 4},
                new[] {1, 2, 6, 5},
                new[] {2, 3, 7, 6},
                new[] {0, 4, 7, 3},
                new[] {4, 5, 6, 7}
            };
            Layer Walls = new("Walls");
            Walls.Color = AciColor.DarkGray;
            netDxf.Entities.Mesh mesh = new Mesh(new List<Vector3> { new Vector3(0, 0, 0), new Vector3(0, y, 0), new Vector3(-80, y, 0), new Vector3(-80, 0, 0), new Vector3(0, 0, x), new Vector3(0, y, x), new Vector3(-80, y, x), new Vector3(-80, 0, x) }, faces);
            netDxf.Entities.Mesh mesh1 = new(new List<Vector3> { new Vector3(-80, 0, 0), new Vector3(z, 0, 0), new Vector3(z, -80, 0), new Vector3(-80, -80, 0), new Vector3(-80, 0, x), new Vector3(z, 0, x), new Vector3(z, -80, x), new Vector3(-80, -80, x) }, faces);
            netDxf.Entities.Mesh mesh2 = new(new List<Vector3> { new Vector3(-80, y, 0), new Vector3(-80, y + 80, 0), new Vector3(z, y + 80, 0), new Vector3(z, y, 0), new Vector3(-80, y, x), new Vector3(-80, y + 80, x), new Vector3(z, y + 80, x), new Vector3(z, y, x) }, faces);
            netDxf.Entities.Mesh mesh3 = new(new List<Vector3> { new Vector3(z, y, 0), new Vector3(z - 80, y, 0), new Vector3(z - 80, 0, 0), new Vector3(z, 0, 0), new Vector3(z, y, x), new Vector3(z - 80, y, x), new Vector3(z - 80, 0, x), new Vector3(z, 0, x) }, faces);
            netDxf.Entities.Mesh top_mesh = new(new List<Vector3> { new Vector3(-80, 0, x), new Vector3(-80, y, x), new Vector3(z, y, x), new Vector3(z, 0, x), new Vector3(-80, 0, x + 80), new Vector3(-80, y, x + 80), new Vector3(z, y, x + 80), new Vector3(z, 0, x + 80) }, faces);
            netDxf.Entities.Mesh bot_mesh = new(new List<Vector3> { new Vector3(-80, 0, 0), new Vector3(-80, y, 0), new Vector3(z, y, 0), new Vector3(z, 0, 0), new Vector3(-80, 0, -80), new Vector3(-80, y, -80), new Vector3(z, y, -80), new Vector3(z, 0, -80) }, faces);
            mesh.Layer = Walls;
            mesh1.Layer = Walls;
            mesh2.Layer = Walls;
            mesh3.Layer = Walls;
            top_mesh.Layer = Walls;
            bot_mesh.Layer = Walls;
            // nozzles z:
            Circle circle = new Circle(new Vector3(0, 0, 0), nozzle_d / 2);
            Circle circle1 = new Circle(new Vector3(0, 0, 0), nozzle_d / 2 + 20);
            circle.Thickness = 120;
            circle1.Thickness = 20;
            circle.Center = new Vector3((z - ((z / (peregor_hot + 1)) / 2))-80, x/2, x+80);
            circle1.Center = new Vector3((z - ((z / (peregor_hot + 1)) / 2))-80, x/2, x+180);
            
            HatchBoundaryPath hatch_path = new(new List<EntityObject> { circle, circle1 });
            Hatch hatch_nozzle = new(HatchPattern.Solid, true);
            hatch_nozzle.BoundaryPaths.Add(hatch_path);
            hatch_nozzle.TransformBy(Matrix4.Translation(0, 0, x+180));
            
            var hatch_nozzle1 = (Hatch)hatch_nozzle.Clone();
            hatch_nozzle1.TransformBy(Matrix4.Translation(0, 0, 20));
            
            ///
            Circle circle2_0 = new Circle(new Vector3(0, 0, 0), nozzle_d / 2);
            Circle circle2_1 = new Circle(new Vector3(0, 0, 0), nozzle_d / 2 + 20);
            circle2_0.Thickness = 120;
            circle2_1.Thickness = 20;
            circle2_0.Center = new Vector3((z / (peregor_hot + 1) / 2), x/2, x+80);
            circle2_1.Center = new Vector3((z / (peregor_hot + 1) / 2), x/2, x+180);
            
            HatchBoundaryPath hatch_path2_0 = new(new List<EntityObject> { circle2_0, circle2_1 });
            Hatch hatch_nozzle2_0 = new(HatchPattern.Solid, true);
            hatch_nozzle2_0.BoundaryPaths.Add(hatch_path2_0);
            hatch_nozzle2_0.TransformBy(Matrix4.Translation(0, 0, x+180));
            
            var hatch_nozzle2_1 = (Hatch)hatch_nozzle2_0.Clone();
            hatch_nozzle2_1.TransformBy(Matrix4.Translation(0, 0, 20));
            

            ///
            Circle circle2 = new Circle(new Vector3(0, 0, 0), nozzle_d / 2);
            Circle circle3 = new Circle(new Vector3(0, 0, 0), nozzle_d / 2 + 20);
            circle2.Thickness = -120;
            circle3.Thickness = -20;
            circle2.Center = new Vector3((z / (peregor_hot + 1)) / 2, x / 2, -80);
            circle3.Center = new Vector3((z / (peregor_hot + 1)) / 2, x / 2, -180);
            HatchBoundaryPath hatch_path1 = new(new List<EntityObject> { circle2, circle3 });
            Hatch hatch_nozzle2 = new(HatchPattern.Solid, true);
            hatch_nozzle2.BoundaryPaths.Add(hatch_path1);
            hatch_nozzle2.TransformBy(Matrix4.Translation(0, 0, -180));
            
            var hatch_nozzle3 = (Hatch)hatch_nozzle2.Clone();
            hatch_nozzle3.TransformBy(Matrix4.Translation(0, 0, -20));
            
            ///
            // nozzles x:
            ///
            Circle circle4 = new Circle(new Vector3(0, 0, 0), nozzle_d / 2);
            Circle circle5 = new Circle(new Vector3(0, 0, 0), nozzle_d / 2 + 20);
            circle4.Thickness = 120;
            circle5.Thickness = 20;
            circle4.TransformBy(new Matrix4(1, 0, 0, 0,
                                           0, 0, -1, 0,
                                           0, 1, 0, 0,
                                           0, 0, 0, 1
                                            ));
            circle5.TransformBy(new Matrix4(1, 0, 0, 0,
                                           0, 0, -1, 0,
                                           0, 1, 0, 0,
                                           0, 0, 0, 1
                                            ));
            circle4.Center = new Vector3((z - ((z / (peregor_cold + 1)) / 2))-80, -80, x/2);
            circle5.Center = new Vector3((z - ((z / (peregor_cold + 1)) / 2))-80, -180, x/2);
            doc.Entities.Add(circle4);
            doc.Entities.Add(circle5);
            HatchBoundaryPath hatch_path2 = new(new List<EntityObject> { circle4, circle5 });
            Hatch hatch_nozzle4 = new(HatchPattern.Solid, true);
            hatch_nozzle4.BoundaryPaths.Add(hatch_path2);
            hatch_nozzle4.TransformBy(new Matrix4(1, 0, 0, 0,
                                                 0, 0, -1, 0,
                                                 0, 1, 0, 0,
                                                 0, 0, 0, 1
                                            ));
            var hatch_nozzle5 = (Hatch)hatch_nozzle4.Clone();
            hatch_nozzle4.TransformBy(Matrix4.Translation(0, -180, 0));
            hatch_nozzle5.TransformBy(Matrix4.Translation(0, -200, 0));
            doc.Entities.Add(hatch_nozzle4);
            doc.Entities.Add(hatch_nozzle5);
            ///
            ///
            Circle circle6 = new Circle(new Vector3(0, 0, 0), nozzle_d / 2);
            Circle circle7 = new Circle(new Vector3(0, 0, 0), nozzle_d / 2 + 20);
            circle6.Thickness = -120;
            circle7.Thickness = -20;
            circle6.TransformBy(new Matrix4(1, 0, 0, 0,
                                           0, 0, -1, 0,
                                           0, 1, 0, 0,
                                           0, 0, 0, 1
                                            ));
            circle7.TransformBy(new Matrix4(1, 0, 0, 0,
                                           0, 0, -1, 0,
                                           0, 1, 0, 0,
                                           0, 0, 0, 1
                                            ));
            circle6.Center = new Vector3(((z / (peregor_cold + 1)) / 2), y + 80, x/2);
            circle7.Center = new Vector3(((z / (peregor_cold + 1)) / 2), y + 180, x/2);
            doc.Entities.Add(circle6);
            doc.Entities.Add(circle7);
            HatchBoundaryPath hatch_path3 = new(new List<EntityObject> { circle6, circle7 });
            Hatch hatch_nozzle6 = new(HatchPattern.Solid, true);
            hatch_nozzle6.BoundaryPaths.Add(hatch_path3);
            hatch_nozzle6.TransformBy(new Matrix4(1, 0, 0, 0,
                                                 0, 0, -1, 0,
                                                 0, 1, 0, 0,
                                                 0, 0, 0, 1
                                            ));
            hatch_nozzle6.TransformBy(Matrix4.Translation(0, y + 180, 0));

            var hatch_nozzle7 = (Hatch)hatch_nozzle6.Clone();
            hatch_nozzle7.TransformBy(Matrix4.Translation(0, 20, 0));
            doc.Entities.Add(hatch_nozzle6);
            doc.Entities.Add(hatch_nozzle7);
            ///

            // stand:
            List<int[]> faces_st = new List<int[]> {
                new[] {0, 3, 2, 1},
                new[] {0, 1, 5, 4},
                new[] {1, 2, 6, 5},
                new[] {2, 3, 7, 6},
                new[] {0, 4, 7, 3},
                new[] {4, 5, 6, 7},
                new[] {9,10,22,21},
                new[] {9,21,27,15},
                new[] {15,16,28,27 },
                new[] {16,28,22,10},
                new[] {9,10,16,15},
                new[] {21,22,28,27 },
                new[] {18,19,31,30},
                new[] {18,30,24,12 },
                new[] {12,13,25,24 },
                new[] {13,25,31,19 },
                new[] {12,13,19,18 },
                new[] {24,25,31,30}

            };
            Layer stand = new("stand");
            stand.Color = AciColor.Blue;
            Mesh stand_m = new Mesh(new List<Vector3> {
                new Vector3((x/2)-(x/10), y/2,0), //0
                new Vector3(x/2,(y/2)-(y/10),0), //1
                new Vector3((x/2)+(x/10),y/2,0), //2
                new Vector3(x/2,(y/2)+(y/10),0), //3
                // bot side
                new Vector3((x/2)-(x/10), y/2,-(x/10)), //4
                new Vector3(x/2,(y/2)-(y/10),-(x/10)), //5
                new Vector3((x/2)+(x/10),y/2,-(x / 10)), //6
                new Vector3(x/2,(y/2)+(y/10),-(x / 10)), //7
                // stand top
                    //0
                new Vector3(0,0,-(x/10)), //8
                new Vector3(x/10,0,-(x/10)),//9
                new Vector3(0,y/10,-(x/10)),//10
                    //x
                new Vector3(x,0,-(x/10)),//11
                new Vector3(x-(x/10),0,-(x/10)),//12
                new Vector3(x, x/10,-(x/10)),//13
                    //x,y
                new Vector3(x,y,-(x/10)),//14
                new Vector3(x,y-(x/10),-(x/10)),//15
                new Vector3(x-(x/10),y,-(x/10)),//16
                    //y
                new Vector3(0,y,-(x/10)),//17
                new Vector3(0,y-(x/10),-(x/10)),//18
                new Vector3(x/10,y,-(x/10)),//19
                // stand bot
                    //0
                new Vector3(0,0,-((x/10)-10)),//20
                new Vector3(x/10,0,-((x/10)-10)),//21
                new Vector3(0,y/10,-((x / 10) - 10)),//22
                    //x
                new Vector3(x,0,-((x / 10) - 10)),//23
                new Vector3(x-(x/10),0,-((x / 10) - 10)),//24
                new Vector3(x, x/10,-((x / 10) - 10)),//25
                    //x,y
                new Vector3(x,y,-((x / 10) - 10)),//26
                new Vector3(x,y-(x/10),-((x / 10) - 10)),//27
                new Vector3(x-(x/10),y,-((x / 10) - 10)),//28
                    //y
                new Vector3(0,y,-((x / 10) - 10)),//29
                new Vector3(0,y-(x/10),-((x / 10) - 10)),//30
                new Vector3(x/10,y,-((x / 10) - 10)),//31
                }, faces_st);
            stand_m.Layer = stand;

            // hook
            List<int[]> faces_h = new List<int[]>()
            {
                new[] {0, 3, 2, 1},
                new[] {0, 17, 19, 16, 9, 11, 8, 3},
                new[] {4, 17, 18, 16, 9, 10, 8, 7},
                new[] {0,4,17},
                new[] {3,7,8}, 
                new[] {1, 21, 23, 20, 13, 15, 12, 2},
                new[] {5, 21, 22, 20, 13, 14, 12, 6},
                new[] {1,5,21},
                new[] {2,6,12},
                new[] {0, 1, 5, 4},
                //new[] {1, 2, 6, 5},
                new[] {2, 3, 7, 6},
                //new[] {0, 4, 7, 3},
                new[] {4, 5, 6, 7},//
                new[] {8, 10, 14, 12},//
                new[] {8, 11, 15, 12},
                new[] {9, 10, 14, 13},
                new[] {9, 11, 15, 13},//
                new[] {16, 18, 22, 20},//
                new[] {16, 19, 23, 20},
                new[] {17, 18, 22, 21},
                new[] {17, 19, 23, 21},//
            };
            List<int[]> faces_V = new List<int[]>()
            {
                new[] {0, 3, 2, 1},
                
                new[] {0, 1, 5, 4},
                new[] {1, 2, 6, 5},
                new[] {2, 3, 7, 6},
                new[] {0, 4, 7, 3},
                new[] {4, 5, 6, 7},
            };
            List<MeshEdge> edges2 = new List<MeshEdge>
            {
                new MeshEdge(0, 1, -1.0),
                new MeshEdge(1, 2, -1.0),
                new MeshEdge(2, 3,-1.0),
                new MeshEdge(3, 0, -1.0),
                new MeshEdge(4, 5),//
                new MeshEdge(5, 6, -1.0),
                new MeshEdge(6, 7),
                new MeshEdge(7, 4, -1.0),//
                new MeshEdge(0, 4, -1.0),
                new MeshEdge(1, 5, -1.0),
                new MeshEdge(2, 6, -1.0),
                new MeshEdge(3, 7, -1.0),
                /*new MeshEdge(0, 17, -1.0),
                new MeshEdge(4, 17, -1.0),
                new MeshEdge(16, 9, -1.0),
                new MeshEdge(3, 8, -1.0),
                new MeshEdge(7, 8, -1.0),*/
                new MeshEdge(17, 18, -1.0),
                new MeshEdge(18, 16, -1.0),
                new MeshEdge(17, 19, -1.0),
                new MeshEdge(19, 16, -1.0),//
                new MeshEdge(9, 11, -1.0),
                new MeshEdge(11, 8, -1.0),
                new MeshEdge(9, 10, -1.0),
                new MeshEdge(10, 8, -1.0),//
                new MeshEdge(21, 23, -1.0),///////
                new MeshEdge(23, 20, -1.0),
                new MeshEdge(13, 15, -1.0),
                new MeshEdge(15, 12, -1.0),//
                new MeshEdge(21, 22, -1.0),//
                new MeshEdge(22, 20, -1.0),
                new MeshEdge(13, 14, -1.0),
                new MeshEdge(14, 12, -1.0),//

            };
            Mesh hook = new(new List<Vector3> { new Vector3(-80, y / 4, (x / 2) - 5), //0
                                                new Vector3(-80, y/4,(x/2)+5), //1
                                                new Vector3(-80, y-(y/4),(x/2)+5), //2
                                                new Vector3(-80, y-(y/4),(x/2)-5), //3
                                                new Vector3(-180,y/4, (x/2)-5), //4
                                                new Vector3(-180,y/4, (x/2)+5), //5
                                                new Vector3(-180,y-(y/4), (x/2)+5), //6
                                                new Vector3(-180,y-(y/4), (x/2)-5),//7
                                                new Vector3(-130, y-(y/2.8)+5,(x/2)-5),//8// ***             
                                                new Vector3(-130, y-(y/2.8)-5,(x/2)-5),//9               
                                                new Vector3(-135, y-(y/2.8),(x/2)-5),//10                
                                                new Vector3(-125, y-(y/2.8),(x/2)-5),//11
                                                new Vector3(-130, y-(y/2.8)+5,(x/2)+5),//12               
                                                new Vector3(-130, y-(y/2.8)-5,(x/2)+5),//13                
                                                new Vector3(-135, y-(y/2.8),(x / 2) + 5),//14                
                                                new Vector3(-125, y-(y/2.8),(x / 2) + 5),//15// ***
                                                new Vector3(-130, (y/2.8)+5,(x/2)-5),//16// ***               
                                                new Vector3(-130, (y/2.8)-5,(x/2)-5),//17               
                                                new Vector3(-135, (y/2.8),(x/2)-5),//18              
                                                new Vector3(-125, (y/2.8),(x/2)-5),//19
                                                new Vector3(-130, (y/2.8)+5,(x/2)+5),//20               
                                                new Vector3(-130, (y/2.8)-5,(x/2)+5),//21                
                                                new Vector3(-135, (y/2.8),(x / 2) + 5),//22                
                                                new Vector3(-125, (y/2.8),(x / 2) + 5),//23               
            }, faces_h, edges2);

            Mesh hookV = new(new List<Vector3> { new Vector3(-80, (x / 2) - 5 ,y / 3 ), //0
                                                new Vector3(-80, (x/2)+5,y/3), //1
                                                new Vector3(-80, (x/2)+5,y-(y/3)), //2
                                                new Vector3(-80, (x / 2) - 5, y -(y / 3)), //3
                                                new Vector3(-180,(x / 2) - 5, y / 3), //4
                                                new Vector3(-180,(x / 2) + 5, y / 3), //5
                                                new Vector3(-180,(x / 2) + 5, y -(y / 3)), //6
                                                new Vector3(-180,(x / 2) - 5, y -(y / 3)), //7
                                                
            }, faces_V, edges2);
            hookV.SubdivisionLevel = 2;
            Mesh hook2 = new(new List<Vector3> { new Vector3(z, y / 4, (x / 2) - 5), //0
                                                new Vector3(z, y/4,(x/2)+5), //1
                                                new Vector3(z, y-(y/4),(x/2)+5), //2
                                                new Vector3(z, y-(y/4),(x/2)-5), //3
                                                new Vector3(z+100,y/4, (x/2)-5), //4
                                                new Vector3(z+100,y/4, (x/2)+5), //5
                                                new Vector3(z + 100,y-(y/4), (x/2)+5), //6
                                                new Vector3(z + 100,y-(y/4), (x/2)-5), //7
                                                
            }, faces_V, edges2);
            hook.SubdivisionLevel = 5;
            hook2.SubdivisionLevel = 5;
            Circle podbolt = new Circle(new Vector3(-130,y-(y/2.8),(x/2)+5),7);
            HatchBoundaryPath path = new HatchBoundaryPath(new List<EntityObject> { podbolt });
            Hatch podbolth = new Hatch(HatchPattern.Solid, true);
            podbolth.Color = AciColor.FromTrueColor(0);
            podbolth.BoundaryPaths.Add(path);
            podbolth.TransformBy(Matrix4.Translation(0, 0, (x / 2) + 5));
            
            //  Add Entities:
            doc.Entities.Add(hook);
            doc.Entities.Add(hookV);
            doc.Entities.Add(hook2);
            doc.Entities.Add(mesh);
            doc.Entities.Add(mesh1);
            doc.Entities.Add(mesh2);
            doc.Entities.Add(mesh3);
            doc.Entities.Add(top_mesh);
            doc.Entities.Add(bot_mesh);
            //doc.Entities.Add(stand_m);

            /*switch (cold_side_count_of_nozzles)
            {
                case 1:
                    doc.Entities.Add(nozzle);
                    doc.Entities.Add(nozzle1_2);
                    break;
                case 2:
                    doc.Entities.Add(nozzle);
                    doc.Entities.Add(nozzle2);
                    break;
            }*/

            switch (Hot_side_count_of_nozzles)
            {
                case 1:
                    doc.Entities.Add(circle);
                    doc.Entities.Add(circle1);
                    doc.Entities.Add(hatch_nozzle);
                    doc.Entities.Add(hatch_nozzle1);
                    ///
                    doc.Entities.Add(circle2);
                    doc.Entities.Add(circle3);
                    doc.Entities.Add(hatch_nozzle2);
                    doc.Entities.Add(hatch_nozzle3);
                    break;
                case 2:
                    doc.Entities.Add(circle);
                    doc.Entities.Add(circle1);
                    doc.Entities.Add(hatch_nozzle);
                    doc.Entities.Add(hatch_nozzle1);
                    ///
                    doc.Entities.Add(circle2_0);
                    doc.Entities.Add(circle2_1);
                    doc.Entities.Add(hatch_nozzle2_0);
                    doc.Entities.Add(hatch_nozzle2_1);
                    break;
            }


            //  Save to file:
            doc.Save(file);
        }
    }
}
