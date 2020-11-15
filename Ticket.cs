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
    }
    public class Bug : Ticket
    {
        public string severity { get; set; }
        public override string Display()
        {
            return $"Ticket {ticketID} \nSummary) {summary} \nStatus) {status}\nPriority) {priority}\nSubmitter) {submitter}\nAssigned) {assigned}\nWatching) {string.Join(", ", watching)}\nSeverity) {severity}";
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
    }
    public class Task : Ticket
    {
        public string projectName { get; set; }
        public DateTime duedate { get; set; }
        public override string Display()
        {
            return $"Ticket {ticketID} \nSummary) {summary} \nStatus) {status}\nPriority) {priority}\nSubmitter) {submitter}\nAssigned) {assigned}\nWatching) {string.Join(", ", watching)}\nProject Name) {projectName}\nDue Date) {duedate:d}";
        }
    }
}