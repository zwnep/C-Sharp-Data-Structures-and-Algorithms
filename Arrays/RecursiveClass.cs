internal class Program
{
    private static void Main(string[] args)
    {

        Node head = null;

        for (int i = 0; i < 10; i++)
        {
            Node node = new Node();
            node.data = i;
            if (head == null)
            {
                head = node;
            }
            Node currentNode = head;
            while (currentNode.next != null)
            {
                currentNode = currentNode.next;
            }
            currentNode.next = node;
        }

        while (head != null)
        {
            Console.WriteLine(head);
            head = head.next;
        }

    }
}

class Node
{
    public int data;
    public Node next;
}
