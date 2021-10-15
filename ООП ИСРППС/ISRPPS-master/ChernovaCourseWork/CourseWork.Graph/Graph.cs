using System;
using System.Collections.Generic;
using System.Linq;

namespace CourseWork.Graph
{
    public class Graph
    {
        public Graph(int[,] adjacencyMatrix)
        {
            var edges = new List<Edge>();
            for (var i = 0; i < adjacencyMatrix.GetLength(0); i++)
            {
                for (var j = 0; j < i; j++)
                {
                    if (adjacencyMatrix[i, j] == 1)
                    {
                        edges.Add(new Edge() { FirstVertexIndex = i, SecondVertexIndex = j });
                    }
                }
            }
            _edges = edges.ToArray();
            _verticesCount = adjacencyMatrix.GetLength(0);
        }

        private Edge[] _edges;
        private int _verticesCount;

        public int[] GetArticulationVerticesIndices()
        {
            var result = new List<int>();
            int connectivityComponentsCount = FindConnectivityComponents(_edges, Enumerable.Range(0, _verticesCount).ToArray()).Length;
            for (var i = 0; i < _verticesCount; i++)
            {
                var edges = _edges
                    .Select(e => new Edge() { FirstVertexIndex = e.FirstVertexIndex, SecondVertexIndex = e.SecondVertexIndex })
                    .Where(e => e.FirstVertexIndex != i && e.SecondVertexIndex != i)
                    .ToArray();
                if (connectivityComponentsCount != FindConnectivityComponents(edges, Enumerable.Range(0, _verticesCount).Where(v => v != i).ToArray()).Length)
                {
                    result.Add(i);
                }
            }
            return result.ToArray();
        }

        public Dictionary<int, int[][]> GetBlocks()
        {
            var articulationVertices = GetArticulationVerticesIndices();
            foreach (var articulationVertex in articulationVertices)
            {
                var edges = _edges
                    .Select(e => new Edge() { FirstVertexIndex = e.FirstVertexIndex, SecondVertexIndex = e.SecondVertexIndex })
                    .Where(e => e.FirstVertexIndex != articulationVertex && e.SecondVertexIndex != articulationVertex)
                    .ToArray();
                var connectivityComponents = FindConnectivityComponents(edges, Enumerable.Range(0, _verticesCount).Where(v => v != articulationVertex).ToArray());
                foreach (var component in connectivityComponents)
                {
                    // TODO
                    throw new Exception();
                }
            }
            return null;
        }

        private int[][] FindConnectivityComponents(Edge[] edges, int[] vertices)
        {
            var edgesList = edges.ToList();
            var verticesList = vertices.ToList();
            var result = new List<int[]>();
            while (edgesList.Count() != 0)
            {
                var component = new List<int>();
                
                component.Add(edgesList[0].FirstVertexIndex);
                var componentSize = 0;

                while (componentSize != component.Count)
                {
                    componentSize = component.Count;
                    var verticesToAdd = new List<int>();
                    for (var i = 0; i < component.Count; i++)
                    {
                        var vertex = component[i];
                        var edgesToRemove = edgesList.Where(e => e.FirstVertexIndex == vertex || e.SecondVertexIndex == vertex);
                        edgesList = edgesList.Where(e => e.FirstVertexIndex != vertex && e.SecondVertexIndex != vertex).ToList();
                        foreach (var edgeToRemove in edgesToRemove)
                        {
                            verticesToAdd.Add(edgeToRemove.FirstVertexIndex);
                            verticesToAdd.Add(edgeToRemove.SecondVertexIndex);
                        }
                    }
                    verticesToAdd = verticesToAdd.Distinct().ToList();
                    foreach (var vertexToAdd in verticesToAdd)
                    {
                        component.Add(vertexToAdd);
                    }
                    component = component.Distinct().ToList();
                    foreach (var vertex in component)
                    {
                        verticesList.Remove(vertex);
                    }
                }
                result.Add(component.ToArray());
            }
            foreach (var vertex in verticesList)
            {
                result.Add(new[] { vertex });
            }
            return result.ToArray();
        }
    }
}