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
            ticketID = Int32.Parse(ticketArray[0]);
            summary = ticketArray[1];
            status = ticketArray[2];
            priority = ticketArray[3];
            submitter = ticketArray[4];
            assigned = ticketArray [5];
            watching = new List<string>(ticketArray[6].Split("|"));
        }
        public string Display()
        {
            return $"{ticketID}) {status}\nStatus) {priority}\nPriority) {submitter}\nSubmitter) {assigned}\nAssigned) {string.Join(", ", watching)}\nWatching) {6}";
        }
    }
}