using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    public class Graph
    {
        public List<Vertex> vertices = new List<Vertex>();
        public void AddEdge(int start, int end)
        {
            Vertex? vertex_start = CheckVertex(start);
            if (vertex_start == null)
            {
                vertex_start = new Vertex(start);
                vertices.Add(vertex_start);
            }
            Vertex? vertex_end = CheckVertex(end);
            if (vertex_end == null)
            {
                vertex_end = new Vertex(end);
                vertices.Add(vertex_end);
            }
            vertex_start.AddAdjacentVertex(vertex_end);
            
        }
        private Vertex? CheckVertex(int data)
        {
            foreach (Vertex vertex in vertices)
            {
                if (vertex.data == data)
                    return vertex;
            }
            return null;
        }
    }
}
