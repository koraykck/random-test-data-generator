using Business.ManagerServices.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Extensions
{
    public static class TypeDTOExtensions
    {
       
        public static List<string> CheckRule(this List<DetailedTypesDTO> model)
        {
            List<string> nameGenderRule = new List<string>
            {
                "name",
                "gender"
            };
            List<string> countryCityRule = new List<string>
            {
                "country",
                "city"
            };
            List<string> nameMailRule = new List<string>
            {
                "name",
                "mail"
            };
            List<string> lastNameMailRule = new List<string>
            {
                "last-name",
                "mail"
            };
            List<string> nameLastNameMailRule = new List<string>
            {
                "name",
                "last-name",
                "mail"
            };
            
            var typeKeys = model.Select(x=> x.TypeKey).ToList();
            var returnRules = new List<string>();
            if (nameGenderRule.All(x => typeKeys.Contains(x)))
            {
                returnRules.Add("name-gender");

            }
            if (countryCityRule.All(x => typeKeys.Contains(x)))
            {
                returnRules.Add("country-city");

            }
            if (nameMailRule.All(x => typeKeys.Contains(x)))
            {
                returnRules.Add("name-mail");

            }
            if (lastNameMailRule.All(x => typeKeys.Contains(x)))
            {
                returnRules.Add("lastname-mail");

            }
            if (nameLastNameMailRule.All(x => typeKeys.Contains(x)))
            {
                returnRules.Add("name-lastname-mail");
                returnRules.Remove("name-mail");
                returnRules.Remove("lastname-mail");

            }
            
            return returnRules;

        }
    }
}
