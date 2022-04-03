using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Node
    {
        //properties 
        public int state { set; get; }
        public int depth { set; get; }
        public int pathcost { set; get; }
        public Node parent { set; get; }
        //constractors
        //root 
        public Node()
        {
            this.state = 0;
            this.depth = 0;
            this.pathcost = 0;
            this.parent = null;
        }
        //root changed 
        public Node(int state)
        {
            this.state = state;
            this.depth = 0;
            this.pathcost = 0;
            this.parent = null;
        }
        //children
        public Node(Node parent, int state)
        {
            this.state = state;
            this.parent = parent;
            this.depth = parent.depth + 1;
            this.pathcost = parent.pathcost + 1;
        }
        public Node(int state, Node parent, int stopcost)
        {
            this.state = state;
            this.parent = parent;
            this.depth = parent.depth + 1;
            this.pathcost = parent.pathcost + stopcost;
        }
        public Node[] getchildren()
        {
            Node[] children = new Node[2];
            children[0] = new Node(this, this.state * 2 + 1);
            children[1] = new Node(this, this.state * 2 + 2);
            return children;
        }

    }
    class UninformedSearch
    {
        // Goal 
        public void BFS(int GoalState)
        {
            //queue
            Queue<Node> BFS = new Queue<Node>();
            //enqueue
            Node initalState = new Node();
            BFS.Enqueue(initalState);
            while (BFS.Count != 0)
            {
                //remove 
                Node currentNode = BFS.Dequeue();
                if (currentNode.state == GoalState)
                {
                    //retuen solution --"path"-- 
                    List<int> solution = new List<int>();
                    while (currentNode != null)
                    {
                        solution.Insert(0, currentNode.state);
                        currentNode = currentNode.parent;
                    }
                    foreach (var item in solution)
                    {
                        Console.WriteLine(item);
                    }
                    //end program
                    break;
                }
                else
                {
                    //add children 
                    foreach (var item in currentNode.getchildren())
                    {
                        BFS.Enqueue(item);
                    }
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the goal state : ");
            int Goal = int.Parse(Console.ReadLine());
            UninformedSearch uni = new UninformedSearch();
            uni.BFS(Goal);
            Console.ReadKey();
        }
    }
}


