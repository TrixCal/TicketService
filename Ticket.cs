using System;
using System.Collections.Generic;

namespace TicketService
{
    public class Ticket
    {
        public int ticketID { get; set; }
        public string summary { get; set; }
        public string status { get; set; }
        public string priority { get; set; }
        public string submitter { get; set; }
        public string assigned { get; set; }
        public List<string> watching { get; set; }

        public virtual string Display()
        {
            return $"Ticket {ticketID} \nSummary) {summary} \nStatus) {status}\nPriority) {priority}\nSubmitter) {submitter}\nAssigned) {assigned}\nWatching) {string.Join(", ", watching)}";
        }
        public override string ToString()
        {
            return $"{ticketID},{summary},{status},{priority},{submitter},{assigned},{string.Join("|", watching)}";
        }
        public virtual void TicketSubmit()
        {
            Console.WriteLine("Enter ticket summary: ");
            summary = Console.ReadLine();
            Console.WriteLine("Ticket status: ");
            status = Console.ReadLine();
            Console.WriteLine("Ticket priority: ");
            priority = Console.ReadLine();
            Console.WriteLine("Submitted by: ");
            submitter = Console.ReadLine();
            Console.WriteLine("Assigned to: ");
            assigned = Console.ReadLine();
            Console.WriteLine("Watched by: (Type \"0\" to Stop)");
            string watch = "";
            while(watch != "0"){
                watch = Console.ReadLine();
                if(watch != "0") watching.Add(watch);
            }
        }
    }
    public class Bug : Ticket
    {
        public string severity { get; set; }
        public override string Display()
        {
            return $"Ticket {ticketID} \nSummary) {summary} \nStatus) {status}\nPriority) {priority}\nSubmitter) {submitter}\nAssigned) {assigned}\nWatching) {string.Join(", ", watching)}\nSeverity) {severity}";
        }
        public override string ToString()
        {
            return $"{ticketID},{summary},{status},{priority},{submitter},{assigned},{string.Join("|", watching)},{severity}";
        }
        public override void TicketSubmit()
        {
            Console.WriteLine("Enter ticket summary: ");
            summary = Console.ReadLine();
            Console.WriteLine("Ticket status: ");
            status = Console.ReadLine();
            Console.WriteLine("Ticket priority: ");
            priority = Console.ReadLine();
            Console.WriteLine("Submitted by: ");
            submitter = Console.ReadLine();
            Console.WriteLine("Assigned to: ");
            assigned = Console.ReadLine();
            Console.WriteLine("Watched by: (Type \"0\" to Stop)");
            watching = new List<string>();
            string watch = "";
            while(watch != "0"){
                watch = Console.ReadLine();
                if(watch != "0") watching.Add(watch);
            }
            Console.WriteLine("Severity: ");
            severity = Console.ReadLine();
        }
    }
    public class Enhancement : Ticket
    {
        public string software { get; set; }
        public double cost { get; set; }
        public string reason { get; set; }
        public double estimate { get; set; }
        public override string Display()
        {
            return $"Ticket {ticketID} \nSummary) {summary} \nStatus) {status}\nPriority) {priority}\nSubmitter) {submitter}\nAssigned) {assigned}\nWatching) {string.Join(", ", watching)}\nSoftware) {software}\nCost) {cost:C}\nReason) {reason}\nEstimate) {estimate:C}";
        }
        public override string ToString()
        {
            return $"{ticketID},{summary},{status},{priority},{submitter},{assigned},{string.Join("|", watching)},{software},{cost},{reason},{estimate}";
        }
        public override void TicketSubmit()
        {
            Console.WriteLine("Enter ticket summary: ");
            summary = Console.ReadLine();
            Console.WriteLine("Ticket status: ");
            status = Console.ReadLine();
            Console.WriteLine("Ticket priority: ");
            priority = Console.ReadLine();
            Console.WriteLine("Submitted by: ");
            submitter = Console.ReadLine();
            Console.WriteLine("Assigned to: ");
            assigned = Console.ReadLine();
            Console.WriteLine("Watched by: (Type \"0\" to Stop)");
            watching = new List<string>();
            string watch = "";
            while(watch != "0"){
                watch = Console.ReadLine();
                if(watch != "0") watching.Add(watch);
            }
            Console.WriteLine("Software: ");
            software = Console.ReadLine();
            Console.WriteLine("Cost(Leave out signs): ");
            cost = Double.Parse(Console.ReadLine());
            Console.WriteLine("Reason: ");
            reason = Console.ReadLine();
            Console.WriteLine("Estimated Total Cost: ");
            estimate = double.Parse(Console.ReadLine());
        }
    }
    public class Task : Ticket
    {
        public string projectName { get; set; }
        public DateTime duedate { get; set; }
        public override string Display()
        {
            return $"Ticket {ticketID} \nSummary) {summary} \nStatus) {status}\nPriority) {priority}\nSubmitter) {submitter}\nAssigned) {assigned}\nWatching) {string.Join(", ", watching)}\nProject Name) {projectName}\nDue Date) {duedate:d}";
        }
        public override string ToString()
        {
            return $"{ticketID},{summary},{status},{priority},{submitter},{assigned},{string.Join("|", watching)},{projectName},{duedate}";
        }
        public override void TicketSubmit()
        {
            Console.WriteLine("Enter ticket summary: ");
            summary = Console.ReadLine();
            Console.WriteLine("Ticket status: ");
            status = Console.ReadLine();
            Console.WriteLine("Ticket priority: ");
            priority = Console.ReadLine();
            Console.WriteLine("Submitted by: ");
            submitter = Console.ReadLine();
            Console.WriteLine("Assigned to: ");
            assigned = Console.ReadLine();
            Console.WriteLine("Watched by: (Type \"0\" to Stop)");
            watching = new List<string>();
            string watch = "";
            while(watch != "0"){
                watch = Console.ReadLine();
                if(watch != "0") watching.Add(watch);
            }
            Console.WriteLine("Task name: ");
            projectName = Console.ReadLine();
            Console.WriteLine("Due Date (M/D/YYYY): ");
            duedate = DateTime.Parse(Console.ReadLine());
        }
    }
}