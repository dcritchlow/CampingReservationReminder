using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using EventQueryService.DTO;

namespace EventQueryService
{
    public class Campers
    {
        private string _description;
        private string _campersRegex => @"campers:\s?(.*)";
        

        private Campers(string description)
        {
            _description = description;
        }

        public static List<Camper> FindNames(string description) => new Campers(description).GetCampers();

        private List<Camper> GetCampers()
        {
            var campersExist = _description.ToLower().Contains("campers");
            if (!campersExist)
            {
                return new List<Camper>();
            }

            var listedCampers = Regex.Matches(_description, _campersRegex)
                .Cast<Match>()
                .Select(match => match.Groups)
                .Select(groups => groups[1])
                .Select(group => group.Value)
                .First()
                .Split(',')
                .ToList()
                .Select(c => c.Trim());

            var campers = new List<Camper>();
            foreach (var camper in listedCampers)
            {
                var approvedCampers = new ApprovedCampers().List;
                if (!approvedCampers.Contains(camper.Trim()))
                {
                    continue;
                }
                campers.Add(new Camper(camper));
            }

            return campers;
        }
    }
}
