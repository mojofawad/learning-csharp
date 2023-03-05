using System.CommandLine;

namespace scl;

class Program
{
    static async Task<int> Main(string[] args)
    {
        /*      Commented out to be replaced with final piece of app
        
        // Create option named --file of type FileInfo
        var fileOption = new Option<FileInfo?>(
            name: "--file",
            description: "The file to read and display on the console.");

        */

        // Create option named --file
        var fileOption = new Option<FileInfo?>(
            name: "--file",
            description: "An option whose argument is parsed as a FileInfo",
            isDefault: true,
            // Use ParseArgument<T> to provide custom parsing, validation, and error handling
            parseArgument: result =>
            {
                if (result.Tokens.Count == 0)
                {
                    return new FileInfo("sampleQuotes.txt");
                }
                string? filePath = result.Tokens.Single().Value;
                if (!File.Exists(filePath))
                {
                    result.ErrorMessage = "File does not exist";
                    return null;
                }
                else
                {
                    return new FileInfo(filePath);
                }
            });


        // Create options to control the readout speed and text colors
        var delayOption = new Option<int>(
            name: "--delay",
            description: "Delay between lines, specified as milliseconds per character in a line.",
            getDefaultValue: () => 42);

        var fgcolorOption = new Option<ConsoleColor>(
            name: "--fgcolor",
            description: "Foreground color of text displayed on the console.",
            getDefaultValue: () => ConsoleColor.White);

        var lightModeOption = new Option<bool>(
            name: "--light-mode",
            description: "Background color of the text displayed on the console.");
        
        // Create options for add and delete commands
        var searchTermsOption = new Option<string[]>(
            name: "--search-terms",
            description: "Strings to search for when deleting entries.")
            // Allow for the omission of --search-terms
            { IsRequired = true, AllowMultipleArgumentsPerToken = true };
            //                      Example
            // scl quotes delete --search-terms David "You can do"
            // scl quotes delete --search-terms David --search-terms "You can do"

        var quoteArgument = new Argument<string>(
            name: "quote",
            description: "Text of quote.");

        var bylineArgument = new Argument<string>(
            name: "byline",
            description: "Byline of quote.");

        /*
                Completely replacing the rootCommand and readCommand
        // Assign option to root command
        var rootCommand = new RootCommand("Sample app for System.CommandLine");
        //rootCommand.AddOption(fileOption); // Removed (commented out) so we can add a new subcommand
        
        // Create `read` subcommand
        var readCommand = new Command("read", "Read and display the file.")
            {
                fileOption,
                delayOption,
                fgcolorOption,
                lightModeOption
            };
        // Add subcommand to the root command
        rootCommand.AddCommand(readCommand);
        */

        var rootCommand = new RootCommand("Sample app for System.CommandLine");
        rootCommand.AddGlobalOption(fileOption);

        var quotesCommand = new Command("quotes", "Work with a file that contains quotes.");
        rootCommand.AddCommand(quotesCommand);

        var readCommand = new Command("read", "Read and display the file.")
            {
                delayOption,
                fgcolorOption,
                lightModeOption
            };
        quotesCommand.AddCommand(readCommand);

        var deleteCommand = new Command("delete", "Delete lines from the file.");
        deleteCommand.AddOption(searchTermsOption);
        quotesCommand.AddCommand(deleteCommand);

        var addCommand = new Command("add", "Add an entry to the file.");
        addCommand.AddArgument(quoteArgument);
        addCommand.AddArgument(bylineArgument);
        addCommand.AddAlias("insert");
        quotesCommand.AddCommand(addCommand);

        // new command hierarchy:
        //      - quotes
        //          - read
        //          - add
        //          - delete


        /*      
                Commented out and replaced with SetHandler code below
                Done for the new subcommand
        // Calls the ReadFile method
        rootCommand.SetHandler((file) => 
            { 
                ReadFile(file!); 
            },
            fileOption);

        return await rootCommand.InvokeAsync(args);
        */

        // Calls the ReadFile method
        // No longer calls SetHandler on root command
        // Root command no longer needs a handler
        readCommand.SetHandler(async (file, delay, fgcolor, lightMode) =>
            {
                await ReadFile(file!, delay, fgcolor, lightMode);
            },
            fileOption, delayOption, fgcolorOption, lightModeOption);
        
        deleteCommand.SetHandler((file, searchTerms) =>
            {
                DeleteFromFile(file!, searchTerms);
            },
            fileOption, searchTermsOption);

        addCommand.SetHandler((file, quote, byline) =>
            {
                AddToFile(file!, quote, byline);
            },
            fileOption, quoteArgument, bylineArgument);

        return rootCommand.InvokeAsync(args).Result;
    }


    /*
            Commented out and replace with code below
    // Displays the contents of the specified
    // file when the root command is invoked
    static void ReadFile(FileInfo file)
    {
        File.ReadLines(file.FullName).ToList()
            .ForEach(line => Console.WriteLine(line));
    }
    */

    // Displays contents of the specified file
    internal static async Task ReadFile(
        FileInfo file, int delay, ConsoleColor fgColor, bool lightMode)
    {
        Console.BackgroundColor = lightMode ? ConsoleColor.White : ConsoleColor.Black;
        Console.ForegroundColor = fgColor;
        List<string> lines = File.ReadLines(file.FullName).ToList();
        foreach (string line in lines)
        {
            Console.WriteLine(line);
            await Task.Delay(delay * line.Length);
        };
    }

    // Add handlers for add and delete
    internal static void DeleteFromFile(FileInfo file, string[] searchTerms)
    {
        Console.WriteLine("Deleting from file");
        File.WriteAllLines(
            file.FullName, File.ReadLines(file.FullName)
                .Where(line => searchTerms.All(s => !line.Contains(s))).ToList());
    } 
    internal static void AddToFile(FileInfo file, string quote, string byline)
    {
        Console.WriteLine("Adding to file");
        using StreamWriter? writer = file.AppendText();
        writer.WriteLine($"{Environment.NewLine}{Environment.NewLine}{quote}");
        writer.WriteLine($"{Environment.NewLine}-{byline}");
        writer.Flush();
    }
}

