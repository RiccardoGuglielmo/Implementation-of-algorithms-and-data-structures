using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace ASDlib
{
    #region Interfacce

    interface IPriorityQueue
    {
        bool insert(int i);
        int findMin();
        int extractMin();
    }

    interface IGraphSearch
    {
        void depthFirst();
        void breadthFirst(int s);
    }

    interface ICandidate
    {
        string nome { get; }
        string cognome { get; }
        string matricola { get; }
    }

    interface IOrdinamenti
    {
        void insertionSort(int[] A);
        void insertionSort(double[] A);
        void insertionSort(string[] A);
        void quickSort(int[] arr);
        void quickSort(double[] arr);
        void quickSort(string[] arr);
        void countingSort(int[] A, out int[] B);
    }

    interface IGrafo
    {
        void readXMLgraph(string fpath);
        int[] dijkstra(int s);
        List<int> kruskal();
        int[] prim(int r);
        int numNodi { get; set; }
        int numArchi { get; set; }
        bool isOriented { get; }
    }

    interface IUpTree
    {
        int findSet(int x);
        void makeSet(int x);
        void union(int x, int y);
    }

    interface IHeap
    {
        int[] HeapInt { get; }
        double[] HeapDouble { get; }
        string[] HeapString { get; }
        void buildHeap(int[] A);
        void insert(int x);
        void extractMin(out int min);
        void extractMin(out double min);
        void extractMin(out string min);
    }

    interface IHash
    {
        int NumPos { get; }
        List<int> showTableLine(int k);
        void chainedHashInsert(int x);
        bool chainedHashSearch(int k);
        bool chainedHashDelete(int x);
    }

    #endregion

    public struct Nodo
    {
        public int id;
        public int x, y;
        public Nodo(int p1, int p2, int p3)
        {
            id = p1;
            x = p2;
            y = p3;
        }
    }

    public struct Arco
    {
        public int id;
        public int end1;
        public int end2;
        public int w;
        public Arco(int p1, int p2, int p3, int p4)
        {
            id = p1;
            end1 = p2;
            end2 = p3;
            w = p4;
        }
    }

    public class Ordinamenti : IOrdinamenti, ICandidate
    {
        public string nome { get { return "Riccardo"; } }
        public string cognome { get { return "Guglielmo"; } }
        public string matricola { get { return "0000577079"; } }

        public void insertionSort(int[] A)
        {
            int i, temp;
            for (int j = 1; j < A.Length; j++)
            {
                temp = A[j];
                i = j;
                while (i > 0 && A[i - 1] >= temp)
                {
                    A[i] = A[i - 1];
                    i--;
                }
                A[i] = temp;
            }
        }

        public void insertionSort(double[] A)
        {
            int i;
            double temp;
            for (int j = 1; j < A.Length; j++)
            {
                temp = A[j];
                i = j;
                while (i > 0 && A[i - 1] >= temp)
                {
                    A[i] = A[i - 1];
                    i--;
                }
                A[i] = temp;
            }
        }

        public void insertionSort(string[] A)
        {
            int i;
            string temp;
            for (int j = 1; j < A.Length; j++)
            {
                temp = A[j];
                i = j;
                while (i > 0 && A[i - 1].CompareTo(temp) > 0)
                {
                    A[i] = A[i - 1];
                    i--;
                }
                A[i] = temp;
            }
        }

        public void quickSort(int[] arr)
        {
            qSort(arr, 0, arr.Length - 1);
        }
        private void qSort(int[] arr, int first, int last)
        {
            if ((last - first) <= 0) return;
            else
            {
                int part = Partition(arr, first, last);
                qSort(arr, first, part - 1);
                qSort(arr, part + 1, last);
            }
        }
        private int Partition(int[] arr, int first, int last)
        {
            int temp;
            int pivot = arr[last];
            int i = first - 1;
            for (int j = first; j < last; j++)
            {
                if (arr[j] <= pivot)
                {
                    i = i + 1;
                    temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }
            temp = arr[i + 1];
            arr[i + 1] = arr[last];
            arr[last] = temp;
            return i + 1;
        }

        public void quickSort(double[] arr)
        {
            qSort(arr, 0, arr.Length - 1);
        }
        private void qSort(double[] arr, int first, int last)
        {
            if ((last - first) <= 0) return;
            else
            {
                int part = Partition(arr, first, last);
                qSort(arr, first, part - 1);
                qSort(arr, part + 1, last);
            }
        }
        private int Partition(double[] arr, int first, int last)
        {
            double temp;
            double pivot = arr[last];
            int i = first - 1;
            for (int j = first; j < last; j++)
            {
                if (arr[j] <= pivot)
                {
                    i = i + 1;
                    temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }
            temp = arr[i + 1];
            arr[i + 1] = arr[last];
            arr[last] = temp;
            return i + 1;
        }

        public void quickSort(string[] arr)
        {
            qSort(arr, 0, arr.Length - 1);
        }
        private void qSort(string[] arr, int first, int last)
        {
            int i = first;
            int j = last;
            string leftString = arr[i];
            string rightString = arr[j];
            double pivotValue = ((first + last) / 2);
            string middle = arr[Convert.ToInt32(pivotValue)];
            string temp = null;
            while (i <= j)
            {
                while (arr[i].CompareTo(middle) < 0)
                {
                    i++;
                    leftString = arr[i];
                }
                while (arr[j].CompareTo(middle) > 0)
                {
                    j--;
                    rightString = arr[j];
                }
                if (i <= j)
                {
                    temp = arr[i];
                    arr[i++] = arr[j];
                    arr[j--] = temp;
                }
            }
            if (first < j)
            {
                qSort(arr, first, j);
            }
            if (i < last)
            {
                qSort(arr, i, last);
            }
        }

        public void countingSort(int[] A, out int[] B)
        {
            int index = 0, k = A[0];
            B = new int[A.Length];
            for (int i = 0; i < A.Length; i++) if (A[i] > k) k = A[i];
            int[] C = new int[k + 1];
            for (int i = 0; i < A.Length; i++) C[A[i]]++;
            for (int i = 0; i < C.Length; i++)
            {
                while (C[i] != 0)
                {
                    B[index++] = i;
                    C[i]--;
                }
            }
        }
    }

    public class Grafo : IGrafo
    {
        public List<Nodo> V;
        public List<Arco> E;
        private int numV;
        private int numE;
        private bool isOr;

        public int numNodi { get { return numV; } set { numV = value; } }
        public int numArchi { get { return numE; } set { numE = value; } }
        public bool isOriented { get { return isOr; } }

        public Grafo()
        {
            V = new List<Nodo>();
            E = new List<Arco>();
            numNodi = 0;
            numArchi = 0;
            isOr = false;
        }

        public virtual void readXMLgraph(string fpath)
        {
            XmlTextReader reader = new XmlTextReader(fpath);
            Nodo nodo = new Nodo(0, 0, 0);
            Arco arco = new Arco(0, 0, 0, 0);
            int temp;
            while (reader.Read())
            {
                if (reader.Name == "nodo")
                {
                    while (reader.MoveToNextAttribute())
                    {
                        switch (reader.Name)
                        {
                            case "id":
                                nodo.id = Convert.ToInt16(reader.Value);
                                break;
                            case "x":
                                nodo.x = Convert.ToInt16(reader.Value);
                                break;
                            case "y":
                                nodo.y = Convert.ToInt16(reader.Value);
                                break;
                        }
                    }
                    V.Add(nodo);
                    numNodi++;
                }
                if (reader.Name == "arco")
                {
                    while (reader.MoveToNextAttribute())
                    {
                        switch (reader.Name)
                        {
                            case "id":
                                arco.id = Convert.ToInt16(reader.Value);
                                break;
                            case "end1":
                                arco.end1 = Convert.ToInt16(reader.Value);
                                break;
                            case "end2":
                                arco.end2 = Convert.ToInt16(reader.Value);
                                break;
                            case "type":
                                if (reader.Value == "Edge")
                                    isOr = true;
                                break;
                            case "w":
                                arco.w = Convert.ToInt16(reader.Value);
                                break;
                        }
                    }
                    E.Add(arco);
                    if (isOriented)
                    {
                        temp = arco.end1;
                        arco.end1 = arco.end2;
                        arco.end2 = temp;
                        E.Add(arco);
                        numArchi++;
                        isOr = false;
                    }
                    numArchi++;
                }
            }
            reader.Close();
        }

        public int[] dijkstra(int s)
        {
            List<int> S = new List<int>();
            IEnumerable<Nodo> temp;
            Nodo[] V1 = V.ToArray();
            for (int i = 0; i < numNodi; i++)
            {
                V1[i].x = int.MaxValue;
                V1[i].y = 0;
            }
            V1[s].x = 0;
            List<Nodo> Q;
            Nodo u;

            for (int i = 0; i < numNodi; i++)
            {
                temp = V1.OrderBy(v => v.x);
                Q = temp.ToList();
                for (int j = 0; j < S.Count; j++)
                    Q.Remove(V1[S[j]]);
                u = Q[0];
                S.Add(u.id);
                foreach (Arco arc in E)
                {
                    if (arc.end1 == u.id)
                    {
                        if (V1[arc.end2].x > u.x + arc.w)
                        {
                            V1[arc.end2].x = u.x + arc.w;
                            V1[arc.end2].y = u.id;
                        }
                    }
                }
            }

            int[] p = new int[numNodi];
            foreach (Nodo v in V1)
                p[v.id] = v.y;

            return p;
        }

        public virtual List<int> kruskal()
        {
            UpTree myUT = new UpTree(numNodi);
            List<Arco> E1 = new List<Arco>();
            List<int> A = new List<int>();

            for (int i = 0; i < numNodi; i++)
                myUT.makeSet(V[i].id);

            #region Edge sort
            XmlTextReader reader = new XmlTextReader("Grafo.xml");
            Nodo nodo = new Nodo(0, 0, 0);
            Arco arco = new Arco(0, 0, 0, 0);
            while (reader.Read())
            {
                if (reader.Name == "arco")
                {
                    while (reader.MoveToNextAttribute())
                    {
                        switch (reader.Name)
                        {
                            case "id":
                                arco.id = Convert.ToInt16(reader.Value);
                                break;
                            case "end1":
                                arco.end1 = Convert.ToInt16(reader.Value);
                                break;
                            case "end2":
                                arco.end2 = Convert.ToInt16(reader.Value);
                                break;
                            case "w":
                                arco.w = Convert.ToInt16(reader.Value);
                                break;
                        }
                    }
                    E1.Add(arco);
                }
            }
            reader.Close();
            IEnumerable<Arco> temp = E1.OrderBy(arc => arc.w);
            E1 = temp.ToList();
            #endregion

            for (int i = 0; i < E1.Count; i++)
            {
                if (myUT.findSet(E1[i].end1) != myUT.findSet(E1[i].end2))
                {
                    A.Add(E1[i].id);
                    myUT.union(E1[i].end1, E1[i].end2);
                }
            }

            return A;
        }

        public int[] prim(int r)
        {
            List<int> S = new List<int>();
            IEnumerable<Nodo> temp;
            Nodo[] V1 = V.ToArray();
            for (int i = 0; i < numNodi; i++)
            {
                V1[i].x = int.MaxValue;
                V1[i].y = 0;
            }
            V1[r].x = 0;
            List<Nodo> Q;
            Nodo u;
            bool inQueue = false;

            for (int i = 0; i < numNodi; i++)
            {
                temp = V1.OrderBy(v => v.x);
                Q = temp.ToList();
                for (int j = 0; j < S.Count; j++)
                    Q.Remove(V1[S[j]]);
                u = Q[0];
                S.Add(u.id);
                foreach (Arco arc in E)
                {
                    if (arc.end1 == u.id)
                    {
                        for (int j = 0; j < Q.Count; j++)
                            if (Q[j].id == arc.end2)
                                inQueue = true;
                        if (inQueue)
                        {
                            if (arc.w < V1[arc.end2].x)
                            {
                                V1[arc.end2].x = arc.w;
                                V1[arc.end2].y = u.id;
                            }
                            inQueue = false;
                        }
                    }
                }
            }

            int[] p = new int[numNodi];
            foreach (Nodo v in V1)
                p[v.id] = v.y;

            return p;
        }
    }

    public class GrafoOrientato : Grafo
    {
    }

    public class GrafoNonOrientato : Grafo
    {
    }

    public class UpTree : IUpTree
    {
        private int[] p;
        private int[] rank;

        public UpTree(int n)
        {
            p = new int[n];
            rank = new int[n];
        }

        public int findSet(int x)
        {
            if (x != p[x])
                p[x] = this.findSet(p[x]);
            return p[x];
        }

        public void makeSet(int x)
        {
            p[x] = x;
            rank[x] = 0;
        }

        public void union(int x, int y)
        {
            this.link(this.findSet(x), this.findSet(y));
        }

        private void link(int x, int y)
        {
            if (rank[x] > rank[y])
                p[y] = x;
            else
            {
                p[x] = y;
                if (rank[x] == rank[y])
                    rank[y]++;
            }
        }
    }

    public class MyHeap : IHeap
    {
        private int[] heapInt;
        private double[] heapDouble;
        private string[] heapString;

        public int[] HeapInt { get { return heapInt; } }
        public double[] HeapDouble { get { return heapDouble; } }
        public string[] HeapString { get { return heapString; } }

        public void buildHeap(int[] A)
        {
            heapInt = new int[A.Length];
            for (int i = 0; i < heapInt.Length + 1; i++)
            {
                if (i < A.Length) heapInt[i] = A[i];
                buildHeapInt(i);
            }
        }
        private void buildHeapInt(int i)
        {
            if (i / 2 > 0)
            {
                if (heapInt[i - 1] < heapInt[(i / 2 - 1)])
                {
                    int temp = heapInt[i - 1];
                    heapInt[i - 1] = heapInt[(i / 2 - 1)];
                    heapInt[(i / 2 - 1)] = temp;
                    buildHeapInt(i / 2);
                }
            }
        }
        public void insert(int x)
        {
            try
            {
                int[] tempHeap = new int[heapInt.Length + 1];
                for (int i = 0; i < heapInt.Length; i++)
                    tempHeap[i] = heapInt[i];
                tempHeap[heapInt.Length] = x;
                buildHeap(tempHeap);
            }
            catch
            {
                heapInt = new int[] { x };
            }
        }
        public void extractMin(out int min)
        {
            min = heapInt[0];
            int[] temp = new int[heapInt.Length - 1];
            for (int i = 0; i < temp.Length; i++)
                temp[i] = heapInt[i + 1];
            buildHeap(temp);
        }
        public int showMin()
        {
            return heapInt[0];
        }

        public void buildHeap(double[] A)
        {
            heapDouble = new double[A.Length];
            for (int i = 0; i < heapDouble.Length + 1; i++)
            {
                if (i < A.Length) heapDouble[i] = A[i];
                buildHeapDouble(i);
            }
        }
        private void buildHeapDouble(int i)
        {
            if (i / 2 > 0)
            {
                if (heapDouble[i - 1] < heapDouble[(i / 2 - 1)])
                {
                    double temp = heapDouble[i - 1];
                    heapDouble[i - 1] = heapDouble[(i / 2 - 1)];
                    heapDouble[(i / 2 - 1)] = temp;
                    buildHeapDouble(i / 2);
                }
            }
        }
        public void insert(double x)
        {
            try
            {
                double[] tempHeap = new double[heapDouble.Length + 1];
                for (int i = 0; i < heapDouble.Length; i++)
                    tempHeap[i] = heapDouble[i];
                tempHeap[heapDouble.Length] = x;
                buildHeap(tempHeap);
            }
            catch
            {
                heapDouble = new double[] { x };
            }
        }
        public void extractMin(out double min)
        {
            min = heapDouble[0];
            double[] temp = new double[heapDouble.Length - 1];
            for (int i = 0; i < temp.Length; i++)
                temp[i] = heapDouble[i + 1];
            buildHeap(temp);
        }

        public void buildHeap(string[] A)
        {
            heapString = new string[A.Length];
            for (int i = 0; i < heapString.Length + 1; i++)
            {
                if (i < A.Length) heapString[i] = A[i];
                buildHeapString(i);
            }
        }
        private void buildHeapString(int i)
        {
            if (i / 2 > 0)
            {
                if (heapString[i / 2 - 1].CompareTo(heapString[i - 1]) > 0)
                {
                    string temp = heapString[i - 1];
                    heapString[i - 1] = heapString[(i / 2 - 1)];
                    heapString[(i / 2 - 1)] = temp;
                    buildHeapString(i / 2);
                }
            }
        }
        public void insert(string x)
        {
            try
            {
                string[] tempHeap = new string[heapString.Length + 1];
                for (int i = 0; i < heapString.Length; i++)
                    tempHeap[i] = heapString[i];
                tempHeap[heapString.Length] = x;
                buildHeap(tempHeap);
            }
            catch
            {
                heapString = new string[] { x };
            }
        }
        public void extractMin(out string min)
        {
            min = heapString[0];
            string[] temp = new string[heapString.Length - 1];
            for (int i = 0; i < temp.Length; i++)
                temp[i] = heapString[i + 1];
            buildHeap(temp);
        }
    }

    public class MyHash : IHash
    {
        public List<int>[] hashtable;
        private int m;

        public int NumPos { get { return m; } }

        public MyHash(int M)
        {
            m = M;
            hashtable = new List<int>[m];
        }

        private int hashFunction(int k)
        {
            return k % m;
        }

        public List<int> showTableLine(int k)
        {
            return hashtable[hashFunction(k)];
        }

        public void chainedHashInsert(int x)
        {
            if (chainedHashSearch(x))
                return;
            if (hashtable[hashFunction(x)] == null)
                hashtable[hashFunction(x)] = new List<int>();
            hashtable[hashFunction(x)].Insert(0, x);
        }

        public bool chainedHashSearch(int k)
        {
            if (hashtable[hashFunction(k)] != null)
                foreach (int value in hashtable[hashFunction(k)])
                    if (value == k)
                        return true;
            return false;
        }

        public bool chainedHashDelete(int x)
        {
            if (hashtable[hashFunction(x)] != null)
            {
                foreach (int value in hashtable[hashFunction(x)])
                {
                    if (value == x)
                    {
                        hashtable[hashFunction(x)].Remove(x);
                        return true;
                    }
                }
            }
            return false;
        }
    }

    public class GraphSearch : IGraphSearch
    {
        private Grafo G;
        public int[] d;
        public int[] f;
        public int[] p;
        public enum nColor { white, gray, black };
        public nColor[] nodeColor;

        public GraphSearch()
        {
            G = new Grafo();
            G.readXMLgraph("Grafo.xml");
            nodeColor = new nColor[G.numNodi];
        }

        public void depthFirst()
        {
            d = new int[G.numNodi];
            f = new int[G.numNodi];
            p = new int[G.numNodi];

            int time = 0;
            for (int u = 0; u < G.numNodi; u++)
            {
                nodeColor[u] = nColor.white;
                p[u] = -1;
            }
            for (int u = 0; u < G.numNodi; u++)
            {
                if (nodeColor[u] == nColor.white)
                {
                    dfs_visit(u, ref time);
                }
            }
        }
        private void dfs_visit(int u, ref int time)
        {
            time++;
            d[u] = time;
            nodeColor[u] = nColor.gray;
            for (int v = 0; v < G.numNodi; v++)
            {
                for (int i = 0; i < G.numArchi; i++)
                {
                    if (G.E[i].end1 == u && G.E[i].end2 == v)
                    {
                        if (nodeColor[v] == nColor.white)
                        {
                            p[v] = u;
                            dfs_visit(v, ref time);
                        }
                    }
                }
            }
            nodeColor[u] = nColor.black;
            time++;
            f[u] = time;
        }

        public void breadthFirst(int s)
        {
            d = new int[G.numNodi];
            f = new int[G.numNodi];
            p = new int[G.numNodi];

            int u;
            List<int> Q = new List<int>();
            for (int v = 0; v < G.numNodi; v++)
            {
                d[v] = -1;
                nodeColor[v] = nColor.white;
                p[v] = -1;
            }

            d[s] = 0;
            nodeColor[s] = nColor.gray;
            Q.Add(s);

            while (Q.Count != 0)
            {
                u = Q[0];
                Q.Remove(Q[0]);
                for (int i = 0; i < G.numArchi; i++)
                {
                    if (G.E[i].end1 == u && nodeColor[G.E[i].end2] == nColor.white)
                    {
                        nodeColor[G.E[i].end2] = nColor.gray;
                        d[G.E[i].end2] = d[u] + 1;
                        p[G.E[i].end2] = u;
                        Q.Add(G.E[i].end2);
                    }
                }
                nodeColor[u] = nColor.black;
            }
        }
    }

    public class ArrayPQ : IPriorityQueue
    {
        private int[] PQ;
        public int Length;

        public ArrayPQ(int length)
        {
            PQ = new int[length];
            Length = 0;
        }

        public bool insert(int i)
        {
            try
            {
                PQ[Length] = i;
                Length++;
                i = 0;
                int temp;
                for (int j = 1; j < Length; j++)
                {
                    temp = PQ[j];
                    i = j;
                    while (i > 0 && PQ[i - 1] >= temp)
                    {
                        PQ[i] = PQ[i - 1];
                        i--;
                    }
                    PQ[i] = temp;
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public int findMin()
        {
            return PQ[0];
        }

        public int extractMin()
        {
            int[] temp = PQ;
            PQ = new int[temp.Length - 1];
            for (int i = 0; i < PQ.Length; i++)
                PQ[i] = temp[i + 1];
            Length--;
            return temp[0];
        }
    }

    public class HeapPQ : IPriorityQueue
    {
        private MyHeap PQ;

        public HeapPQ()
        {
            PQ = new MyHeap();
        }

        public bool insert(int i)
        {
            try
            {
                PQ.insert(i);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public int findMin()
        {
            return PQ.showMin();
        }

        public int extractMin()
        {
            int min;
            PQ.extractMin(out min);
            return min;
        }
    }
}
