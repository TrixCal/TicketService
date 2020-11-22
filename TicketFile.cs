using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using NLog.Web;

namespace TicketService
{
    public class TicketFile
    {
        public string filePath { get; set; }
        public List<Bug> bugs { get; set; }
        public List<Enhancement> enhancements { get; set; }
        public List<Task> tasks { get; set; }
        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();
        public TicketFile(string ticketFilePath)
        {
            filePath = ticketFilePath;
            bugs = new List<Bug>();
            enhancements = new List<Enhancement>();
            tasks = new List<Task>();
            //Add tickets from data file to list
            try
            {
                StreamReader sr = new StreamReader(filePath);
                while(!sr.EndOfStream)
                {

                    string line = sr.ReadLine();
                    string[] arr = line.Split(",");
                    //Add ticket through data in arr
                    if(arr.Count() == 8)
                    {
                        Bug ticket = new Bug(){
                            ticketID = Int32.Parse(arr[0]),
                            summary = arr[1],
                            status = arr[2],
                            priority = arr[3],
                            submitter = arr[4],
                            assigned = arr[5],
                            watching = arr[6].Split("|").ToList<string>(),
                            severity = arr[7]
                        };
                    }
                    else if(arr.Count() == 11)
                    {
                        Enhancement ticket = new Enhancement(){
                            ticketID = Int32.Parse(arr[0]),
                            summary = arr[1],
                            status = arr[2],
                            priority = arr[3],
                            submitter = arr[4],
                            assigned = arr[5],
                            watching = arr[6].Split("|").ToList<string>(),
                            software = arr[7],
                            cost = Double.Parse(arr[8]),
                            reason = arr[9],
                            estimate = Double.Parse(arr[10])
                        };
                    }
                    else if(arr.Count() == 9)
                    {
                        Task ticket = new Task(){
                            ticketID = Int32.Parse(arr[0]),
                            summary = arr[1],
                            status = arr[2],
                            priority = arr[3],
                            submitter = arr[4],
                            assigned = arr[5],
                            watching = arr[6].Split("|").ToList<string>(),
                            projectName = arr[7],
                            duedate = DateTime.Parse(arr[8])
                        };
                    }
                }
                sr.Close();
                logger.Info($"Tickets in file Bugs:{bugs.Count}   Enhancements:{enhancements.Count}   Tasks:{tasks.Count}.");
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
        }
        public void RewriteFile()
        {
            StreamWriter sw = new StreamWriter(filePath);
            foreach(Bug b in bugs){
                sw.WriteLine(b.ToString());
            }
            foreach(Enhancement e in enhancements){
                sw.WriteLine(e.ToString());
            }
            foreach(Task t in tasks){
                sw.WriteLine(t.ToString());
            }
            sw.Close();
        }
        public void AddTicket(Bug ticket)
        {
            try
            {
                //Generate ticket ID
                ticket.ticketID = bugs.Any() ? bugs.Max(m => m.ticketID) + 1 : 1;
                //Add ticket to file
                StreamWriter sw = new StreamWriter(filePath, true);
                sw.WriteLine(ticket.ToString());
                sw.Close();
                //Add ticket to list
                bugs.Add(ticket);
                logger.Info($"Ticket ID {ticket.ticketID} Added.");
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
        }
        public void AddTicket(Enhancement ticket)
        {
            try
            {
                //Generate ticket ID
                ticket.ticketID = enhancements.Any() ? enhancements.Max(m => m.ticketID) + 1 : 1;
                //Add ticket to file
                StreamWriter sw = new StreamWriter(filePath, true);
                sw.WriteLine(ticket.ToString());
                sw.Close();
                //Add ticket to list
                enhancements.Add(ticket);
                logger.Info($"Ticket ID {ticket.ticketID} Added.");
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
        }
        public void AddTicket(Task ticket)
        {
            try
            {
                //Generate ticket ID
                ticket.ticketID = tasks.Any() ? tasks.Max(m => m.ticketID) + 1 : 1;
                //Add ticket to file
                StreamWriter sw = new StreamWriter(filePath, true);
                sw.WriteLine(ticket.ToString());
                sw.Close();
                //Add ticket to list
                tasks.Add(ticket);
                logger.Info($"Ticket ID {ticket.ticketID} Added.");
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
        }
        public void RemoveTicket(string group, int ticketID)
        {
            switch(group)
            {
                case "1":
                    //Removes Bug from List
                    for(int i = 0; i < bugs.Count; i++)
                    {
                        if(bugs[i].ticketID == ticketID) bugs.RemoveAt(i);
                    }
                    logger.Info($"Bug ID {ticketID} Removed.");
                    RewriteFile();
                break;
                case "2":
                    //Removes Enhancement from List
                    for(int i = 0; i < enhancements.Count; i++)
                    {
                        if(enhancements[i].ticketID == ticketID) enhancements.RemoveAt(i);
                    }
                    logger.Info($"Enhancement ID {ticketID} Removed.");
                    RewriteFile();
                break;
                case "3":
                    //Removes Task from List
                    for(int i = 0; i < tasks.Count; i++)
                    {
                        if(tasks[i].ticketID == ticketID) tasks.RemoveAt(i);
                    }
                    logger.Info($"Task ID {ticketID} Removed.");
                    RewriteFile();
                break;
            }
        }
    }
}