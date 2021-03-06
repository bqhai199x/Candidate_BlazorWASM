using Candidate_BlazorWASM.Shared;
using System;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Linq.Dynamic.Core;
using Candidate_BlazorWASM.Shared.ViewModels;

namespace Candidate_BlazorWASM.Server.Extensions
{
    public static class CandidateExtensions
    {
        public static IQueryable<CandidateVM> Search(this IQueryable<CandidateVM> candidates, string searchTearm)
        {
            if (string.IsNullOrWhiteSpace(searchTearm))
                return candidates;
            var lowerCaseSearchTerm = searchTearm.Trim().ToLower();
            return candidates.Where(p => p.FullName.ToLower().Contains(lowerCaseSearchTerm));
        }

        public static IQueryable<CandidateVM> Sort(this IQueryable<CandidateVM> candidates, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return candidates.OrderBy(e => e.FullName);

            var orderParams = orderByQueryString.Trim().Split(',');
            var propertyInfos = typeof(CandidateVM).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var orderQueryBuilder = new StringBuilder();
            foreach (var param in orderParams)
            {
                if (string.IsNullOrWhiteSpace(param))
                    continue;

                var propertyFromQueryName = param.Split(" ")[0];
                var objectProperty = propertyInfos.FirstOrDefault(pi => pi.Name.Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase));

                if (objectProperty == null)
                    continue;

                var direction = param.EndsWith(" desc") ? "descending" : "ascending";
                orderQueryBuilder.Append($"{objectProperty.Name} {direction}, ");
            }

            var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');
            if (string.IsNullOrWhiteSpace(orderQuery))
                return candidates.OrderBy(e => e.FullName);

            var x = candidates.OrderBy(orderQuery);
            return x;
        }
    }
}
