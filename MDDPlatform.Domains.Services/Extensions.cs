namespace MDDPlatform.Domains.Services;
public static class Extensions
{
    public static string ResolveExpression(this string expression, Dictionary<string,string> keyValues)
    {
        
        string expr = expression;
        var terms = expression.Split('+');        
        foreach(var term in terms)
        {
            if(keyValues.ContainsKey(term))
                expr = expr.Replace(term,keyValues[term]);
        }
        expr = expr.Replace("+","");
        return expr;        
    }
}