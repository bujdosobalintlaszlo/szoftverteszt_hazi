using System.Linq;
public class ValidE
{
    string a;
    string b;
    public ValidE(string a, string b)
    {
        this.a = a;
        this.b = b;
    }
    public bool Eldont()
    {
        return IsValidNumber(a) && IsValidNumber(b);
    }
    private bool IsValidNumber(string s)
    {
        if (string.IsNullOrEmpty(s)) return false;

        if (s[0] == '-') 
        {
            if (s.Length == 1 || s[1] == '0') return false;
            return s.Substring(1).All(c => char.IsDigit(c)); 
        }
        else
        {
            return !(s.Length > 1 && s[0] == '0' || !char.IsDigit(s[0])) && !s.Any(c => !char.IsDigit(c));
        }
    }
}