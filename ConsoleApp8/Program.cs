using System.Collections.Generic;

namespace ConsoleApp8
{
    class Programm
    {
        public static void Main(string[] args)
        {
            Graph graph = new Graph();
            graph.AddEdge(1, 2);
            graph.AddEdge(2, 3);
            graph.AddEdge(3, 1);
            DepthTraversal(graph);
            Console.WriteLine();
            WidthTraversal(graph);
            FindEulerianCycle(graph);
        }

        public static void DepthTraversal(Graph graph)
        {
            // ----ФУНКЦИЯ ПОИСКА В ГЛУБИНУ----
            // Алгоритм:
            // 1. Создается стэк и туда помещается первая вершина графа
            // 2. Создается список обработанных вершин
            // 3. Пока стэк не пустой:
            //      -извлекаем из стэка вершину
            //      -Если в списке обр. вершин нету этой вершины, то:
            //          *обрабатываем вершину
            //          *добавляем в стэк все смежные с ним вершины
            //          *добавляем извлечённую вершину в список обработнных вершин
            Stack<Vertex> vertexStack = new Stack<Vertex>();
            List<Vertex> ProcessedVerticies = new List<Vertex>();
            vertexStack.Push(graph.vertices[0]);
            while (vertexStack.Count > 0)
            {
                Vertex v = vertexStack.Pop();
                if (!ProcessedVerticies.Contains(v))
                {
                    Console.WriteLine(v.data);
                    foreach (var vert in v.adjacentVerticies)
                    {
                        vertexStack.Push(vert);
                    }
                    ProcessedVerticies.Add(v);
                }
                else
                {
                    Console.WriteLine("В графе есть цикл");
                }
            }
        }

        public static void WidthTraversal(Graph graph)
        {
            // ----ФУНКЦИЯ ПОИСКА В ШИРИНУ----
            // Алгоритм:
            // 1. Создается очередь и список обработанных вершин
            // 2. В очередь добавляется произвольная вершина графа
            // 3. Пока очередь не пуста:
            //      -извлекаем из очереди вершину
            //      -Если вершины нету в списке обработнных вершин, то:
            //          *обрабатываем вершину
            //          *заносим в очередь все смежные с ним вершины
            //          *заносим в список обработанных вершин извлечённую вершину
            Queue<Vertex> queue = new Queue<Vertex>();
            List<Vertex> ProcessedVerticies = new List<Vertex>();
            queue.Enqueue(graph.vertices[0]);
            while (queue.Count > 0)
            {
                Vertex v = queue.Dequeue();
                if (!ProcessedVerticies.Contains(v))
                {
                    Console.WriteLine(v.data);
                    foreach (var vert in v.adjacentVerticies)
                    {
                        queue.Enqueue(vert);
                    }
                    ProcessedVerticies.Add(v);
                }
                else
                {
                    Console.WriteLine("В графе есть цикл");
                }
            }

        }

        public static void FindEulerianCycle(Graph graph)
        {
            List<Vertex> cycle = new List<Vertex>();
            Stack<Vertex> stack = new Stack<Vertex>();
            foreach (var v in graph.vertices)
            {
                if (v.adjacentVerticies.Count > 0)
                {
                    stack.Push(v);
                    break;
                }
            }
            while (stack.Count > 0)
            {
                Vertex currentVertex = stack.Peek();
                if (currentVertex.adjacentVerticies.Count > 0)
                {
                    var nextVertex = currentVertex.adjacentVerticies[0];
                    stack.Push(nextVertex);
                    currentVertex.adjacentVerticies.Remove(nextVertex);
                    nextVertex.adjacentVerticies.Remove(currentVertex);
                }
                else
                {
                    cycle.Add(stack.Pop());
                }
            }
            cycle.Reverse();
            foreach (var v in cycle)
            {
                Console.WriteLine(v.data);
            }
        }
    }
    // ----ПРИМЕНЕНИЕ ОБХОДОВ ГРАФОВ----
    // Оба метода обхода графа можно использовать для нахождения пути между двумя вершинами
    // Оба метода обхода графа можно использовать для обнаружения цикла в графе
    // Оба метода обхода графа можно использовать для обнаружения остновного дереве в нём
    // Метод обхода графа в ширину можно использовать для обнаружения того, является ли он двудольным

    // ----СФЕРЫ ПРИМЕНЕНИЯ ГРАФОВ----
    // 1. Тестирование программ, анализ
    // 2. Транспортные сети, логистика
    // 3. Теоретическое программирование
    // 4. Исследование проблем оптимизации
}
