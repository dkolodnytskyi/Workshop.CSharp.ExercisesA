namespace WebApplication2.Models
{
    public class Schedule
    {
        public Slot Time { get; set; }
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }

        Dictionary<int, List<Slot>> ReceptionHours = new Dictionary<int, List<Slot>>();


        public void AddHourVisit(Patient patient, DateOnly day, TimeOnly startHour, TimeOnly endHour)
        {
            
            Slot time = new Slot(day, startHour, endHour);
            time.SetStatus(true);
            if (ReceptionHours.TryGetValue(Patient.Id, out List<Slot> hours))
            {
                
                ReceptionHours[Patient.Id].Add(time) ;
            }
            else
            {
                ReceptionHours.Add(Patient.Id, new List<Slot>() {time});
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
