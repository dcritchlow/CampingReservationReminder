using System;
using System.Collections.Generic;
using EventQueryService.DTO;

namespace EventQueryService
{
    public static class EventStringExtensions
    {
        public static string GetDisplayTitle(this string summary)
        {
            var startIndex = summary.IndexOf('-');
            var newTitle = summary.Substring(startIndex + 1).Trim();
            
            return newTitle;
        }

        public static string GetCampType(this string description)
        {
            var campTypeExists = description.Contains("#");
            var campType = string.Empty;
            if (campTypeExists)
            {
                var startIndex = description.IndexOf("#", StringComparison.InvariantCulture);
                campType = description.Substring(startIndex + 1);
                var indexOfPlainUrl = campType.IndexOf(Environment.NewLine, StringComparison.InvariantCulture);
                if(indexOfPlainUrl != -1)
                {
                    campType = campType.Substring(0, indexOfPlainUrl);
                }
                var indexOfUrlLink = campType.IndexOf('<');
                if(indexOfUrlLink != -1)
                {
                    campType = campType.Substring(0, indexOfUrlLink);
                }
            }
            return campType;
        }

        public static string GetWebsite(this string description)
        {
            var desc = description.StripTagsCharArray();
            var websiteExists = desc.Contains("url");
            var website = string.Empty;
            if (websiteExists)
            {
                var startIndex = desc.IndexOf(":", StringComparison.InvariantCulture);
                var endIndex = desc.IndexOf("campers:", StringComparison.InvariantCulture);
                if (endIndex > 0)
                {
                    website = desc.Substring(startIndex + 1, endIndex - startIndex - 1);
                }
                else
                {
                    website = desc.Substring(startIndex + 1);
                }
            }
            return website;
        }

        public static List<Camper> GetCampers(this string description)
        {
            var campers = Campers.FindNames(description);
            return campers;
        }

        private static string StripTagsCharArray(this string source)
        {
            char[] array = new char[source.Length];
            int arrayIndex = 0;
            bool inside = false;

            for (int i = 0; i < source.Length; i++)
            {
                char let = source[i];
                if (let == '<')
                {
                    inside = true;
                    continue;
                }
                if (let == '>')
                {
                    inside = false;
                    continue;
                }
                if (!inside)
                {
                    array[arrayIndex] = let;
                    arrayIndex++;
                }
            }
            return new string(array, 0, arrayIndex);
        }
    }
}
