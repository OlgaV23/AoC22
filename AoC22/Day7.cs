namespace AoC22;

class Node
{
    public Node(string name, int size, Node? parentNode, List<Node>? childNodes)
    {
        Name = name;
        Size = size;
        ParentNode = parentNode;
        ChildNodes = childNodes;
    }

    public string Name { get; set; }
    public int Size { get; set; }
    public Node? ParentNode { get; set; }
    public List<Node>? ChildNodes { get; set; }
}

public class Day7
{
    public static void Data()
    {
        var text = File.ReadAllText(
            @"C:\Users\miair\Desktop\_Proj\_AoC22\AoC22\InputFiles\Day7TestInput.txt");

        List<Node> res = new();
        Node currentNode = null;

        var data = text.Split("\n").ToList().Select(x => x.TrimEnd());

        foreach (var command in data)
        {
            if (command.StartsWith('$'))
            {

                if (command.StartsWith("$ cd"))
                {
                    var commandTemp = command.Remove(0, 5);

                    switch (commandTemp)
                    {
                        case "/":
                            currentNode = new Node("/", 0, null, new());
                            res.Add(currentNode);
                            break;
                        case "..":
                            currentNode = currentNode.ParentNode;
                            break;
                        default:
                            currentNode =
                                currentNode.ChildNodes.First(x => x.Name == command.Remove(0, 5));
                            break;
                    }
                }
            }

            else
            {
                if (command.StartsWith("dir"))
                {
                    var newNode = new Node(
                        command.Remove(0, 4),
                        0,
                        currentNode,
                        new List<Node>()
                    );

                    currentNode.ChildNodes.Add(newNode);
                }
                else
                {
                    var newNode = new Node(
                        command.Split(' ')[1],
                        int.Parse(command.Split(' ')[0]),
                        currentNode,
                        new List<Node>()
                    );

                    currentNode.Size += newNode.Size;

                    currentNode.ChildNodes.Add(newNode);
                }
            }
        }

    }


    public static int Result()
    {
        return 0;
    }

    public static int Result2()
    {
        return 0;
    }
}