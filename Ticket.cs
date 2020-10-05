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

        public Ticket(string[] ticketArray)
        {
            summary = ticketArray[0];
            status = ticketArray[1];
            priority = ticketArray[2];
            submitter = ticketArray[3];
            assigned = ticketArray [4];
            watching = new List<string>(ticketArray[5].Split("|"));
        }
        public string Display()
        {
            return $"Ticket {ticketID} \nSummary) {summary} \nStatus) {status}\nPriority) {priority}\nSubmitter) {submitter}\nAssigned) {assigned}\nWatching) {string.Join(", ", watching)}";
        }
    }
}