using NLog;

public class TicketsFile
{
    public string filePath { get; set; }
    public List<Ticket> tickets { get; set; }

    public TicketsFile()
    {
        
    }

    public void ReadBugTicket(string ticketFile)
    {

        tickets = new List<Ticket>();
        // read data from file
        if (File.Exists(ticketFile))
        {
            // read data from file
            StreamReader sr = new StreamReader(ticketFile);
            while (!sr.EndOfStream)
            {
                Bug bugTicket = new Bug();
                string line = sr.ReadLine();
                //convert string to array
                string[] ticketDetails = line.Split('|');
                //display array data
                //Console.WriteLine("TicketID: {0}, Summary: {1}, Status: {2}, Priority: {3}, Submitter: {4}, Assigned: {5}, Watching: {6}", arr[0], arr[1], arr[2], arr[3], arr[4], arr[5], arr[6]);
                bugTicket.ticketId = ticketDetails[0];
                bugTicket.summary = ticketDetails[1];
                bugTicket.status = ticketDetails[2];
                bugTicket.priority = ticketDetails[3];
                bugTicket.submitter = ticketDetails[4];
                bugTicket.assigned = ticketDetails[5];
                bugTicket.watching = ticketDetails[6];
                bugTicket.severity = ticketDetails[7];

                tickets.Add(bugTicket);
            }
        
            sr.Close();
        }
        else
        {
            Console.WriteLine("File does not exist");
        }
    }

    public void AddTicket(Ticket ticket)
    {
        filePath = "Tickets.txt";
        StreamWriter sw = new StreamWriter(filePath, true);
        sw.WriteLine($"{ticket.ticketId}|{ticket.summary}|{ticket.status}|{ticket.priority}|{ticket.submitter}|{ticket.assigned}|{ticket.watching}");
        sw.Close();
    }

    public void AddBug(Bug bug)
    {
        filePath = "BugTickets.txt";
        StreamWriter sw = new StreamWriter(filePath, true);
        sw.WriteLine($"{bug.ticketId}|{bug.summary}|{bug.status}|{bug.priority}|{bug.submitter}|{bug.assigned}|{bug.watching}|{bug.severity}");
        sw.Close();
    }

    public void AddEnhancement(Enhancement enhancement)
    {
        filePath = "EnhancementTickets.txt";
        StreamWriter sw = new StreamWriter(filePath, true);
        sw.WriteLine($"{enhancement.ticketId}|{enhancement.summary}|{enhancement.status}|{enhancement.priority}|{enhancement.submitter}|{enhancement.assigned}|{enhancement.watching}|{enhancement.software}|{enhancement.cost}|{enhancement.reason}|{enhancement.estimate}");
        sw.Close();
    }

    public void AddTask(Task task)
    {
        filePath = "TaskTickets.txt";
        StreamWriter sw = new StreamWriter(filePath, true);
        sw.WriteLine($"{task.ticketId}|{task.summary}|{task.status}|{task.priority}|{task.submitter}|{task.assigned}|{task.watching}|{task.projectName}|{task.dueDate}");
        sw.Close();
    }
}