using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    public class AgentVisitClass
    {
        [DataMember(Order = 1)]
        public int Id { get; set; }
        [DataMember(Order = 2)]
        public int UserId { get; set; }
        [DataMember(Order = 3)]
        public int ClientId { get; set; }
        [DataMember(Order = 4)]
        public string AgentFullName { get; set; }
        [DataMember(Order = 5)]
        public string ClientFullName { get; set; }
        [DataMember(Order = 6)]
        public string Notes { get; set; }
        [DataMember(Order = 7)]
        public string Date { get; set; }
        [DataMember(Order = 8)]
        public double Longitude { get; set; }
        [DataMember(Order = 9)]
        public double Latitude { get; set; }
        [DataMember(Order = 10)]
        public int Order { get; set; }

        public AgentVisitClass PopulateAgentVisit(string[] fieldNames, SqlDataReader reader, string prefix = "")
        {

            var agentVisit = new AgentVisitClass();

            if (fieldNames.Contains(prefix + "Id"))
                if (!Convert.IsDBNull(reader[prefix + "Id"]))
                    agentVisit.Id = Convert.ToInt32(reader[prefix + "Id"]);

            if (fieldNames.Contains(prefix + "UserId"))
                if (!Convert.IsDBNull(reader[prefix + "UserId"]))
                    agentVisit.UserId = Convert.ToInt32(reader[prefix + "UserId"]);

            if (fieldNames.Contains(prefix + "ClientId"))
                if (!Convert.IsDBNull(reader[prefix + "ClientId"]))
                    agentVisit.ClientId = Convert.ToInt32(reader[prefix + "ClientId"]);

            if (fieldNames.Contains(prefix + "AgentFullName"))
                if (!Convert.IsDBNull(reader[prefix + "AgentFullName"]))
                    agentVisit.AgentFullName = reader[prefix + "AgentFullName"].ToString();

            if (fieldNames.Contains(prefix + "ClientFullName"))
                if (!Convert.IsDBNull(reader[prefix + "ClientFullName"]))
                    agentVisit.ClientFullName = reader[prefix + "ClientFullName"].ToString();

            if (fieldNames.Contains(prefix + "Date"))
                if (!Convert.IsDBNull(reader[prefix + "Date"]))
                    agentVisit.Date = reader[prefix + "Date"].ToString();

            if (fieldNames.Contains(prefix + "Notes"))
                if (!Convert.IsDBNull(reader[prefix + "Notes"]))
                    agentVisit.Notes = reader[prefix + "Notes"].ToString();

            if (fieldNames.Contains(prefix + "Longitude"))
                if (!Convert.IsDBNull(reader[prefix + "Longitude"]))
                    agentVisit.Longitude = Convert.ToDouble(reader[prefix + "Longitude"]);

            if (fieldNames.Contains(prefix + "Latitude"))
                if (!Convert.IsDBNull(reader[prefix + "Latitude"]))
                    agentVisit.Latitude = Convert.ToDouble(reader[prefix + "Latitude"]);

            return agentVisit;
        }


        }
}