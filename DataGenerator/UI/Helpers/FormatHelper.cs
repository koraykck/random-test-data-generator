using Business.ManagerServices.DTOs;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UI.Models;

namespace UI.Helpers
{
    public static class FormatHelper
    {

        public static List<Dictionary<string, RandomDataDTO>> FlattenColsToRow(RandomResultModel model)
        {
            List<Dictionary<string, RandomDataDTO>> rows = new List<Dictionary<string, RandomDataDTO>>();

            for (int i = 0; i < model.NumberOfRecords; i++)
            {
                Dictionary<string, RandomDataDTO> row = new Dictionary<string, RandomDataDTO>();

                foreach (var column in model.Cols)
                {
                    row.Add(column.FieldName, column.Values[i]);

                }
                rows.Add(row);
            }

            return rows;

        }

        public static List<Dictionary<string, RandomDataDTO>> ApplyRules(List<Dictionary<string, RandomDataDTO>> model, List<string> rules)
        {

            foreach (var rule in rules)
            {
                if (rule == "name-gender")
                {
                    foreach (var row in model)
                    {

                        var name = row.Values.Where(x => x.TypeKey == "name").FirstOrDefault();
                        var gender = row.Values.Where(x => x.TypeKey == "gender").FirstOrDefault();

                        if (gender != null)
                        {

                            var keyToUpdate = FindKeyByValue(row, gender);

                            if (keyToUpdate != null && name != null)
                            {
                                gender.Value = string.IsNullOrEmpty(name.DependentValue) ? string.Empty : name.DependentValue;
                                row[keyToUpdate] = gender;
                            }
                        }


                    }
                }
                else if (rule == "country-city")
                {
                    foreach (var row in model)
                    {

                        var country = row.Values.Where(x => x.TypeKey == "country").FirstOrDefault();
                        var city = row.Values.Where(x => x.TypeKey == "city").FirstOrDefault();
                        if (country != null)
                        {
                            var keyToUpdate = FindKeyByValue(row, country);

                            if (keyToUpdate != null && city != null)
                            {
                                country.Value = string.IsNullOrEmpty(city.DependentValue) ? string.Empty : city.DependentValue;
                                row[keyToUpdate] = country;
                            }
                        }
                    }
                }
                else if (rule == "name-mail")
                {
                    foreach (var row in model)
                    {

                        var name = row.Values.Where(x => x.TypeKey == "name").FirstOrDefault();
                        var mail = row.Values.Where(x => x.TypeKey == "mail").FirstOrDefault();
                        if (mail != null)
                        {
                            var keyToUpdate = FindKeyByValue(row, mail);

                            if (keyToUpdate != null && name != null)
                            {
                                mail.Value = (name.Value + "@" + mail.Value.Split("@")[1]).ToLower();
                                row[keyToUpdate] = mail;
                            }
                        }



                    }
                }
                else if (rule == "lastname-mail")
                {
                    foreach (var row in model)
                    {

                        var lname = row.Values.Where(x => x.TypeKey == "last-name").FirstOrDefault();
                        var mail = row.Values.Where(x => x.TypeKey == "mail").FirstOrDefault();


                        if (mail != null)
                        {
                            var keyToUpdate = FindKeyByValue(row, mail);
                            if (keyToUpdate != null && lname != null)
                            {
                                mail.Value = (lname.Value + "@" + mail.Value.Split("@")[1]).ToLower();
                                row[keyToUpdate] = mail;
                            }
                        }



                    }
                }
                else if (rule == "name-lastname-mail")
                {
                    foreach (var row in model)
                    {

                        var lname = row.Values.Where(x => x.TypeKey == "last-name").FirstOrDefault();
                        var name = row.Values.Where(x => x.TypeKey == "name").FirstOrDefault();
                        var mail = row.Values.Where(x => x.TypeKey == "mail").FirstOrDefault();
                        if (mail != null)
                        {
                            var keyToUpdate = FindKeyByValue(row, mail);
                            if (keyToUpdate != null && lname != null && name != null)
                            {
                                mail.Value = (lname.Value + name.Value[0] + "@" + mail.Value.Split("@")[1]).ToLower();
                                row[keyToUpdate] = mail;
                            }
                        }


                    }
                }
            }


            return model;
        }

        static string? FindKeyByValue(Dictionary<string, RandomDataDTO> dict, RandomDataDTO value)
        {
            foreach (var kvp in dict)
            {
                if (kvp.Value == value)
                {
                    return kvp.Key;
                }
            }
            return null;
        }

        public static List<Dictionary<string, string>> ConvertToListOfStringDictionaries(List<Dictionary<string, RandomDataDTO>> listOfDictionaries)
        {
            var result = new List<Dictionary<string, string>>();

            foreach (var dict in listOfDictionaries)
            {
                var stringDict = new Dictionary<string, string>();

                foreach (var kvp in dict)
                {
                    stringDict[kvp.Key] = kvp.Value.Value?.ToString() ?? string.Empty;
                }

                result.Add(stringDict);
            }

            return result;
        }
    }

}
