// Encapsulation de propriété
namespace ConsoleApp4
{
    //public class CoffreFort
    //{
    //    public string Utilisateur = "Inconnu";
    //    private string Code = "0000";
    //    public string GetCode()
    //    {
    //        if (Utilisateur == "André")
    //            return Code;
    //        else
    //            return null;
    //    }
    //    public void SetCode(string value)
    //    {
    //        if (Utilisateur == "André") Code = value;
    //    }
    //}
    public class CoffreFort
    {
        public string Utilisateur = "Inconnu";
        private string code = "000";
        public string Code
        {
            get
            {
                if (Utilisateur == "André")
                    return code;
                else
                    return null;
            }
            set
            {
                if (Utilisateur == "André") code = value;
            }
        }
    }
}

