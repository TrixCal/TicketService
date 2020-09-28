using System;
using System.Collections.Generic;

namespace TicketService
{
    public class Ticket
    {
        public int ticketID { get; set; }
        public string status { get; set; }
        public string priority { get; set; }
        public string submitter { get; set; }
        public string assigned { get; set; }
        public List<string> watching { get; set; }

        public string Display()
        {
            return $"{ticketID}) {status}\nStatus) {priority}\nPriority) {submitter}\nSubmitter) {assigned}\nAssigned) {string.Join(", ", watching)}\nWatching) {6}";
        }
    }
}