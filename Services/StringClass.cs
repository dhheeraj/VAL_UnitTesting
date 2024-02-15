namespace Services
{
    public class StringClass
    {
        public string AlwaysReturnString(string str)
        {
            if (string.IsNullOrEmpty(str)) return string.Empty;
            return $"Hello {str}";

        }
        public string HandleException(string str1, string str2)
        {
            try
            {
                if (str1 == null) return string.Empty;
                // intently making mistake
                str1 = str2.Trim();
                return str1;

            }
            catch (Exception ex)
            {
                throw;

            }

        }

        public List<string> AppendToStringInCollection(List<string> strCollection)
        {
            if (strCollection == null) { return null; }
            List<string> newCollection = new List<string>();
            foreach (string str in strCollection)
            {
                if (str != null)
                {
                    newCollection.Add($"Hi {str}");
                }
            }
            return newCollection;

        }
    }
}
