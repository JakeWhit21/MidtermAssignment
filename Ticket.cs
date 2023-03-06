public class Ticket
{
    public string ticketId { get; set; }
    public string summary { get; set; }
    public string status { get; set; }
    public string priority { get; set; }
    public string submitter { get; set; }
    public string assigned { get; set; }
    public string watching { get; set; }

    public Ticket()
    {
        
    }

    public string Display()
    {
        return $"Id: {ticketId}\nSummary: {summary}\nStatus: {status}\nPriority: {priority}\nSubmitter: {submitter}\nAssigned to: {assigned}\nWatching: {watching}";
    }
}