namespace Model_Object
{
    //Data Object class to store the different symptoms along with their medication.
    public class SymptomsOrDiseaseDO
    {
        public string SymptomsOrDiseaseName { get; set; }
        public string Medication { get; set; }
        public string Tests { get; set; }
        public string Cure { get; set; }
    }
}
