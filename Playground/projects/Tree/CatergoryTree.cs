namespace Playground.projects.Tree.CatergoryTree;



public static class Program
{
    
    public static Category InitTree()
    {
        var root = new Category("root");

        // First level categories
        var furniture = new Category("furniture");
        var electronic = new Category("electronic");
        var clothing = new Category("clothing");

        // Furniture subcategories
        var table = new Category("table");
        var chair = new Category("chair");
        var bed = new Category("bed");

        furniture.Childs.Add(table);
        furniture.Childs.Add(chair);
        furniture.Childs.Add(bed);

        // Electronics subcategories
        var phone = new Category("phone");
        var laptop = new Category("laptop");
        var tv = new Category("tv");

        electronic.Childs.Add(phone);
        electronic.Childs.Add(laptop);
        electronic.Childs.Add(tv);

        // Clothing subcategories
        var men = new Category("men");
        var women = new Category("women");

        clothing.Childs.Add(men);
        clothing.Childs.Add(women);

        // Men's clothing subcategories
        var shirts = new Category("shirts");
        var pants = new Category("pants");

        men.Childs.Add(shirts);
        men.Childs.Add(pants);

        // Women's clothing subcategories
        var dresses = new Category("dresses");
        var skirts = new Category("skirts");

        women.Childs.Add(dresses);
        women.Childs.Add(skirts);

        // Add top-level categories to root
        root.Childs.Add(furniture);
        root.Childs.Add(electronic);
        root.Childs.Add(clothing);

        return root;
    }

    public static string IsCategoryExists(Category root, string name)
    {
        var stack = new Stack<Category>();
        
        stack.Push(root);

        while (stack.Count > 0)
        {
            var current = stack.Pop();

            if (current.Name == name)
                return current.Name;
            
            foreach (var child in current.Childs)
            {
                stack.Push(child);
            }
        }
        
        throw new Exception("Category does not exist");
    }
    
    public static List<string> DisplayTree(Category root)
    {
        var stack = new Stack<Category>();
        var result = new List<string>();
        
        stack.Push(root);

        while (stack.Count > 0)
        {
            var current = stack.Pop();

            foreach (var child in current.Childs)
            {
                stack.Push(child);
            }
            
            result.Add(current.Name);
        }
        
        return result;
    }
    
    public static void AddChildToCategory(Category root, Category childCategory, string searchingCategory)
    {
        var stack = new Stack<Category>();
        
        stack.Push(root);

        while (stack.Count > 0)
        {
            var current = stack.Pop();
            
            if (current.Name == searchingCategory)
            {
                current.Childs.Add(childCategory);
                break;
            }
        }
    }
    
    public static List<string> FindChildrenByName(Category root, string name)
    {
        var stack = new Stack<Category>();
        var result = new List<string>();
        
        stack.Push(root);

        while (stack.Count > 0)
        {
            var current = stack.Pop();
            
            foreach (var child in current.Childs)
            {
                stack.Push(child);
            }

            if (current.Name == name)
            {
                foreach (var child in current.Childs)
                {
                    result.Add(child.Name);
                }

                break;
            }
        }
        
        return result;
    }
    
    public static List<string> GetAllWithoutChildren(Category root)
    {
        var stack = new Stack<Category>();
        var result = new List<string>();
        
        stack.Push(root);

        while (stack.Count > 0)
        {
            var current = stack.Pop();

            if (current.Childs.Count == 0)
            {
                result.Add(current.Name);
            }
            
            foreach (var child in current.Childs)
            {
                stack.Push(child);
            }
        }
        
        return result;
    }
    
    public static void Start()
    {
        var tree = InitTree();
        // var res = DisplayTree(tree);
        // var res = FindChildrenByName(tree, "furniture");

        // var product = new Product(5, IsCategoryExists(tree, "chair"));

        // var res = GetAllWithoutChildren(tree); 
        //
        // foreach (var result in res)
        // {
        //     Console.WriteLine(result);
        // }

        var date1 = DateTime.Today;
        Console.WriteLine(date1);
        var date2 = DateTime.Now;
        Console.WriteLine(date2);
        Console.WriteLine(date2 - date1);

        
    }
}

public class Product
{
    public Product(int price, string category)
    {
        Price = price;
        Category = category;
    }

    public string Category { get; set; }
    
    public int Price { get; init; }
}

public class Category
{
    public Category(string name)
    {
        Name = name;
    }

    public Guid Id { get; init; } = Guid.NewGuid();
    
    public string Name { get; set; }
    
    public List<Category> Childs { get; set; } = new List<Category>();
}