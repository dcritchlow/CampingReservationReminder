﻿using System;
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
            var websiteExists = description.Contains("url");
            var website = string.Empty;
            if (websiteExists)
            {
                var startIndex = description.IndexOf(":", StringComparison.InvariantCulture);
                website = description.Substring(startIndex + 1).StripTagsCharArray();
             
                //var indexOfUrlLink = website.IndexOf('<');
                //if (indexOfUrlLink != -1)
                //{
                //    website = website.Substring(0, indexOfUrlLink);
                //}
            }
            return website;
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
