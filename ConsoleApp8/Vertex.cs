using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    public class Vertex
    {
        public int data;
        public int min_d;
        public List<Vertex> adjacentVerticies = new List<Vertex>();
        public Vertex(int data)
        {
            this.data = data;
        }

        public void AddAdjacentVertex(Vertex vertex)
        {
            adjacentVerticies.Add(vertex);
        }
    }
}
