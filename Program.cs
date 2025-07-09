namespace NOVA_CLI;
public class Program
{
    public static async Task<int> Main(string[] args)
    {
        var app = new NovaCLI();

        // Important for spin animations etc..
        Console.OutputEncoding = System.Text.Encoding.UTF8;


        if (args.Length > 0)
        {
            return await app.RunAsync(args);
        }


        Startup.ShowGreeting();

        while (true)
        {
            Console.Write("> ");
            var input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
                continue;

            if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                break;

            if(input.Equals("cls", StringComparison.OrdinalIgnoreCase) || input.Equals("clear", StringComparison.OrdinalIgnoreCase))
            {       
                Console.Clear();
                continue;
            }



            var inputArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            try
            {
                await app.RunAsync(inputArgs);
            } catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            
        }

        return 0;

        

        
        
    }
}
