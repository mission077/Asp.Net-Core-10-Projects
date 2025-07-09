
using System.Text.RegularExpressions;

namespace Routing.CustomConstraints;


//sales-report/2025/apr
public class MonthsCustomConstraints : IRouteConstraint
{
    public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
    {
        //check wheather the value existes

        if (!values.ContainsKey(routeKey)) //month
        {
            return false; // not a match  
        }

        Regex regex = new Regex("^(apr|jul|oct|jan)$");
        string? monthValue = Convert.ToString(values[routeKey]);


        if(regex.IsMatch(monthValue))
        {
            return true; // is a match
        }
        return false;
    }
}
