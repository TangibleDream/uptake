namespace UptakeTechTest.steps
{
    internal class DimensionsPage
    {
        internal string btnSubmit = ".//input[@type=\"submit\"]";

        public string getLength(int row)
        {
            return $".//input[@name=\"length-{row}\"]";
        }
        public string getWidth(int row)
        {
            return $".//input[@name=\"width-{row}\"]";
        }
        public string getHeight(int row)
        {
            return $".//input[@name=\"height-{row}\"]";
        }
    }
}