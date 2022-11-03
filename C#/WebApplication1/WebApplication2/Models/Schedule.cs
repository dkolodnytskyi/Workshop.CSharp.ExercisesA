namespace WebApplication2.Models
{
    public class Schedule
    {
        public Time Time { get; set; }
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }

        Dictionary<int, List<Time>> ReceptionHours = new Dictionary<int, List<Time>>();


        public void AddHourVisit(Patient Patient, DateOnly day, TimeOnly startHour, TimeOnly endHour)
        {
            
            Time time = new Time(day, startHour, endHour);
            time.SetStatus(true);
            if (ReceptionHours.TryGetValue(Patient.Id, out List<Time> hours))
            {
                
                ReceptionHours[Patient.Id].Add(time) ;
            }
            else
            {
                ReceptionHours.Add(Patient.Id, new List<Time>() {time});
            }
            
            
        }

        public void EditHourVisit()
        {

        }

        public void RemoveHoursVisit()
        {

        }

        public void ShowRHours()
        {
            foreach (var hour in ReceptionHours)
            {
                foreach(var item in hour.Value)
                {
                    Console.WriteLine($"key: {hour.Key} value:{item}");
                }
                
            }
        }
    }
}
