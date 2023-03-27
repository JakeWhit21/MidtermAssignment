using NLog;

// See https://aka.ms/new-console-template for more information
string path = Directory.GetCurrentDirectory() + "\\nlog.config";

// create instance of Logger
var logger = LogManager.LoadConfiguration(path).GetCurrentClassLogger();
logger.Info("Program started");

string bugFile = "BugTickets.txt";
string enhancementsFile = "EnhancementTickets.txt";
string taskFile = "TaskTickets.txt";
string choice;
string ticketChoice;

TicketsFile ticketsFile = new TicketsFile();

do
{
    //ask user a question
    Console.WriteLine("1) Read data from file.");
    Console.WriteLine("2) Create file from data or add ticket to file.");
    Console.WriteLine("3) Search for ticket.");
    Console.WriteLine("Enter any other key to exit.");
    // input response
    choice = Console.ReadLine();

    if (choice == "1")
    {
        Console.WriteLine("Which ticket do you want to enter?");
        Console.WriteLine("1) Bug");
        Console.WriteLine("2) Enhancement");
        Console.WriteLine("3) Task");
        ticketChoice = Console.ReadLine();

        if (ticketChoice == "1")
        {
            ticketsFile.ReadBugTicket(bugFile);
            foreach (Bug b in ticketsFile.tickets)
            {
                Console.WriteLine(b.Display());
            }
        }
        else if (ticketChoice == "2")
        {
            ticketsFile.ReadEnhancementTicket(enhancementsFile);
            foreach (Enhancement e in ticketsFile.tickets)
            {
                Console.WriteLine(e.Display());
            }
        }
        else if (ticketChoice == "3")
        {
            ticketsFile.ReadTaskTicket(taskFile);
            foreach (Task t in ticketsFile.tickets)
            {
                Console.WriteLine(t.Display());
            }
        }


    }
    else if (choice == "2")
    {
        Console.WriteLine("Which ticket do you want to enter?");
        Console.WriteLine("1) Bug");
        Console.WriteLine("2) Enhancement");
        Console.WriteLine("3) Task");
        ticketChoice = Console.ReadLine();

        if (ticketChoice == "1")
        {
            Bug bug = new Bug();

            Console.WriteLine("Enter ticket ID");
            bug.ticketId = Console.ReadLine();

            Console.WriteLine("Enter the summary for the ticket: ");
            bug.summary = Console.ReadLine();

            Console.WriteLine("Enter status: ");
            bug.status = Console.ReadLine();

            Console.WriteLine("Enter priority: ");
            bug.priority = Console.ReadLine();

            Console.WriteLine("Enter submitter: ");
            bug.submitter = Console.ReadLine();

            Console.WriteLine("Enter person assigned to: ");
            bug.assigned = Console.ReadLine();

            Console.WriteLine("Enter person watching: ");
            bug.watching = Console.ReadLine();

            Console.WriteLine("Enter severity: ");
            bug.severity = Console.ReadLine();

            ticketsFile.AddBug(bug);
        }
        else if (ticketChoice == "2")
        {
            Enhancement enhancement = new Enhancement();

            Console.WriteLine("Enter ticket ID");
            enhancement.ticketId = Console.ReadLine();

            Console.WriteLine("Enter the summary for the ticket: ");
            enhancement.summary = Console.ReadLine();

            Console.WriteLine("Enter status: ");
            enhancement.status = Console.ReadLine();

            Console.WriteLine("Enter priority: ");
            enhancement.priority = Console.ReadLine();

            Console.WriteLine("Enter submitter: ");
            enhancement.submitter = Console.ReadLine();

            Console.WriteLine("Enter person assigned to: ");
            enhancement.assigned = Console.ReadLine();

            Console.WriteLine("Enter person watching: ");
            enhancement.watching = Console.ReadLine();

            Console.WriteLine("Enter software: ");
            enhancement.software = Console.ReadLine();

            Console.WriteLine("Enter cost: ");
            enhancement.cost = Console.ReadLine();

            Console.WriteLine("Enter reason: ");
            enhancement.reason = Console.ReadLine();

            Console.WriteLine("Enter estimate: ");
            enhancement.estimate = Console.ReadLine();

            ticketsFile.AddEnhancement(enhancement);
        }
        else if (ticketChoice == "3")
        {
            Task task = new Task();

            Console.WriteLine("Enter ticket ID");
            task.ticketId = Console.ReadLine();

            Console.WriteLine("Enter the summary for the ticket: ");
            task.summary = Console.ReadLine();

            Console.WriteLine("Enter status: ");
            task.status = Console.ReadLine();

            Console.WriteLine("Enter priority: ");
            task.priority = Console.ReadLine();

            Console.WriteLine("Enter submitter: ");
            task.submitter = Console.ReadLine();

            Console.WriteLine("Enter person assigned to: ");
            task.assigned = Console.ReadLine();

            Console.WriteLine("Enter person watching: ");
            task.watching = Console.ReadLine();

            Console.WriteLine("Enter project name: ");
            task.projectName = Console.ReadLine();

            Console.WriteLine("Enter due date: ");
            task.dueDate = Console.ReadLine();

            ticketsFile.AddTask(task);
        }


        // Ticket ticket = new Ticket();

        // Console.WriteLine("Enter ticket ID");
        // ticket.ticketId = Console.ReadLine();

        // Console.WriteLine("Enter the summary for the ticket: ");
        // ticket.summary = Console.ReadLine();

        // Console.WriteLine("Enter status: ");
        // ticket.status = Console.ReadLine();

        // Console.WriteLine("Enter priority: ");
        // ticket.priority = Console.ReadLine();

        // Console.WriteLine("Enter submitter: ");
        // ticket.submitter = Console.ReadLine();

        // Console.WriteLine("Enter person assigned to: ");
        // ticket.assigned = Console.ReadLine();

        // Console.WriteLine("Enter person watching: ");
        // ticket.watching = Console.ReadLine();

        // ticketsFile.AddTicket(ticket);
    }
    else if (choice == "3")
    {
        Console.WriteLine("Enter a part of the ticket to search by: ");
        Console.WriteLine("1) status");
        Console.WriteLine("2) priority");
        Console.WriteLine("3) submitter");
        string input = Console.ReadLine();

        switch (input)
        {
            case "1":
                Console.WriteLine("Which ticket? ");
                Console.WriteLine("1) Bug");
                Console.WriteLine("2) Enhancement");
                Console.WriteLine("3) Task");
                string input2 = Console.ReadLine();

                // // LINQ - Where filter operator & Select projection operator & Contains quantifier operator
                // var titles = movieFile.Movies.Where(m => m.title.Contains("Shark")).Select(m => m.title);
                // // LINQ - Count aggregation method
                // Console.WriteLine($"There are {titles.Count()} movies with \"Shark\" in the title:");
                // foreach (string t in titles)
                // {
                //     Console.WriteLine($"  {t}");
                // }

                if (input2 == "1")
                {
                    ticketsFile.ReadBugTicket(bugFile);
                    Console.WriteLine("Enter something to search for: ");
                    var statusSearch = Console.ReadLine();

                    var statusSearchResults = ticketsFile.tickets.Where(t => t.status.Contains(statusSearch)).Select(t => t.ticketId);
                    Console.WriteLine($"There are {statusSearchResults.Count()} tickets with {statusSearch} as the status: ");
                    foreach (string s in statusSearchResults){
                        Console.WriteLine($"   Ticket ID: {s}");
                    }


                }
                else if (input2 == "2")
                {

                }
                else if (input2 == "3")
                {

                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
                break;

            case "2":

                break;

            case "3":

                break;

            default:
                Console.WriteLine("Wrong input. Try again.");
                break;
        }
    }
} while (choice == "1" || choice == "2");


logger.Info("Program ended");