using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    public class AgentClientClass
    {
        [DataMember(Order = 1)]
        public int Id { get; set; }
        [DataMember(Order = 2)]
        public int AgentId { get; set; }
        [DataMember(Order = 3)]
        public int ClientId { get; set; }
        [DataMember(Order = 4)]
        public string AgentFullName { get; set; }
        [DataMember(Order = 5)]
        public string ClientFullName { get; set; }
        [DataMember(Order = 6)]
        public int Order { get; set; }

        public AgentClientClass PopulateAgentClient(string[] fieldNames, SqlDataReader reader)
        {
            var agentClient = new AgentClientClass();

            if (fieldNames.Contains("Id"))
                if (!Convert.IsDBNull(reader["Id"]))
                    agentClient.Id = (int)reader["Id"];

            if (fieldNames.Contains("AgentId"))
                if (!Convert.IsDBNull(reader["AgentId"]))
                    agentClient.AgentId = (int)reader["AgentId"];

            if (fieldNames.Contains("ClientId"))
                if (!Convert.IsDBNull(reader["ClientId"]))
                    agentClient.ClientId = (int)reader["ClientId"];

            if (fieldNames.Contains("AgentFullName"))
                if (!Convert.IsDBNull(reader["AgentFullName"]))
                    agentClient.AgentFullName = reader["AgentFullName"].ToString();

            if (fieldNames.Contains("ClientFullName"))
                if (!Convert.IsDBNull(reader["ClientFullName"]))
                    agentClient.ClientFullName = reader["ClientFullName"].ToString();

            return agentClient;
        }

    }
}