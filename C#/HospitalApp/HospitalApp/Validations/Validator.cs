namespace HospitalApp.Validations
{
    public static class Validator
    {



        public static bool IsDayValid(DateTime DateofVisit)
        {
            if (DateofVisit.DayOfWeek == DayOfWeek.Saturday || DateofVisit.DayOfWeek == DayOfWeek.Sunday)
            {
                return false;
            }

            return true;

        }

        public static bool IsHourValid(DateTime DateofVisit)
        {
            DateTime HourOpen = new DateTime(2023, 1, 27, 9, 0, 0);
            DateTime HourClose = new DateTime(2023, 1, 27, 17, 0, 0);

            if (DateofVisit.Hour <= HourOpen.Hour || DateofVisit.Hour >= HourClose.Hour)
            {
                return false;

            }
                return true;

        }
    }
}
