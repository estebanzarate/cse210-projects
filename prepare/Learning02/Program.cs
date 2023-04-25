using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        Job job2 = new Job();
        job1._jobTitle = "Software Engineer";
        job2._jobTitle = "Manager";
        job1._company = "Microsoft";
        job2._company = "Apple";
        job1._startYear = "2019";
        job2._startYear = "2022";
        job1._endYear = "2022";
        job2._endYear = "2023";
        job1.DisplayJobDetails();
        job2.DisplayJobDetails();

        Resume myResume = new Resume();
        myResume._name = "Allison Rose";
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);
        myResume.Display();
    }
}